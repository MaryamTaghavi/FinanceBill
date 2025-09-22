using FinanceBill.Application.Interfaces;
using MediatR;

namespace FinanceBill.Application.Features.Bill.Commands.CreateBill;

public class CreateBillCommandHandler : IRequestHandler<CreateBillCommand, bool>
{
    private readonly IBillService _billService;

    public CreateBillCommandHandler(IBillService billService) => _billService = billService;

    public async Task<bool> Handle(CreateBillCommand command, CancellationToken cancellationToken)
    {
        return await _billService.AddAsync(command.viewModel, cancellationToken);
    }
}