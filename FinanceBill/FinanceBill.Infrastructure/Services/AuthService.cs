using FinanceBill.Domain.Entities;
using FinanceBill.Domain.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using FinanceBill.Application.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FinanceBill.Infrastructure.Services;

public class AuthService : IAuthService
{
    private readonly AppDbContext _context;
    private readonly IConfiguration _configuration;
    private readonly ILogger<BillService> _logger;

    public AuthService(AppDbContext context, IConfiguration configuration, ILogger<BillService> logger)
    {
        _context = context;
        _configuration = configuration;
        _logger = logger;
    }

    public async Task<LoginViewModel?> LoginWithPasswordAsync(string Name, string Password, CancellationToken cancellationToken)
    {
        //var user = await _context.Users.FirstOrDefaultAsync(r => r.Name == login.UserName && r.Password == login.Password, cancellationToken);

        //if (user == null)
        //{
        //    _logger.LogError("User is null");
        //    return null;
        //}

        var response = GenerateToken();

        return new LoginViewModel(response);
    }

    public string GenerateToken(User user = null)
    {
        var claims = new[]
        {
            //new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            //new Claim(ClaimTypes.Name, user.Name),
            new Claim(ClaimTypes.NameIdentifier, 1.ToString()),
            new Claim(ClaimTypes.Name, "Test"),
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:SecretKey"]!));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddHours(2),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
