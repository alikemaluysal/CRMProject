using Application.Features.UserEmails.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.UserEmails.Queries.GetById;

public class GetByIdUserEmailQuery : IRequest<GetByIdUserEmailResponse>
{
    public int Id { get; set; }

    public class GetByIdUserEmailQueryHandler : IRequestHandler<GetByIdUserEmailQuery, GetByIdUserEmailResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserEmailRepository _userEmailRepository;
        private readonly UserEmailBusinessRules _userEmailBusinessRules;

        public GetByIdUserEmailQueryHandler(IMapper mapper, IUserEmailRepository userEmailRepository, UserEmailBusinessRules userEmailBusinessRules)
        {
            _mapper = mapper;
            _userEmailRepository = userEmailRepository;
            _userEmailBusinessRules = userEmailBusinessRules;
        }

        public async Task<GetByIdUserEmailResponse> Handle(GetByIdUserEmailQuery request, CancellationToken cancellationToken)
        {
            UserEmail? userEmail = await _userEmailRepository.GetAsync(predicate: ue => ue.Id == request.Id, cancellationToken: cancellationToken);
            await _userEmailBusinessRules.UserEmailShouldExistWhenSelected(userEmail);

            GetByIdUserEmailResponse response = _mapper.Map<GetByIdUserEmailResponse>(userEmail);
            return response;
        }
    }
}