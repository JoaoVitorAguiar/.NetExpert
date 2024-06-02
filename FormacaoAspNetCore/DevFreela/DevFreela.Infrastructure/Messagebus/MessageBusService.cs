using DevFreela.Core.Services;
using RabbitMQ.Client;

namespace DevFreela.Infrastructure.Messagebus;

public class MessageBusService : IMessageBusService
{
    private readonly ConnectionFactory _factory;
    public MessageBusService()
    {
        _factory = new ConnectionFactory
        {
            HostName = "localhost"
        };
    }

    public void Publish(string queue, byte[] message)
    {
        using (var connection = _factory.CreateConnection())
        {
            using (var chanel = connection.CreateModel())
            {
                // Garantindo que a fila seja criada
                chanel.QueueDeclare(
                    queue: queue,
                    durable: false,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null
                );

                // Publicar a menssagem
                chanel.BasicPublish(
                    exchange: "",
                    routingKey: queue,
                    basicProperties: null,
                    body: message
                );
            }
        }
    }
}
