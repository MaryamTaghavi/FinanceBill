using FinanceBill.Application.Interfaces;
using FinanceBill.Application.Mappers;
using FinanceBill.Domain.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace FinanceBill.Infrastructure.Services;

public class BillService : IBillService
{
    private readonly AppDbContext _context;

    public BillService(AppDbContext context) => _context = context;

    public async Task<bool> AddAsync(CreateBillViewModel viewModel, CancellationToken cancellationToken)
    {
        try
        {
            var result = viewModel.ToAddBill();

            await _context.Bills.AddAsync(result, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }

        catch
        {
            return false;
        }
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken)
    {
        var bill = await _context.Bills.AsNoTracking().SingleOrDefaultAsync(r => r.Id == id, cancellationToken);

        if (bill != null)
        {
            _context.Bills.Remove(bill);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }

        else
        {
            return false;
        }

    }

    public async Task<GetBillByIdViewModel?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        var bill = await _context.Bills.AsNoTracking().SingleOrDefaultAsync(r => r.Id == id, cancellationToken);

        if (bill != null)
        {
            return bill.ToGetById();
        }

        else
        {
            return null;
        }
    }

    public async Task<bool> UpdateAsync(UpdateBillViewModel viewModel, CancellationToken cancellationToken)
    {
        var bill = await _context.Bills.AsNoTracking().SingleOrDefaultAsync(r => r.Id == viewModel.Id, cancellationToken);

        if (bill != null)
        {
            var result = viewModel.ToUpdateBill(bill);

            _context.Bills.Update(result);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
        else
        {
            return false;
        }
    }
}
