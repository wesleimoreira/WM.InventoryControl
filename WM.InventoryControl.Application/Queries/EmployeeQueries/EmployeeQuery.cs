using MediatR;

namespace WM.InventoryControl.Application.Queries.EmployeeQueries
{
    public record GetEmployQuery(Guid Id) : IRequest<EmployeeViewModel> { }
    public record GetAllEmployQuery : IRequest<IEnumerable<EmployeeViewModel>> { }
}
