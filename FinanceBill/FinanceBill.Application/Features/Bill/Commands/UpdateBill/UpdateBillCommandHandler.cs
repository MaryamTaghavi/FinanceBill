using FinanceBill.Application.Interfaces;
using MediatR;

namespace FinanceBill.Application.Features.Bill.Commands.UpdateBill;

internal class UpdateBillCommandHandler : IRequestHandler<UpdateBillCommand, bool>
{
    private readonly IBillService _billService;

    public UpdateBillCommandHandler(IBillService billService) => _billService = billService;

    public async Task<bool> Handle(UpdateBillCommand command, CancellationToken cancellationToken)
    {
        return await _billService.UpdateAsync(command.viewModel, cancellationToken);
    }
}
