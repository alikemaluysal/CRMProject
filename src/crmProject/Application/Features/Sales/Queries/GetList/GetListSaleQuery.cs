using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.Sales.Queries.GetList;

public class GetListSaleQuery : IRequest<GetListResponse<GetListSaleListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListSaleQueryHandler : IRequestHandler<GetListSaleQuery, GetListResponse<GetListSaleListItemDto>>
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IMapper _mapper;

        public GetListSaleQueryHandler(ISaleRepository saleRepository, IMapper mapper)
        {
            _saleRepository = saleRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListSaleListItemDto>> Handle(GetListSaleQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Sale> sales = await _saleRepository.GetListAsync(
                index: request.PageRequest.Page,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListSaleListItemDto> response = _mapper.Map<GetListResponse<GetListSaleListItemDto>>(sales);
            return response;
        }
    }
}