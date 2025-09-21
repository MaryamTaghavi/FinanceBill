using FinanceBill.Domain.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceBill.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BillController : ControllerBase
{
    private readonly IMediator _sender;

    /// <summary>
    /// صورت حساب
    /// </summary>
    /// <param name="sender"></param>
    public BillController(IMediator sender)
    {
        _sender = sender;
    }

    /// <summary>
    /// دریافت صورت حساب
    /// </summary>
    /// <returns></returns>
    [HttpGet("id:int")]
    [ProducesResponseType(typeof(GetBillByIdViewModel), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetById(CancellationToken cancellationToken)
    {
        var result = await _sender.Send(new GetNewsCategoriesQuery(), cancellationToken);
        return Ok(result);
    }

}
