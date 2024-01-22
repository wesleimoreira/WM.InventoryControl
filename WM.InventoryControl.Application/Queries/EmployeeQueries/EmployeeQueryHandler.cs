using MediatR;
using WM.InventoryControl.Application.Dtos;
using WM.InventoryControl.Domain.Interfaces;

namespace WM.InventoryControl.Application.Queries.EmployeeQueries
{
    public class EmployeeQueryHandler(IEmployeeService employeeService) : IRequestHandler<GetEmployQuery, EmployeeDto>, IRequestHandler<GetAllEmployQuery, IEnumerable<EmployeeDto>>
    {
        private readonly IEmployeeService _employeeService = employeeService;

        public async Task<EmployeeDto> Handle(GetEmployQuery request, CancellationToken cancellationToken)
        {
            var employee = await _employeeService.GetEmployeeAsync(request.Id);

            if (employee is null) return default!;

            return new EmployeeDto(employee.Id, employee.Name,
                new CompanyDto(employee.Company.Id, employee.Company.Name, null),
                new AddressDto(
                    employee.Address.Id,
                    employee.Address.Country,
                    employee.Address.State,
                    employee.Address.City,
                    employee.Address.District,
                    employee.Address.Street,
                    employee.Address.ZipCode));
        }

        public async Task<IEnumerable<EmployeeDto>> Handle(GetAllEmployQuery request, CancellationToken cancellationToken)
        {
            return (from employee in await _employeeService.GetAllEmployeesAsync()
                    select new EmployeeDto(employee.Id, employee.Name,
                            new CompanyDto(employee.Company.Id, employee.Company.Name, null),
                            new AddressDto(
                                employee.Address.Id,
                                employee.Address.Country,
                                employee.Address.State,
                                employee.Address.City,
                                employee.Address.District,
                                employee.Address.Street,
                                employee.Address.ZipCode))).ToList();
        }
    }
}
