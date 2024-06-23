namespace ProjetFormation.tuto1.doublure;

public interface IOrderRepository
{
    Order GetOrderById(int orderId);
    void Save(Order order);
}