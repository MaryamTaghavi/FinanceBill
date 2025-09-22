using MediatR;

namespace FinanceBill.Application.Features.Bill.Commands.DeleteBill;

public record DeleteBillCommand(int Id) : IRequest<bool>;