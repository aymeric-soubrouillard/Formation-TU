public class Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public double Weight { get; set; }

    public Product(string name, decimal price, double weight)
    {
        Name = name;
        Price = price;
        Weight = weight;
    }
}
