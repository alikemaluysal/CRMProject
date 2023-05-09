using Application.Features.StatusTypes.Commands.Create;
using Application.Features.StatusTypes.Commands.Delete;
using Application.Features.StatusTypes.Commands.Update;
using Application.Features.StatusTypes.Queries.GetById;
using Application.Features.StatusTypes.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StatusTypesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateStatusTypeCommand createStatusTypeCommand)
    {
        CreatedStatusTypeResponse response = await Mediator.Send(createStatusTypeCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateStatusTypeCommand updateStatusTypeCommand)
    {
        UpdatedStatusTypeResponse response = await Mediator.Send(updateStatusTypeCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedStatusTypeResponse response = await Mediator.Send(new DeleteStatusTypeCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdStatusTypeResponse response = await Mediator.Send(new GetByIdStatusTypeQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListStatusTypeQuery getListStatusTypeQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListStatusTypeListItemDto> response = await Mediator.Send(getListStatusTypeQuery);
        return Ok(response);
    }
}