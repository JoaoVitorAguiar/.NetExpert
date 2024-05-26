using DevFreela.Core.DTOs;
using DevFreela.Core.Services;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DevFreela.Infrastructure.Payments;

public class PaymentService : IPaymentService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly string _paymentBaseURl;

    public PaymentService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
    {
        _httpClientFactory = httpClientFactory;
        _paymentBaseURl = configuration.GetSection("Services:Payments").Value;
    }
    public async Task<bool> ProcessPayment(PaymentInfoDTO patmentInfoDTO)
    {
        try
        {
            var url = $"{_paymentBaseURl}/api/payments";
            var paymentInfoJson = JsonSerializer.Serialize(patmentInfoDTO);
            var paymentInfoContent = new StringContent(
                paymentInfoJson,
                Encoding.UTF8,
                "application/json"
            );

            var httpClient = _httpClientFactory.CreateClient("Payments");
            var response = await httpClient.PostAsync(url, paymentInfoContent);

            return response.IsSuccessStatusCode;
        }
        catch (Exception ex)
        {
            // Registrar ou tratar a exceção aqui
            // Isso pode incluir logs, notificações ou retornar false para indicar falha no processamento do pagamento
            Console.WriteLine($"Erro ao processar pagamento: {ex.Message}");
            return false;
        }
    }
}
