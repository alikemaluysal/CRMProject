using Application.Features.UserEmails.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Domain.Enums;

namespace Application.Features.UserEmails.Commands.Create;

public class CreateUserEmailCommand : IRequest<CreatedUserEmailResponse>
{
    public int? UserId { get; set; }
    public string? EmailAddress { get; set; }
    public EmailTypeEnum EmailType { get; set; }

    public class CreateUserEmailCommandHandler : IRequestHandler<CreateUserEmailCommand, CreatedUserEmailResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserEmailRepository _userEmailRepository;
        private readonly UserEmailBusinessRules _userEmailBusinessRules;

        public CreateUserEmailCommandHandler(IMapper mapper, IUserEmailRepository userEmailRepository,
                                         UserEmailBusinessRules userEmailBusinessRules)
        {
            _mapper = mapper;
            _userEmailRepository = userEmailRepository;
            _userEmailBusinessRules = userEmailBusinessRules;
        }

        public async Task<CreatedUserEmailResponse> Handle(CreateUserEmailCommand request, CancellationToken cancellationToken)
        {
            UserEmail userEmail = _mapper.Map<UserEmail>(request);

            await _userEmailRepository.AddAsync(userEmail);

            CreatedUserEmailResponse response = _mapper.Map<CreatedUserEmailResponse>(userEmail);
            return response;
        }
    }
}