using FinanceBill.Domain.ViewModels;
using MediatR;

namespace FinanceBill.Application.Features.Bill.Queries.GetById;

public record GetByIdQuery(int Id) : IRequest<GetBillByIdViewModel>;