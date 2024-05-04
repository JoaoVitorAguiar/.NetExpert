using DevFreela.Core.DTOs;
using DevFreela.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Infrastructure.Payments;

public class PaymentService : IPaymentService
{
    public Task<bool> ProcessPayment(PaymentInfoDTO patmentInfoDTO)
    {
        // Implementar lógica de pagamento Getway do pagamento  
        return Task.FromResult(true);
    }
}
