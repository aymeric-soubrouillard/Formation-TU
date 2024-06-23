using ProjetFormation.tuto1.doublure;
using Moq;
using NUnit.Framework;

[TestFixture]
public class OrderServiceTests
{
    [Test]
    public void ProcessOrder_ShouldUpdateOrderStatusToProcessed()
    {
        // Given
        var stubOrderRepository = new StubOrderRepository();
        var order = new Order(1,"New","John");
        stubOrderRepository.SetOrder(order);
        var orderService = new OrderService(stubOrderRepository);

        // When
        orderService.ProcessOrder(1);

        // Then
        Assert.AreEqual("Processed", order.Status);
    }
    
}