using FinanceBill.Application.Interfaces;
using FinanceBill.Application.Mappers;
using FinanceBill.Domain.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Serilog;

namespace FinanceBill.Infrastructure.Services;

public class BillService : IBillService
{
    private readonly AppDbContext _context;
    private readonly ILogger<BillService> _logger;

    public BillService(AppDbContext context , ILogger<BillService> logger)
    {
        _context = context;
        _logger = logger;
    }

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
            _logger.LogError(ex, "An unexpected error occurred");
            //Log.Error(ex, "An unexpected error occurred");
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
            //Log.Error("{id} is null" , id);
            _logger.LogError("{id} is null", id);
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
           // Log.Error("{id} is null", id);
           // از طریق ILogger, coupled با serilog از بین میرود.
            _logger.LogError("{id} is null", id);
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
            _logger.LogError("{@bill} is null", viewModel);
            //Log.Error("{@bill} is null" , viewModel);
            return false;
        }
    }
}
