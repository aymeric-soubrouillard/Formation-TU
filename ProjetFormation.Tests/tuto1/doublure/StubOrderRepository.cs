using ProjetFormation.tuto1.doublure;

public class StubOrderRepository : IOrderRepository
{
    private Order? _order;

    public Order GetOrderById(int orderId)
    {
        return _order;
    }

    public void Save(Order order)
    {
        _order = order;
    }

    public void SetOrder(Order order)
    {
        _order = order;
    }
}