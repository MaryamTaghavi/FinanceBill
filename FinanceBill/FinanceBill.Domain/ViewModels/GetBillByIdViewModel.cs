namespace FinanceBill.Domain.ViewModels;

public record GetBillByIdViewModel
(
    int Id,
    string Name,
    string? Description,
    double Price
);