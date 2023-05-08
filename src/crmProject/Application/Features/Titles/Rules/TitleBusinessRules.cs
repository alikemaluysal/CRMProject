using Application.Features.Titles.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.Titles.Rules;

public class TitleBusinessRules : BaseBusinessRules
{
    private readonly ITitleRepository _titleRepository;

    public TitleBusinessRules(ITitleRepository titleRepository)
    {
        _titleRepository = titleRepository;
    }

    public Task TitleShouldExistWhenSelected(Title? title)
    {
        if (title == null)
            throw new BusinessException(TitlesBusinessMessages.TitleNotExists);
        return Task.CompletedTask;
    }

    public async Task TitleIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Title? title = await _titleRepository.GetAsync(
            predicate: t => t.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await TitleShouldExistWhenSelected(title);
    }
}