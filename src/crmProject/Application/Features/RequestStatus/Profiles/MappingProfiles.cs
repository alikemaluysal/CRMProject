using Application.Features.RequestStatus.Commands.Create;
using Application.Features.RequestStatus.Commands.Delete;
using Application.Features.RequestStatus.Commands.Update;
using Application.Features.RequestStatus.Queries.GetById;
using Application.Features.RequestStatus.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.RequestStatus.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<RequestStatus, CreateRequestStatusCommand>().ReverseMap();
        CreateMap<RequestStatus, CreatedRequestStatusResponse>().ReverseMap();
        CreateMap<RequestStatus, UpdateRequestStatusCommand>().ReverseMap();
        CreateMap<RequestStatus, UpdatedRequestStatusResponse>().ReverseMap();
        CreateMap<RequestStatus, DeleteRequestStatusCommand>().ReverseMap();
        CreateMap<RequestStatus, DeletedRequestStatusResponse>().ReverseMap();
        CreateMap<RequestStatus, GetByIdRequestStatusResponse>().ReverseMap();
        CreateMap<RequestStatus, GetListRequestStatusListItemDto>().ReverseMap();
        CreateMap<IPaginate<RequestStatus>, GetListResponse<GetListRequestStatusListItemDto>>().ReverseMap();
    }
}