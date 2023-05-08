using Application.Features.Sales.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.Sales.Rules;

public class SaleBusinessRules : BaseBusinessRules
{
    private readonly ISaleRepository _saleRepository;

    public SaleBusinessRules(ISaleRepository saleRepository)
    {
        _saleRepository = saleRepository;
    }

    public Task SaleShouldExistWhenSelected(Sale? sale)
    {
        if (sale == null)
            throw new BusinessException(SalesBusinessMessages.SaleNotExists);
        return Task.CompletedTask;
    }

    public async Task SaleIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Sale? sale = await _saleRepository.GetAsync(
            predicate: s => s.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await SaleShouldExistWhenSelected(sale);
    }
}