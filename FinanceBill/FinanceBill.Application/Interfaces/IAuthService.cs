using FinanceBill.Domain.ViewModels;

namespace FinanceBill.Application.Interfaces;

public interface IAuthService
{
    Task<LoginViewModel?> LoginWithPasswordAsync(LoginRequest login , CancellationToken cancellationToken);
}
