using FinanceBill.Domain.ViewModels;
using MediatR;

namespace FinanceBill.Application.Features.Bill.Commands.CreateBill;

public record CreateBillCommand(CreateBillViewModel viewModel) : IRequest<bool>;