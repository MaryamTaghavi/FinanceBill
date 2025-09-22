using FinanceBill.Application.Features.Bill.Commands.CreateBill;
using FinanceBill.Application.Features.Bill.Commands.DeleteBill;
using FinanceBill.Application.Features.Bill.Commands.UpdateBill;
using FinanceBill.Application.Features.Bill.Queries.GetById;
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
    public BillController(IMediator sender) => _sender = sender;

    /// <summary>
    /// درج صورت حساب
    /// </summary>
    /// <param name="viewModel"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
    public async Task<IActionResult> Create(CreateBillViewModel viewModel, CancellationToken cancellationToken)
    {
        var result = await _sender.Send(new CreateBillCommand(viewModel), cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// دریافت صورت حساب
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("id:int")]
    [ProducesResponseType(typeof(GetBillByIdViewModel), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
    {
        var result = await _sender.Send(new GetByIdQuery(id), cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// ویرایش صورت حساب
    /// </summary>
    /// <param name="viewModel"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPut]
    [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
    public async Task<IActionResult> Update(UpdateBillViewModel viewModel, CancellationToken cancellationToken)
    {
        var result = await _sender.Send(new UpdateBillCommand(viewModel), cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// حذف صورت حساب
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpDelete]
    [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        var result = await _sender.Send(new DeleteBillCommand(id), cancellationToken);
        return Ok(result);
    }
}
