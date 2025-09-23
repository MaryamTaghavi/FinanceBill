using System.Text.Json.Serialization;

namespace FinanceBill.Domain.ViewModels;

public record LoginRequest
(
    [property: JsonPropertyName("userName")] string UserName = "Test",
    [property: JsonPropertyName("password")] string Password = "123"
);
