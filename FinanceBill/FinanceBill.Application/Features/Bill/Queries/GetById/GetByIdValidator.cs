using FluentValidation;

namespace FinanceBill.Application.Features.Bill.Queries.GetById;

public class GetByIdValidator : AbstractValidator<GetByIdQuery>
{
    public GetByIdValidator()
    {
        RuleFor(s => s.Id)
            .GreaterThan(0).WithMessage("شناسه را وارد کنید");
    }
}