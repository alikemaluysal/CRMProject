using Application.Features.Departments.Constants;
using Application.Features.Departments.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.Departments.Rules;

public class DepartmentBusinessRules : BaseBusinessRules
{
    private readonly IDepartmentRepository _departmentRepository;

    public DepartmentBusinessRules(IDepartmentRepository departmentRepository)
    {
        _departmentRepository = departmentRepository;
    }

    public Task DepartmentShouldExistWhenSelected(Department? department)
    {
        if (department == null)
            throw new BusinessException(DepartmentsBusinessMessages.DepartmentNotExists);
        return Task.CompletedTask;
    }

    public async Task DepartmentIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        Department? department = await _departmentRepository.GetAsync(
            predicate: d => d.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await DepartmentShouldExistWhenSelected(department);
    }

    public async Task DepartmentNameShouldNotExistWhenCreating(string name)
    {
        Department? result = await _departmentRepository.GetAsync(x => x.Name.ToLower() == name.ToLower());
        if (result != null)
            throw new BusinessException(DepartmentsBusinessMessages.DepartmentNameExists);
    }

    public async Task DepartmentNameShouldNotExistWhenUpdating(Department department)
    {
        Department? result = await _departmentRepository.GetAsync(x => x.Id != department.Id && x.Name.ToLower() == department.Name.ToLower());
        if (result != null)
            throw new BusinessException(DepartmentsBusinessMessages.DepartmentNameExists);
    }
}