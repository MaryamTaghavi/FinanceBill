using FinanceBill.Application.Interfaces;
using FinanceBill.Domain.Entities;
using FinanceBill.Domain.ViewModels;
using Microsoft.EntityFrameworkCore;
using FinanceBill.Application.Mappers;

namespace FinanceBill.Infrastructure.Services;

public class BillService : IBillService
{
    private readonly AppDbContext _context;

    public BillService(AppDbContext context) => _context = context;

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
