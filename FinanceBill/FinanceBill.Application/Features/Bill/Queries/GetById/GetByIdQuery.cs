using FinanceBill.Domain.ViewModels;
using MediatR;

namespace FinanceBill.Application.Features.Bill.Queries.GetById;

public class GetByIdQuery : IRequest<GetBillByIdViewModel>
{
}
