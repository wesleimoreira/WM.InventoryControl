using WM.InventoryControl.Domain.Entities;

namespace WM.InventoryControl.Application.Validators
{
    public static class ProductValidator
    {
        public static Product AddProduct(string name, int quantity, decimal price, Guid categoryId)
        {
            if (quantity.Equals(0)) throw new Exception("O Quantity e obrigatório.");

            if (string.IsNullOrEmpty(name)) throw new Exception("O nome e obrigatório.");

            if (price.Equals(decimal.Zero)) throw new Exception("O preço e obrigatório.");

            if (string.IsNullOrEmpty(categoryId.ToString())) throw new Exception("O CategoryId e obrigatório.");

            return new Product(Guid.NewGuid(), name, quantity, price, categoryId, DateTime.Now, null);
        }

        public static Product UpdateProduct(this Product product, string name, int quantity, decimal price, Guid categoryId)
        {
            if (quantity.Equals(0)) throw new Exception("O Quantity e obrigatório.");

            if (string.IsNullOrEmpty(name)) throw new Exception("O nome e obrigatório.");

            if (price.Equals(decimal.Zero)) throw new Exception("O preço e obrigatório.");

            if (string.IsNullOrEmpty(categoryId.ToString())) throw new Exception("O CategoryId e obrigatório.");

            return product.UpdateProduct(name, quantity, price, categoryId);
        }
    }
}
