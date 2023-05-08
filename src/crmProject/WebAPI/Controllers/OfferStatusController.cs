using Application.Features.OfferStatus.Commands.Create;
using Application.Features.OfferStatus.Commands.Delete;
using Application.Features.OfferStatus.Commands.Update;
using Application.Features.OfferStatus.Queries.GetById;
using Application.Features.OfferStatus.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OfferStatusController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateOfferStatusCommand createOfferStatusCommand)
    {
        CreatedOfferStatusResponse response = await Mediator.Send(createOfferStatusCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateOfferStatusCommand updateOfferStatusCommand)
    {
        UpdatedOfferStatusResponse response = await Mediator.Send(updateOfferStatusCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedOfferStatusResponse response = await Mediator.Send(new DeleteOfferStatusCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdOfferStatusResponse response = await Mediator.Send(new GetByIdOfferStatusQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListOfferStatusQuery getListOfferStatusQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListOfferStatusListItemDto> response = await Mediator.Send(getListOfferStatusQuery);
        return Ok(response);
    }
}