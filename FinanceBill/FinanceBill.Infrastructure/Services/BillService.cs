using FinanceBill.Application.Interfaces;
using FinanceBill.Application.Mappers;
using FinanceBill.Domain.ViewModels;
using Microsoft.EntityFrameworkCore;
using Serilog;

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

        catch(Exception ex)
        {
            Log.Error(ex, "An unexpected error occurred");
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
            Log.Error("{id} is null" , id);
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
            Log.Error("{id} is null", id);
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
            Log.Error("{@bill} is null" , viewModel);
            return false;
        }
    }
}
