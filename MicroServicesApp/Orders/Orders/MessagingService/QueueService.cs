using System.Text;
using System.Text.Json;
using Azure.Messaging.ServiceBus;
using Azure.Storage.Queues;
using NuGet.Protocol.Plugins;

namespace Orders.MessagingService;

public class QueueService
{ 
    private readonly IConfiguration _configuration;
    public QueueService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task SendMessageAsync<T>(T message,string queueName)
    {
        if (message == null)
        {
            var queueClient = new ServiceBusClient(_configuration.GetConnectionString("AzureServiceBus"));
            var sender = queueClient.CreateSender(queueName);
            string messagebody = JsonSerializer.Serialize(message);
            var messageData= new ServiceBusMessage(Encoding.UTF8.GetBytes(messagebody)) ;
            await sender.SendMessageAsync(messageData);
        }
    }
    
}