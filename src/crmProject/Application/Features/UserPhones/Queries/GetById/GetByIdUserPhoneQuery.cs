using Application.Features.UserPhones.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.UserPhones.Queries.GetById;

public class GetByIdUserPhoneQuery : IRequest<GetByIdUserPhoneResponse>
{
    public int Id { get; set; }

    public class GetByIdUserPhoneQueryHandler : IRequestHandler<GetByIdUserPhoneQuery, GetByIdUserPhoneResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserPhoneRepository _userPhoneRepository;
        private readonly UserPhoneBusinessRules _userPhoneBusinessRules;

        public GetByIdUserPhoneQueryHandler(IMapper mapper, IUserPhoneRepository userPhoneRepository, UserPhoneBusinessRules userPhoneBusinessRules)
        {
            _mapper = mapper;
            _userPhoneRepository = userPhoneRepository;
            _userPhoneBusinessRules = userPhoneBusinessRules;
        }

        public async Task<GetByIdUserPhoneResponse> Handle(GetByIdUserPhoneQuery request, CancellationToken cancellationToken)
        {
            UserPhone? userPhone = await _userPhoneRepository.GetAsync(predicate: up => up.Id == request.Id, cancellationToken: cancellationToken);
            await _userPhoneBusinessRules.UserPhoneShouldExistWhenSelected(userPhone);

            GetByIdUserPhoneResponse response = _mapper.Map<GetByIdUserPhoneResponse>(userPhone);
            return response;
        }
    }
}