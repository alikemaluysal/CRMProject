using Application.Features.DocumentTypes.Constants;
using Application.Features.DocumentTypes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.DocumentTypes.Commands.Delete;

public class DeleteDocumentTypeCommand : IRequest<DeletedDocumentTypeResponse>
{
    public int Id { get; set; }

    public class DeleteDocumentTypeCommandHandler : IRequestHandler<DeleteDocumentTypeCommand, DeletedDocumentTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDocumentTypeRepository _documentTypeRepository;
        private readonly DocumentTypeBusinessRules _documentTypeBusinessRules;

        public DeleteDocumentTypeCommandHandler(IMapper mapper, IDocumentTypeRepository documentTypeRepository,
                                         DocumentTypeBusinessRules documentTypeBusinessRules)
        {
            _mapper = mapper;
            _documentTypeRepository = documentTypeRepository;
            _documentTypeBusinessRules = documentTypeBusinessRules;
        }

        public async Task<DeletedDocumentTypeResponse> Handle(DeleteDocumentTypeCommand request, CancellationToken cancellationToken)
        {
            DocumentType? documentType = await _documentTypeRepository.GetAsync(dt => dt.Id == request.Id, cancellationToken: cancellationToken);
            await _documentTypeBusinessRules.DocumentTypeShouldExistWhenSelected(documentType);

            await _documentTypeRepository.DeleteAsync(documentType!);

            DeletedDocumentTypeResponse response = _mapper.Map<DeletedDocumentTypeResponse>(documentType);
            return response;
        }
    }
}