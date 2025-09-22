namespace FinanceBill.Domain.ViewModels;

public record CreateBillViewModel
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public double Price { get; set; }
}
