using FinanceBill.Application.Interfaces;
using MediatR;

namespace FinanceBill.Application.Features.Bill.Commands.DeleteBill;

public class DeleteBillCommandHandler : IRequestHandler<DeleteBillCommand, bool>
{
    private readonly IBillService _billService;

    public DeleteBillCommandHandler(IBillService billService) => _billService = billService;

    public async Task<bool> Handle(DeleteBillCommand command, CancellationToken cancellationToken)
    {
        return await _billService.DeleteAsync(command.Id, cancellationToken);
    }
}