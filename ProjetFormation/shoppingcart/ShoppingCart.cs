using System.Collections.Generic;

public class ShoppingCart
{
    private List<Product> products = new List<Product>();
    public decimal TotalAmount { get; private set; }
    public decimal Discount { get; private set; }

    public void AddProduct(Product product)
    {
        products.Add(product);
        UpdateTotalAmount();
    }

    public void RemoveProduct(Product product)
    {
        products.Remove(product);
    }

    public void ApplyDiscount(decimal discount)
    {
        Discount = discount;
        UpdateTotalAmount();
    }

    private void UpdateTotalAmount()
    {
        TotalAmount = 0;
        foreach (var product in products)
        {
            TotalAmount += product.Price;
        }
        TotalAmount -= Discount;
    }

    public List<Product> GetProducts()
    {
        return new List<Product>(products);
    }
}
