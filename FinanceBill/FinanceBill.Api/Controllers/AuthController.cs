using FinanceBill.Application.Interfaces;
using FinanceBill.Domain.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SecureUserManagement.Controllers;

/// <summary>
/// Auth Controller
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private IAuthService _authService;

    public AuthController(IAuthService authService) => _authService = authService;

    /// <summary>
    /// لاگین با پسورد
    /// User : Test
    /// Password : 123
    /// </summary>
    /// <param name="login"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost("LoginWithPassword")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(LoginViewModel), StatusCodes.Status200OK)]

    public async Task<IActionResult> LoginWithPassword([FromBody] LoginRequest login, CancellationToken cancellationToken)
    {
        var result = await _authService.LoginWithPasswordAsync(login, cancellationToken);
        return Ok(result);
    }
}
