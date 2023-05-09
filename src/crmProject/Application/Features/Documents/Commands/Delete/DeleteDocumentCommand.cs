using Application.Features.Documents.Constants;
using Application.Features.Documents.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Documents.Commands.Delete;

public class DeleteDocumentCommand : IRequest<DeletedDocumentResponse>
{
    public int Id { get; set; }

    public class DeleteDocumentCommandHandler : IRequestHandler<DeleteDocumentCommand, DeletedDocumentResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDocumentRepository _documentRepository;
        private readonly DocumentBusinessRules _documentBusinessRules;

        public DeleteDocumentCommandHandler(IMapper mapper, IDocumentRepository documentRepository,
                                         DocumentBusinessRules documentBusinessRules)
        {
            _mapper = mapper;
            _documentRepository = documentRepository;
            _documentBusinessRules = documentBusinessRules;
        }

        public async Task<DeletedDocumentResponse> Handle(DeleteDocumentCommand request, CancellationToken cancellationToken)
        {
            Document? document = await _documentRepository.GetAsync(d => d.Id == request.Id, cancellationToken: cancellationToken);
            await _documentBusinessRules.DocumentShouldExistWhenSelected(document);

            await _documentRepository.DeleteAsync(document!);

            DeletedDocumentResponse response = _mapper.Map<DeletedDocumentResponse>(document);
            return response;
        }
    }
}