using Application.Features.Titles.Constants;
using Application.Features.Titles.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Titles.Commands.Delete;

public class DeleteTitleCommand : IRequest<DeletedTitleResponse>
{
    public Guid Id { get; set; }

    public class DeleteTitleCommandHandler : IRequestHandler<DeleteTitleCommand, DeletedTitleResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITitleRepository _titleRepository;
        private readonly TitleBusinessRules _titleBusinessRules;

        public DeleteTitleCommandHandler(IMapper mapper, ITitleRepository titleRepository,
                                         TitleBusinessRules titleBusinessRules)
        {
            _mapper = mapper;
            _titleRepository = titleRepository;
            _titleBusinessRules = titleBusinessRules;
        }

        public async Task<DeletedTitleResponse> Handle(DeleteTitleCommand request, CancellationToken cancellationToken)
        {
            Title? title = await _titleRepository.GetAsync(t => t.Id == request.Id, cancellationToken: cancellationToken);
            await _titleBusinessRules.TitleShouldExistWhenSelected(title);

            await _titleRepository.DeleteAsync(title!);

            DeletedTitleResponse response = _mapper.Map<DeletedTitleResponse>(title);
            return response;
        }
    }
}