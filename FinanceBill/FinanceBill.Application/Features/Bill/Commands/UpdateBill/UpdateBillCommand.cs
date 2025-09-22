using FinanceBill.Domain.ViewModels;
using MediatR;

namespace FinanceBill.Application.Features.Bill.Commands.UpdateBill;

public record UpdateBillCommand(UpdateBillViewModel viewModel) : IRequest<bool>;