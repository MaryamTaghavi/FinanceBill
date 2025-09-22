using FluentValidation;

namespace FinanceBill.Application.Features.Bill.Commands.CreateBill;

public class CreateBillValidator : AbstractValidator<CreateBillCommand>
{
    public CreateBillValidator()
    {
        RuleFor(s => s.viewModel.Name)
            .NotEmpty().WithMessage("عنوان را وارد کنید")
            .MaximumLength(20).WithMessage("عنوان باید حداکثر 20 کاراکتر باشد");

        RuleFor(s => s.viewModel.Price)
           .GreaterThan(0).LessThan(100000000).WithMessage("قیمت را وارد کنید");
    }
}
