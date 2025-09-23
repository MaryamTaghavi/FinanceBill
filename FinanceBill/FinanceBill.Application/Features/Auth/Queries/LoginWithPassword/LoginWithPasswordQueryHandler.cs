using FinanceBill.Application.Interfaces;
using FinanceBill.Domain.ViewModels;
using MediatR;

namespace FinanceBill.Application.Features.Auth.Queries.LoginWithPassword;

internal class LoginWithPasswordQueryHandler : IRequestHandler<LoginWithPasswordQuery, LoginViewModel>
{
    private readonly IAuthService _authService;

    public LoginWithPasswordQueryHandler(IAuthService authService) => _authService = authService;

    public async Task<LoginViewModel> Handle(LoginWithPasswordQuery query, CancellationToken cancellationToken)
    {
        return await _authService.LoginWithPasswordAsync(query.Name , query.Password, cancellationToken);
    }
}