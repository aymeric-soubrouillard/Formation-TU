namespace ProjetFormation.tuto1.doublure;

public class OrderService
{
    private readonly IOrderRepository _orderRepository;

    public OrderService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public void ProcessOrder(int orderId)
    {
        var order = _orderRepository.GetOrderById(orderId);
        if (order != null)
        {
            order.Status = "Processed";
            _orderRepository.Save(order);
        }
    }
}