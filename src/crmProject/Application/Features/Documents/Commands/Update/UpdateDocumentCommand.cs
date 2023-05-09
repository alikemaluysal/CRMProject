using Application.Features.Documents.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Documents.Commands.Update;

public class UpdateDocumentCommand : IRequest<UpdatedDocumentResponse>
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int RequestId { get; set; }
    public string DocumentFileName { get; set; }
    public int DocumentTypeId { get; set; }

    public class UpdateDocumentCommandHandler : IRequestHandler<UpdateDocumentCommand, UpdatedDocumentResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDocumentRepository _documentRepository;
        private readonly DocumentBusinessRules _documentBusinessRules;

        public UpdateDocumentCommandHandler(IMapper mapper, IDocumentRepository documentRepository,
                                         DocumentBusinessRules documentBusinessRules)
        {
            _mapper = mapper;
            _documentRepository = documentRepository;
            _documentBusinessRules = documentBusinessRules;
        }

        public async Task<UpdatedDocumentResponse> Handle(UpdateDocumentCommand request, CancellationToken cancellationToken)
        {
            Document? document = await _documentRepository.GetAsync(d => d.Id == request.Id, cancellationToken: cancellationToken);
            await _documentBusinessRules.DocumentShouldExistWhenSelected(document);
            document = _mapper.Map(request, document);

            await _documentRepository.UpdateAsync(document);

            UpdatedDocumentResponse response = _mapper.Map<UpdatedDocumentResponse>(document);
            return response;
        }
    }
}