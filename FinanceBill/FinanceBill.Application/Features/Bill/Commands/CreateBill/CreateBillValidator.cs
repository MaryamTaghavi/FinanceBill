using FinanceBill.Application.Features.Bill.Commands.CreateBill;
using FluentValidation;

namespace CarInquiry.Application.Features.BaseInfo.Commands.CreateCardDocumentVehicleStatus; 

public class CreateBillValidator : AbstractValidator<CreateBillCommand>
{
    public CreateBillValidator()
    {
        RuleFor(s => s.viewModel.Name)
            .NotEmpty().WithMessage("عنوان را وارد کنید")
            .MaximumLength(20).WithMessage("عنوان باید حداکثر 20 کاراکتر باشد");

        RuleFor(s => s.viewModel.Price)
           .GreaterThan(0).WithMessage("قیمت را وارد کنید");
    }
}
