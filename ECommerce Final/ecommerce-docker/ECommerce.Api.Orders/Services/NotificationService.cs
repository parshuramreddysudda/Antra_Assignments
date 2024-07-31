using Microsoft.Azure.NotificationHubs;

namespace ECommerce.Api.Orders.Services;

public class NotificationService
{
    private readonly IConfiguration _configuration;
    private readonly NotificationHubClient _hub;

    public NotificationService(IConfiguration configuration)
    {
        var connectionString = configuration["AzureNotificationHub:ConnectionString"];
        var hubName = configuration["AzureNotificationHub:HubName"];
        _hub = NotificationHubClient.CreateClientFromConnectionString(connectionString, hubName);

    }
}