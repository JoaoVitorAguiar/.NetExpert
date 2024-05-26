using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Core.DTOs;

public class PaymentInfoDTO
{
    public PaymentInfoDTO(int id, string creditCardNumber, string cvv, DateTime expiresAt, string fullName)
    {
        Id = id;
        CreditCardNumber = creditCardNumber;
        Cvv = cvv;
        ExpiresAt = expiresAt;
        FullName = fullName;
    }

    public int Id { get; set; }
    public string CreditCardNumber { get; set; }
    public string Cvv { get; set; }
    public DateTime ExpiresAt { get; set; }
    public string FullName { get; set; }
}
