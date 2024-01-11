using MediatR;
using WM.InventoryControl.Application.Queries.AddressQueries;
using WM.InventoryControl.Application.Queries.CompanyQueries;
using WM.InventoryControl.Domain.Interfaces;

namespace WM.InventoryControl.Application.Queries.EmployeeQueries
{
    public class EmployeeQueryHandler(IEmployeeService employeeService) : IRequestHandler<GetEmployQuery, EmployeeViewModel>, IRequestHandler<GetAllEmployQuery, IEnumerable<EmployeeViewModel>>
    {
        private readonly IEmployeeService _employeeService = employeeService;

        public async Task<EmployeeViewModel> Handle(GetEmployQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var employee = await _employeeService.GetEmployeeAsync(request.Id);

                if (employee is null) return default!;

                return new EmployeeViewModel(employee.Id, employee.Name,
                    new CompanyViewModel(employee.Company.Id, employee.Company.Name, null),
                    new AddressViewModel(
                        employee.Address.Id,
                        employee.Address.Country,
                        employee.Address.State,
                        employee.Address.City,
                        employee.Address.District,
                        employee.Address.Street,
                        employee.Address.ZipCode));
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<EmployeeViewModel>> Handle(GetAllEmployQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return (from employee in await _employeeService.GetAllEmployeesAsync()
                        select new EmployeeViewModel(employee.Id, employee.Name,
                                new CompanyViewModel(employee.Company.Id, employee.Company.Name, null),
                                new AddressViewModel(
                                    employee.Address.Id,
                                    employee.Address.Country,
                                    employee.Address.State,
                                    employee.Address.City,
                                    employee.Address.District,
                                    employee.Address.Street,
                                    employee.Address.ZipCode))).ToList();
            }
            catch
            {
                throw;
            }
        }
    }
}
