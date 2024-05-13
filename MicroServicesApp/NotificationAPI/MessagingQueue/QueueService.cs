using System.Text;
using System.Text.Json;
using ApplicationCore.Entities.Orders;
using Azure.Messaging.ServiceBus;

namespace NotificationAPI.MessagingQueue;

public class QueueService
{
    private readonly IConfiguration _configuration;
    public QueueService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<Order_Details> ReadMsgAsync(string queue)
    {
        var queueClient = new ServiceBusClient(_configuration.GetConnectionString("AzureServiceBus"));
        var receiver = queueClient.CreateReceiver(queue);
        receiver.ReceiveMessageAsync();
        var message = await receiver.ReceiveMessageAsync();
        var encodedString=Encoding.UTF8.GetString(message.Body);
        return JsonSerializer.Deserialize<Order_Details>(encodedString);
    }
}