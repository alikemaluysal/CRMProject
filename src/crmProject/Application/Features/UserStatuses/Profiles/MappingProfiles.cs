using Application.Features.UserStatuses.Commands.Create;
using Application.Features.UserStatuses.Commands.Delete;
using Application.Features.UserStatuses.Commands.Update;
using Application.Features.UserStatuses.Queries.GetById;
using Application.Features.UserStatuses.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.UserStatuses.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<UserStatus, CreateUserStatusCommand>().ReverseMap();
        CreateMap<UserStatus, CreatedUserStatusResponse>().ReverseMap();
        CreateMap<UserStatus, UpdateUserStatusCommand>().ReverseMap();
        CreateMap<UserStatus, UpdatedUserStatusResponse>().ReverseMap();
        CreateMap<UserStatus, DeleteUserStatusCommand>().ReverseMap();
        CreateMap<UserStatus, DeletedUserStatusResponse>().ReverseMap();
        CreateMap<UserStatus, GetByIdUserStatusResponse>().ReverseMap();
        CreateMap<UserStatus, GetListUserStatusListItemDto>().ReverseMap();
        CreateMap<IPaginate<UserStatus>, GetListResponse<GetListUserStatusListItemDto>>().ReverseMap();
    }
}