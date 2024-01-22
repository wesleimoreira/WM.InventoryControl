using MediatR;
using WM.InventoryControl.Application.Dtos;

namespace WM.InventoryControl.Application.Queries.EmployeeQueries
{
    public record GetEmployQuery(Guid Id) : IRequest<EmployeeDto> { }
    public record GetAllEmployQuery : IRequest<IEnumerable<EmployeeDto>> { }
}
