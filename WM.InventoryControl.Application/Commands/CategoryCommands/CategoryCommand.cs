using MediatR;

namespace WM.InventoryControl.Application.Commands.CategoryCommands
{
    public record AddCategoryCommand(string Name) : IRequest<Guid> { }

    public record DeleteCategoryCommand(Guid Id, string Name) : IRequest { }
}
