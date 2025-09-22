using FinanceBill.Application.Interfaces;
using FinanceBill.Domain.ViewModels;
using MediatR;

namespace FinanceBill.Application.Features.Bill.Queries.GetById;

public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, GetBillByIdViewModel>
{
    private readonly IBillService _billService;

    public GetByIdQueryHandler(IBillService billService) => _billService = billService;

    public async Task<GetBillByIdViewModel?> Handle(GetByIdQuery query, CancellationToken cancellationToken)
    {
        return await _billService.GetByIdAsync(query.Id , cancellationToken);
    }
}
