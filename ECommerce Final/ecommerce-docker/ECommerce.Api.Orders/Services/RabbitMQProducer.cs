using System.Text;
using ECommerce.Api.Orders.Interfaces;
using RabbitMQ.Client;

namespace ECommerce.Api.Orders.Services;

public class RabbitMqProducer:IRabbitMQProducer
{
    private readonly string _hostname;
    private readonly string _username;
    private readonly string _password;
    private readonly string _queueName;

    public RabbitMqProducer(string hostname,string username,string password,string queueName)
    {
        _queueName = queueName;
        _password = password;
        _username = username;
        _hostname = hostname;
    }

    public void SendMessage(string message)
    {
        var factory= new ConnectionFactory(){HostName = _hostname,UserName = _username,Password = _password};
        using var connection = factory.CreateConnection();
        using var channel = connection.CreateModel();
        {
            channel.QueueDeclare(queue: _queueName, durable: true, exclusive: false, autoDelete: false,
                arguments: null);
            var body = Encoding.UTF8.GetBytes(message);
            channel.BasicPublish(exchange:"",routingKey:_queueName,basicProperties:null,body:body);
            Console.WriteLine("[x] Sent {0}",message);
            Console.WriteLine("Message complete log is ",message);
        }


    }
}