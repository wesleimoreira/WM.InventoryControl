using MediatR;
using WM.InventoryControl.Application.Dtos;

namespace WM.InventoryControl.Application.Queries.SupplierQueries
{
    public record GetSupplierQuery(Guid Id) : IRequest<SupplierDto> { }

    public record GetAllSupplierQuery : IRequest<IEnumerable<SupplierDto>> { }

}
