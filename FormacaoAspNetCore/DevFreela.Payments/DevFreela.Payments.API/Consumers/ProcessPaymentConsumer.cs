
using DevFreela.Payments.API.Models;
using DevFreela.Payments.API.Services;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace DevFreela.Payments.API.Consumers;

public class ProcessPaymentConsumer : BackgroundService
{
    private const string QUEUE = "Payments";
    private const string PAYMENTS_APPROVED_QUEUE = "PaymentsApproved";

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

        _chanel.QueueDeclare(
           queue: PAYMENTS_APPROVED_QUEUE,
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

            var paymentApproved = new PaymentApprovedIntegrationEvent(paymentInfo.IdProject);
            var paymenyApprovedJson = JsonSerializer.Serialize(paymentApproved);
            var paymentApprovedBytes = Encoding.UTF8.GetBytes(paymenyApprovedJson);
            _chanel.BasicPublish(
                exchange: "",
                routingKey: PAYMENTS_APPROVED_QUEUE,
                basicProperties: null,
                body: paymentApprovedBytes);

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
