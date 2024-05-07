using DevFreela.Payments.API.Models;
using DevFreela.Payments.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.Payments.API.Controllers;

[ApiController]
[Route("api/payments")]
public class PaymentsController : ControllerBase
{
    private readonly IPaymentService _servicePayment;

    public PaymentsController(IPaymentService servicePayment)
    {
        _servicePayment = servicePayment;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] PaymentInfoInputModel paymentInfo)
    {
        var result = await _servicePayment.Process(paymentInfo);

        if(!result)
        {
            BadRequest();
        }

        return NoContent();
    }
}
