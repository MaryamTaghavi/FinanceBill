using FinanceBill.Domain.Entities;
using FinanceBill.Domain.ViewModels;

namespace FinanceBill.Application.Mappers;

public static class BillMappers
{
    private static Bill ToAddBill(this CreateBillViewModel viewModel)
    {
        return new Bill()
        {
            CreatedAt = DateTime.Now,
            Description = viewModel.Description,
            Name = viewModel.Name,
            Price = viewModel.Price,
        };
    }

    private static Bill ToUpdateBill(this UpdateBillViewModel viewModel, Bill bill)
    {
        bill.UpdatedAt = DateTime.Now;
        bill.Description = viewModel.Description;
        bill.Name = viewModel.Name;
        bill.Price = viewModel.Price;

        return bill;
    }

    private static GetBillByIdViewModel ToGetById(this Bill bill) =>
         new(
             bill.Id,
             bill.Name,
             bill.Description,
             bill.Price);
}
