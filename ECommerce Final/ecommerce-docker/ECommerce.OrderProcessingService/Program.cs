using ApplicationCore.Constants;
using ECommerce.OrderProcessingService.RabbitMQConsumer;

namespace ECommerce.OrderProcessingService;

class Program
{
    static void Main(string[] args)
    {
        var consumer = new OrderQueueConsumer(Constants.ORDER_QUEUE_HOST_NAME,Constants.ORDER_QUEUE_USER_NAME,Constants.ORDER_QUEUE_PASSWORD,Constants.ORDER_QUEUE_NAME);
        consumer.Start();
    }
}