using FinanceBill.Domain.ViewModels;

namespace FinanceBill.Application.Interfaces;

public interface IBillService
{
    Task<bool> AddAsync(CreateBillViewModel viewModel, CancellationToken cancellationToken);
    Task<bool> UpdateAsync(UpdateBillViewModel viewModel, CancellationToken cancellationToken);
    Task<bool> DeleteAsync(int id, CancellationToken cancellationToken);
    Task<GetBillByIdViewModel?> GetByIdAsync(int id, CancellationToken cancellationToken);
}
