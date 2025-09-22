using FluentValidation;

namespace FinanceBill.Application.Features.Bill.Commands.DeleteBill;

public class DeleteBillValidator : AbstractValidator<DeleteBillCommand>
{
    public DeleteBillValidator()
    {
        RuleFor(s => s.Id)
           .GreaterThan(0).WithMessage("شناسه را وارد کنید");
    }
}