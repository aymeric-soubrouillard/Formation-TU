using ProjetFormation.tuto1.doublure;
using Moq;
using NUnit.Framework;

[TestFixture]
public class OrderServiceTests
{
    [Test]
    public void ProcessOrder_ShouldUpdateOrderStatusToProcessedStub()
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

        [Test]
    public void ProcessOrder_ShouldUpdateOrderStatusToProcessedMock()
    {
        // Given
        var mockOrderRepository = new Mock<IOrderRepository>();
        var order = new Order(1,"New","John");
        mockOrderRepository.Setup(repo => repo.GetOrderById(1)).Returns(order);
        var orderService = new OrderService(mockOrderRepository.Object);
        // When
        orderService.ProcessOrder(1);
        // Then
        Assert.AreEqual("Processed", order.Status);
        mockOrderRepository.Verify(repo => repo.GetOrderById(1), Times.Once);
    }

    
    public void ProcessOrder_ShouldSaveInRepository()
    {
        // Given
        var mockOrderRepository = new Mock<IOrderRepository>();
        var order = new Order(1,"New","John");
        mockOrderRepository.Setup(repo => repo.GetOrderById(1)).Returns(order);
        var orderService = new OrderService(mockOrderRepository.Object);
        // When
        orderService.ProcessOrder(1);
        // Then
        mockOrderRepository.Verify(repo => repo.Save(order), Times.Once);
    }
    
}