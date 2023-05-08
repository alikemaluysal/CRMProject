using Application.Features.OfferStatus.Commands.Create;
using Application.Features.OfferStatus.Commands.Delete;
using Application.Features.OfferStatus.Commands.Update;
using Application.Features.OfferStatus.Queries.GetById;
using Application.Features.OfferStatus.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.OfferStatus.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<OfferStatus, CreateOfferStatusCommand>().ReverseMap();
        CreateMap<OfferStatus, CreatedOfferStatusResponse>().ReverseMap();
        CreateMap<OfferStatus, UpdateOfferStatusCommand>().ReverseMap();
        CreateMap<OfferStatus, UpdatedOfferStatusResponse>().ReverseMap();
        CreateMap<OfferStatus, DeleteOfferStatusCommand>().ReverseMap();
        CreateMap<OfferStatus, DeletedOfferStatusResponse>().ReverseMap();
        CreateMap<OfferStatus, GetByIdOfferStatusResponse>().ReverseMap();
        CreateMap<OfferStatus, GetListOfferStatusListItemDto>().ReverseMap();
        CreateMap<IPaginate<OfferStatus>, GetListResponse<GetListOfferStatusListItemDto>>().ReverseMap();
    }
}