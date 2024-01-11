using MediatR;

namespace WM.InventoryControl.Application.Queries.SupplierQueries
{
    public record GetSupplierQuery(Guid Id) : IRequest<SupplierViewModel> { }

    public record GetAllSupplierQuery : IRequest<IEnumerable<SupplierViewModel>> { }

}
