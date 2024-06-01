using DevFreela.Core.DTOs;
using DevFreela.Core.Repositories;
using DevFreela.Core.Services;
using MediatR;

namespace DevFreela.Application.Commands.Project.FnishProject;

public class FinishProjectHandler : IRequestHandler<FinishProjectCommand, Unit>
{
    private readonly IProjectRepository _projectRepository;
    private readonly IPaymentService _paymentService;

    public FinishProjectHandler(IProjectRepository projectRepository, IPaymentService paymentService)
    {
        _projectRepository = projectRepository;
        _paymentService = paymentService;
    }


    public async Task<Unit> Handle(FinishProjectCommand request, CancellationToken cancellationToken)
    {
        var project = await _projectRepository.GetByIdAsync(request.Id);

        var paymentInfoDTO = new PaymentInfoDTO(request.Id, request.CreditCardNumber, request.Cvv, request.ExpiresAt, request.FullName);
        _paymentService.ProcessPayment(paymentInfoDTO);


        project.SetPaymentPending();

        await _projectRepository.SaveChangesAsync(project);

        return Unit.Value;
    }

}

