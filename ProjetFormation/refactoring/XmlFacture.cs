using System;
using System.Collections.Generic;
using System.Xml;
public class XMLFacture
{

    private readonly Facture facture;

    public XMLFacture(Facture factureParam){
        facture=factureParam;
    }

    public void writeFile()
    {
        //Le repertore XML
        string directoryXML = "/repertoire/xml";
        // Le chemin XML
        string filePathXML = System.IO.Path.Combine(directoryXML, $"facture_{facture.Id}.xml");

        using (XmlWriter writer = XmlWriter.Create(filePathXML))
        {
            writer.WriteStartDocument();
            writer.WriteStartElement("Facture"); // debut facture

            writer.WriteElementString("Id", facture.Id.ToString());
            writer.WriteElementString("Entreprise", facture.Entreprise);
            writer.WriteElementString("Adresse", facture.Adresse);
            writer.WriteElementString("DateFacture", facture.DateFacture.ToString("yyyy-MM-ddTHH:mm:ss"));

            writer.WriteStartElement("Produits");
            // Pour chaque produit dans la liste on ecrit le produit
            foreach (var produit in facture.Produits)
            {
                writer.WriteStartElement("Produit");

                writer.WriteElementString("Id", produit[0].ToString());
                writer.WriteElementString("Nom", produit[1].ToString());
                writer.WriteElementString("PrixUnitaire", produit[2].ToString());
                writer.WriteElementString("Quantite", produit[3].ToString());

                writer.WriteEndElement(); 
            }
            writer.WriteEndElement(); // fin facture

            writer.WriteElementString("MontantTotal", facture.MontantTotal.ToString());

            writer.WriteEndElement();  // fin facture
            writer.WriteEndDocument();
        }
    }
}