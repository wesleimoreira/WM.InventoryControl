using WM.InventoryControl.Domain.Entities;

namespace WM.InventoryControl.Application.Validators
{
    public static class ProductValidator
    {
        public static Product IsProductValid(Product product)
        {
            if (product.Quantity.Equals(0)) throw new Exception("O Quantity e obrigatório.");

            if (string.IsNullOrEmpty(product.Name)) throw new Exception("O nome e obrigatório.");

            if (product.Price.Equals(decimal.Zero)) throw new Exception("O preço e obrigatório.");

            if (string.IsNullOrEmpty(product.CategoryId.ToString())) throw new Exception("O CategoryId e obrigatório.");

            return product;
        }

        public static Product AddProduct(string name, int quantity, decimal price, Guid categoryId)
        {
            return IsProductValid(new Product(Guid.NewGuid(), name, quantity, price, categoryId, DateTime.Now, null));
        }

        public static Product UpdateProduct(this Product product, string name, int quantity, decimal price, Guid categoryId)
        {
            return IsProductValid(product.UpdateProduct(name, quantity, price, categoryId));
        }
    }
}
