public class Achat
{
    public int Id { get; set; }
    private List<object[]> Produits { get; set; }

    public Achat()
    {
        Produits = new List<object[]>();
    }

    public void AddProduct(int id, string nom, int quantite, double prixUnitaire)
    {
        Produits.Add(new object[] { id, nom, quantite, prixUnitaire });
    }

    public List<object[]> GetProduits()
    {
        return Produits;
    }
}
