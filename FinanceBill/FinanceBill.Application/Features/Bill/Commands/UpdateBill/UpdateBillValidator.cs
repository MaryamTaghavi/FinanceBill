using FinanceBill.Application.Features.Bill.Commands.UpdateBill;
using FluentValidation;

namespace CarInquiry.Application.Features.BaseInfo.Commands.CreateCardDocumentVehicleStatus; 

public class UpdateBillValidator : AbstractValidator<UpdateBillCommand>
{
    public UpdateBillValidator()
    {
        RuleFor(s => s.viewModel.Name)
            .NotEmpty().WithMessage("عنوان را وارد کنید")
            .MaximumLength(20).WithMessage("عنوان باید حداکثر 20 کاراکتر باشد");

        RuleFor(s => s.viewModel.Price)
            .GreaterThan(0).WithMessage("قیمت را وارد کنید");

        RuleFor(s => s.viewModel.Id)
            .GreaterThan(0).WithMessage("شناسه را وارد کنید");
    }
}
