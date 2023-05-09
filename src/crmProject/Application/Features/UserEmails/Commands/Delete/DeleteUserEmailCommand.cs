using Application.Features.UserEmails.Constants;
using Application.Features.UserEmails.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.UserEmails.Commands.Delete;

public class DeleteUserEmailCommand : IRequest<DeletedUserEmailResponse>
{
    public int Id { get; set; }

    public class DeleteUserEmailCommandHandler : IRequestHandler<DeleteUserEmailCommand, DeletedUserEmailResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserEmailRepository _userEmailRepository;
        private readonly UserEmailBusinessRules _userEmailBusinessRules;

        public DeleteUserEmailCommandHandler(IMapper mapper, IUserEmailRepository userEmailRepository,
                                         UserEmailBusinessRules userEmailBusinessRules)
        {
            _mapper = mapper;
            _userEmailRepository = userEmailRepository;
            _userEmailBusinessRules = userEmailBusinessRules;
        }

        public async Task<DeletedUserEmailResponse> Handle(DeleteUserEmailCommand request, CancellationToken cancellationToken)
        {
            UserEmail? userEmail = await _userEmailRepository.GetAsync(ue => ue.Id == request.Id, cancellationToken: cancellationToken);
            await _userEmailBusinessRules.UserEmailShouldExistWhenSelected(userEmail);

            await _userEmailRepository.DeleteAsync(userEmail!);

            DeletedUserEmailResponse response = _mapper.Map<DeletedUserEmailResponse>(userEmail);
            return response;
        }
    }
}