using FinanceBill.Domain.ViewModels;
using MediatR;

namespace FinanceBill.Application.Features.Auth.Queries.LoginWithPassword;

public record LoginWithPasswordQuery(string Name = "Test" , string Password = "123") : IRequest<LoginViewModel>;