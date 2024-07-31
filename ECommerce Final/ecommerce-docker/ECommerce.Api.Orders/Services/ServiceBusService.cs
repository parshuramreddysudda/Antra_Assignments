using System.Text.Json;
using Azure.Messaging.ServiceBus;

namespace ECommerce.Api.Orders.Services;

public class ServiceBusService
{
    private readonly ServiceBusClient _client;
    private readonly IConfiguration _configuration;
    private readonly string _queueName;

    public ServiceBusService(IConfiguration configuration)
    {
        var connectionString = configuration["AzureServiceBus:ConnectionString"];
        _queueName = configuration["AzureServiceBus:QueueName"];
        _client = new ServiceBusClient(connectionString);
    }

    public async Task SendMessageAsync<T>(T message)
    {
        var sender = _client.CreateSender(_queueName);
        var jsonMessage = JsonSerializer.Serialize(message);
        var serviceBusMessage = new ServiceBusMessage(jsonMessage);
        try
        {
            await sender.SendMessageAsync(serviceBusMessage);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
    }

    public async Task ReceiveMessagesAsync()
    {
        var processor = _client.CreateProcessor(_queueName, new ServiceBusProcessorOptions());
        processor.ProcessMessageAsync += MessageHandler;
        processor.ProcessErrorAsync += ErrorHandler;

        await processor.StartProcessingAsync();
    }
    private async Task MessageHandler(ProcessMessageEventArgs args)
    {
        var body = args.Message.Body.ToString();
        Console.WriteLine($"Received message: {body}");

        // Process the message
        await args.CompleteMessageAsync(args.Message);
    }

    private Task ErrorHandler(ProcessErrorEventArgs args)
    {
        Console.WriteLine($"Error: {args.Exception.ToString()}");
        return Task.CompletedTask;
    }
}