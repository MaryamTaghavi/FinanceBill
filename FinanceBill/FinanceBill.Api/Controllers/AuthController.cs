using FinanceBill.Application.Features.Auth.Queries.LoginWithPassword;
using FinanceBill.Domain.ViewModels;
using MediatR;
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
    private readonly IMediator _sender;

    public AuthController(IMediator sender) => _sender = sender;

    /// <summary>
    /// لاگین با پسورد
    /// </summary>
    /// <remarks>
    /// User : Test ***
    /// Password : 123
    /// </remarks>
    /// <param name="Name"></param>
    /// <param name="Password"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost("LoginWithPassword")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(LoginViewModel), StatusCodes.Status200OK)]

    public async Task<IActionResult> LoginWithPassword(string Name , string Password, CancellationToken cancellationToken)
    {
        var result = await _sender.Send(new LoginWithPasswordQuery(Name , Password), cancellationToken);
        return Ok(result);
    }
}
