using Application.Features.Employees.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Employees.Commands.Update;

public class UpdateEmployeeCommand : IRequest<UpdatedEmployeeResponse>
{
    public Guid Id { get; set; }
    public int UserId { get; set; }
    public string? IdentityNumber { get; set; }
    public int? GenderId { get; set; }
    public int? TitleId { get; set; }
    public int? DepartmentId { get; set; }
    public DateTime? StartDate { get; set; }
    public int? StatusTypeId { get; set; }
    public int? RegionId { get; set; }
    public DateTime? BirthDate { get; set; }
    public int? ParentEmployeeId { get; set; }

    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, UpdatedEmployeeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly EmployeeBusinessRules _employeeBusinessRules;

        public UpdateEmployeeCommandHandler(IMapper mapper, IEmployeeRepository employeeRepository,
                                         EmployeeBusinessRules employeeBusinessRules)
        {
            _mapper = mapper;
            _employeeRepository = employeeRepository;
            _employeeBusinessRules = employeeBusinessRules;
        }

        public async Task<UpdatedEmployeeResponse> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            Employee? employee = await _employeeRepository.GetAsync(e => e.Id == request.Id, cancellationToken: cancellationToken);
            await _employeeBusinessRules.EmployeeShouldExistWhenSelected(employee);
            employee = _mapper.Map(request, employee);

            await _employeeRepository.UpdateAsync(employee);

            UpdatedEmployeeResponse response = _mapper.Map<UpdatedEmployeeResponse>(employee);
            return response;
        }
    }
}