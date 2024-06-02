namespace DevFreela.Core.DTOs;

public class PaymentInfoDTO
{
    public PaymentInfoDTO(int id, string creditCardNumber, string cvv, DateTime expiresAt, string fullName)
    {
        IdProject = id;
        CreditCardNumber = creditCardNumber;
        Cvv = cvv;
        ExpiresAt = expiresAt;
        FullName = fullName;
    }

    public int IdProject { get; set; }
    public string CreditCardNumber { get; set; }
    public string Cvv { get; set; }
    public DateTime ExpiresAt { get; set; }
    public string FullName { get; set; }
}
