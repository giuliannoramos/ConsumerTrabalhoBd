using System;
using System.Text.Json;
using MassTransit;
using Trabalho123.Shared;


namespace MassTransitConsumer.NotificationCreatedConsumer
{
    public class NotificationCreatedConsumer : IConsumer<INotificationCreated>
    {
        public async Task Consume(ConsumeContext<INotificationCreated> context)
        {
            if (context.Message.Clientes == null)
            {
                Console.WriteLine("Mensagem de notificação é nula.");
                return;
            }

            var clientes = context.Message.Clientes;      

            // Serializa a lista 'clientes' e imprime a representação JSON
            string clientesJson = JsonSerializer.Serialize(clientes, new JsonSerializerOptions { });
            Console.WriteLine("Clientes JSON: " + clientesJson);
            
            // Imprime os detalhes de cada cliente
            foreach (var cliente in clientes)
            {
                Console.WriteLine($"Nome: {cliente.Nome}, Telefone: {cliente.Telefone}");
            }
        }
    }
}