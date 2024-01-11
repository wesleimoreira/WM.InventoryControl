using MediatR;
using WM.InventoryControl.Domain.Entities;
using WM.InventoryControl.Domain.Interfaces;

namespace WM.InventoryControl.Application.Commands.CategoryCommands
{
    public class CategoryCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<AddCategoryCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Guid> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (string.IsNullOrEmpty(request.Name)) throw new Exception("O nome e obrigatório.");

                var categoryId = await _unitOfWork.AddAsync<Category>(new Category(Guid.NewGuid(), request.Name));

                await _unitOfWork.SaveChangesAsync();

                return categoryId;
            }
            catch
            {
                throw;
            }
        }
    }
}
