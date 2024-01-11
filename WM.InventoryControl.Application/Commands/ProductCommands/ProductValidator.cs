using WM.InventoryControl.Domain.Entities;

namespace WM.InventoryControl.Application.Commands.ProductCommands
{
    public class ProductValidator
    {
        public static Product IsProductValid(Product product)
        {
            if (product.Quantity.Equals(0)) throw new Exception("O Quantity e obrigatório.");

            if (string.IsNullOrEmpty(product.Name)) throw new Exception("O nome e obrigatório.");

            if (product.Price.Equals(decimal.Zero)) throw new Exception("O preço e obrigatório.");

            if (string.IsNullOrEmpty(product.CategoryId.ToString())) throw new Exception("O CategoryId e obrigatório.");

            return product;
        }
    }
}
