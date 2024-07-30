using System.Net.Http.Json;
using System.Text;
using ApplicationCore.Model.Request;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace ECommerce.OrderProcessingService.RabbitMQConsumer;

public class OrderQueueConsumer
{
    private readonly string _hostname;
    private readonly string _username;
    private readonly string _password;
    private readonly string _queueName;
    private readonly HttpClient _httpClient;

    public OrderQueueConsumer(string hostname, string username, string password, string queueName)
    {
        _hostname = hostname;
        _username = username;
        _password = password;
        _queueName = queueName;
        _httpClient = new HttpClient { BaseAddress = new Uri("host.docker.internal:46003") }; // Base address for your API
    }

    public void Start()
    {
        var factory = new ConnectionFactory() { HostName = _hostname, UserName = _username, Password = _password };
        var connection = factory.CreateConnection();
        var channel = connection.CreateModel();

        channel.QueueDeclare(queue: _queueName, durable: true, exclusive: false, autoDelete: false, arguments: null);

        Console.WriteLine("Currently in queue");
        var consumer = new EventingBasicConsumer(channel);
        consumer.Received += async (model, ea) =>
        {
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            Console.WriteLine(" [x] Received {0}", message);
            var orderId = Int32.Parse(message);
            var order = await GetOrderAsync(orderId);
            if (order != null)
                ProcessOrder(order);
                    
                    
        };

        channel.BasicConsume(queue: _queueName, autoAck: true, consumer: consumer);
        Console.WriteLine(" Press [enter] to exit.");
        Console.ReadLine();
    }

    private async Task<OrderResponseModel?> GetOrderAsync(int id)
    {
        try
        {
            var response = await _httpClient.GetAsync($"/api/Orders/order/{id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                // Console.WriteLine("Fetched Order JSON: " + jsonString);

                var orders = JsonConvert.DeserializeObject<List<OrderResponseModel>>(jsonString);
                // Console.WriteLine("Deserialized Orders: " + JsonConvert.SerializeObject(orders));
                return orders[0];
            }
            else
            {
                Console.WriteLine($"Error fetching order: {response.StatusCode}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching order: {ex.Message}");
        }

        return null;
    }

    private void ProcessOrder(OrderResponseModel order)
    {
        // Update order status in the database
        order.OrderStatus = "Delivered"; // or other statuses like "Shipped", "Delivered"
        _ = UpdateOrderInDatabase(order);
        Console.WriteLine("Order processed: " + order.Id);
    }

    private async Task UpdateOrderInDatabase(OrderResponseModel order)
    {
        try
        {
            var response = await _httpClient.PutAsJsonAsync($"/api/Orders/", order);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine($"Order {order.Id} updated in database with status {order.OrderStatus}");
            }
            else
            {
                Console.WriteLine($"Error updating order: {response.StatusCode}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error updating order: {ex.Message}");
        }
    }
}
