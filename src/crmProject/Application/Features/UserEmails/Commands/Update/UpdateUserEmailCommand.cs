using Application.Features.UserEmails.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Domain.Enums;

namespace Application.Features.UserEmails.Commands.Update;

public class UpdateUserEmailCommand : IRequest<UpdatedUserEmailResponse>
{
    public Guid Id { get; set; }
    public int? UserId { get; set; }
    public string? EmailAddress { get; set; }
    public EmailTypeEnum EmailType { get; set; }

    public class UpdateUserEmailCommandHandler : IRequestHandler<UpdateUserEmailCommand, UpdatedUserEmailResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserEmailRepository _userEmailRepository;
        private readonly UserEmailBusinessRules _userEmailBusinessRules;

        public UpdateUserEmailCommandHandler(IMapper mapper, IUserEmailRepository userEmailRepository,
                                         UserEmailBusinessRules userEmailBusinessRules)
        {
            _mapper = mapper;
            _userEmailRepository = userEmailRepository;
            _userEmailBusinessRules = userEmailBusinessRules;
        }

        public async Task<UpdatedUserEmailResponse> Handle(UpdateUserEmailCommand request, CancellationToken cancellationToken)
        {
            UserEmail? userEmail = await _userEmailRepository.GetAsync(ue => ue.Id == request.Id, cancellationToken: cancellationToken);
            await _userEmailBusinessRules.UserEmailShouldExistWhenSelected(userEmail);
            userEmail = _mapper.Map(request, userEmail);

            await _userEmailRepository.UpdateAsync(userEmail);

            UpdatedUserEmailResponse response = _mapper.Map<UpdatedUserEmailResponse>(userEmail);
            return response;
        }
    }
}