using Application.Features.UserStatuses.Commands.Create;
using Application.Features.UserStatuses.Commands.Delete;
using Application.Features.UserStatuses.Commands.Update;
using Application.Features.UserStatuses.Queries.GetById;
using Application.Features.UserStatuses.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserStatusController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateUserStatusCommand createUserStatusCommand)
    {
        CreatedUserStatusResponse response = await Mediator.Send(createUserStatusCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateUserStatusCommand updateUserStatusCommand)
    {
        UpdatedUserStatusResponse response = await Mediator.Send(updateUserStatusCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedUserStatusResponse response = await Mediator.Send(new DeleteUserStatusCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdUserStatusResponse response = await Mediator.Send(new GetByIdUserStatusQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListUserStatusQuery getListUserStatusQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListUserStatusListItemDto> response = await Mediator.Send(getListUserStatusQuery);
        return Ok(response);
    }
}