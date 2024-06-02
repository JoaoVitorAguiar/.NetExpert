using DevFreela.Core.IntegrationEvents;
using DevFreela.Core.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace DevFreela.Application.Consumers;

public class PaymentApprovedConsumer : BackgroundService
{
    private const string PAYMENTS_APPROVED_QUEUE = "PaymentsApproved";

    private readonly IConnection _connection;
    private readonly IModel _chanel;
    private readonly IServiceProvider _serviceProvider;

    public PaymentApprovedConsumer(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;

        var factory = new ConnectionFactory
        {
            HostName = "localhost",
        };

        _connection = factory.CreateConnection();
        _chanel = _connection.CreateModel();

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
        consumer.Received += async (sender, eventsArgs) =>
        {
            var paymentApprovedBytes = eventsArgs.Body.ToArray();
            var paymentApprovedJson = Encoding.UTF8.GetString(paymentApprovedBytes);
            var paymentApprovedIntegrationEvent = JsonSerializer.Deserialize<PaymentApprovedIntegrationEvent>(paymentApprovedJson);

            await FinishProject(paymentApprovedIntegrationEvent.IdProject);

            _chanel.BasicAck(eventsArgs.DeliveryTag, false);
        };
        _chanel.BasicConsume(PAYMENTS_APPROVED_QUEUE, false, consumer);
        return Task.CompletedTask;
    }

    private async Task FinishProject(int id)
    {
        using (var scop = _serviceProvider.CreateScope())
        {
            var projectRepository = scop.ServiceProvider.GetRequiredService<IProjectRepository>();
            var project = await projectRepository.GetByIdAsync(id);
            if (project != null)
            {
                project.Finish();
                await projectRepository.SaveChangesAsync(project);
            }
        }
    }
}
