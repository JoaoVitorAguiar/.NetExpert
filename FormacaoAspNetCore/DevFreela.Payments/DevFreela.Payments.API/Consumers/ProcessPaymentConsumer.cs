
using DevFreela.Payments.API.Models;
using DevFreela.Payments.API.Services;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace DevFreela.Payments.API.Consumers;

public class ProcessPaymentConsumer : BackgroundService
{
    private const string QUEUE = "Patments";
    private readonly IConnection _connection;
    private readonly IModel _chanel;
    private readonly IServiceProvider _serviceProvider;

    public ProcessPaymentConsumer(IServiceProvider serviceProvider)
    {
       _serviceProvider = serviceProvider;
        var factory = new ConnectionFactory
        {
            HostName = "localhost",

        };
        _connection = factory.CreateConnection();
        _chanel = _connection.CreateModel();

        _chanel.QueueDeclare(
            queue: QUEUE,
            durable: false,
            exclusive: false,
            autoDelete: false,
            arguments: null);
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var consumer = new EventingBasicConsumer(_chanel);
        consumer.Received += (sender, eventsArgs) =>
        {
            var byteArray = eventsArgs.Body.ToArray();
            var paymentInfoJson = Encoding.UTF8.GetString(byteArray);
            var paymentInfo = JsonSerializer.Deserialize<PaymentInfoInputModel>(paymentInfoJson);

            ProcessPayment(paymentInfo);
            _chanel.BasicAck(eventsArgs.DeliveryTag, false);
        };
        _chanel.BasicConsume(QUEUE, false, consumer);
        return Task.CompletedTask;
    }

    private void ProcessPayment(PaymentInfoInputModel paymentInfo)
    {
        using(var scop = _serviceProvider.CreateScope()) 
        {
            var paymentService = scop.ServiceProvider.GetRequiredService<IPaymentService>();
            paymentService.Process(paymentInfo);
        }
    }
}
