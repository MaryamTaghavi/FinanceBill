using FinanceBill.Application.Interfaces;
using FinanceBill.Domain.Entities;
using FinanceBill.Domain.ViewModels;

namespace FinanceBill.Infrastructure.Services;

public class BillService : IBillService
{
    private readonly AppDbContext _context;

    public BillService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> AddAsync(Bill bill , CancellationToken cancellationToken)
    {
        try
        {
            await _context.Bills.AddAsync(bill, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }

        catch
        {
            return false;
        }
    }

    public Task<bool> DeleteAsync()
    {
        throw new NotImplementedException();
    }

    public Task<GetBillByIdViewModel> GetByIdAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<bool> UpdateAsync(Bill bill, CancellationToken cancellationToken)
    {
        try
        {
            _context.Bills.Update(bill);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }

        catch
        {
            return false;
        }
    }
}
