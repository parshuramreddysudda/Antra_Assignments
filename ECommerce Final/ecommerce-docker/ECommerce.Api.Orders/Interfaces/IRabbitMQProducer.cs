namespace ECommerce.Api.Orders.Interfaces;

public interface IRabbitMQProducer
{
    public void SendMessage(string message);
}