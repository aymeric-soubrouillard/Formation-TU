namespace ProjetFormation.tuto1.doublure;

public class Order(int orderId, string customerName, string status)
{
    public int OrderId { get; set; } = orderId;
    public string CustomerName { get; set; } = customerName;
    public string Status { get; set; } = status;
}