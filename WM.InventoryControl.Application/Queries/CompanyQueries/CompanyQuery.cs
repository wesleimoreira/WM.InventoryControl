using MediatR;
using WM.InventoryControl.Application.Dtos;

namespace WM.InventoryControl.Application.Queries.CompanyQueries
{
    public record GetCompanyQuery(Guid Id) : IRequest<CompanyDto> { }
    public record GetAllCompanyQuery : IRequest<IEnumerable<CompanyDto>> { }
}
