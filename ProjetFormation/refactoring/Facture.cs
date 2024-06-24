public class Facture
{
    public int Id { get; set; }
    public string Entreprise { get; set; }
    public string Adresse { get; set; }
    public DateTime DateFacture { get; set; }
    public List<object[]> Produits { get; set; }
    public double MontantTotal { get; set; }
    public FormatExtraction Format { get; set; }

    public Facture()
    {
        Produits = new List<object[]>();
    }
}

public enum FormatExtraction
{
    PDF,
    XML,
    JPEG
}
