using MediatR;

namespace WM.InventoryControl.Application.Queries.CompanyQueries
{
    public record GetCompanyQuery(Guid Id) : IRequest<CompanyViewModel> { }
    public record GetAllCompanyQuery : IRequest<IEnumerable<CompanyViewModel>> { }
}
