using FinanceBill.Domain.Entities;
using FinanceBill.Domain.ViewModels;

namespace FinanceBill.Application.Interfaces;

public interface IBillService
{
    Task<bool> AddAsync(Bill bill, CancellationToken cancellationToken);
    Task<bool> UpdateAsync(Bill bill, CancellationToken cancellationToken);
    Task<bool> DeleteAsync(int id, CancellationToken cancellationToken);
    Task<GetBillByIdViewModel?> GetByIdAsync(int id, CancellationToken cancellationToken);
}
