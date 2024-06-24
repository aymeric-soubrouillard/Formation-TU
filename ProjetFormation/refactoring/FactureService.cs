using System;
using System.Collections.Generic;
using System.Data.SqlClient;

public class FactureService
{
    public void TraiterAchatEnFacture(Achat achat, bool merge, Facture factureExistante, string pdfDirectory, string notificationIp, int notificationPort, bool shouldPersist)
    {
        string connectionString = DBConfig.GetConnectionString();

        string entreprise = "";
        string adresse = "";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string query = "SELECT NomEntreprise, AdresseEntreprise FROM Entreprises WHERE Id = @Id";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", achat.Id);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        entreprise = reader["NomEntreprise"].ToString();
                        adresse = reader["AdresseEntreprise"].ToString();
                    }
                }
            }
        }

        Facture facture = new Facture
        {
            Entreprise = entreprise,
            Adresse = adresse,
            DateFacture = DateTime.Now,
            Produits = achat.GetProduits(),
            MontantTotal = 0
        };

        XMLFacture xmlFacture = new XMLFacture(facture);

        foreach (var produit in achat.GetProduits())
        {
            facture.MontantTotal += (int)produit[2] * (double)produit[3]; // produit[1] = Quantite, produit[2] = PrixUnitaire
        }

        if (merge)
        {
            if (factureExistante == null)
            {
                throw new Exception("Une facture doit être passée en paramètre");
            }

            foreach (var produitExistant in factureExistante.Produits)
            {
                bool produitDejaExistant = false;

                foreach (var produit in facture.Produits)
                {
                    if ((int)produit[0] == (int)produitExistant[0]) // produit[0] = Id
                    {
                        produitDejaExistant = true;
                        break;
                    }
                }

                if (!produitDejaExistant)
                {
                    facture.Produits.Add(produitExistant);
                }
                else
                {
                    facture.Produits.Add(produitExistant);
                }
            }

            foreach (var produit in factureExistante.Produits)
            {
                facture.MontantTotal += (int)produit[2] * (double)produit[3];
            }
        }

        switch (facture.Format)
        {
            case FormatExtraction.PDF:
                string filePathPDF = System.IO.Path.Combine(pdfDirectory, "facture.pdf");
                System.IO.File.WriteAllText(filePathPDF, "Données de la facture en PDF");
                break;
            case FormatExtraction.XML:
                xmlFacture.writeFile();
                break;
            case FormatExtraction.JPEG:
                throw new NotImplementedException("please use PDF or XML");
            default:
                throw new Exception("Cas impossible");
        }

        string url = $"http://{notificationIp}:{notificationPort}/notification/facture/urgent";

        if (facture.MontantTotal > 10000 && facture.Produits.Count > 10 || facture.Entreprise.Contains("VIP"))
        {
            using (var client = new System.Net.Http.HttpClient())
            {
                var content = new System.Net.Http.StringContent($"Facture ID: {facture.Id}");
                client.PostAsync(url, content).Wait();
            }
        }

        if (shouldPersist)
        {
            Console.WriteLine("La facture a été persisté");
        }

        if (facture != null && facture.MontantTotal > 0)
        {
            Console.WriteLine("La facture a bien été traitée");
        }
    }
}
