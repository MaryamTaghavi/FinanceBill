using MediatR;

namespace FinanceBill.Application.Features.Bill.Commands.DeleteBill;

public class DeleteBillCommand(int id) : IRequest<bool>;