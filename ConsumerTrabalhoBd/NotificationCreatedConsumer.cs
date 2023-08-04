using MassTransit;
using System.Text.Json;
using TrabalhoBancoDeDados.Shared;


namespace MassTransitConsumer.NotificationCreatedConsumer;

public class NotificationCreatedConsumer : IConsumer<INotificationCreated>
{
    public async Task Consume(ConsumeContext<INotificationCreated> context)
    {
        var serializedMessage = JsonSerializer.Serialize(context.Message, new JsonSerializerOptions { });

        Console.WriteLine($"Producer: {serializedMessage}");
    }
}