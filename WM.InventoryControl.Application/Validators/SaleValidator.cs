using WM.InventoryControl.Domain.Entities;

namespace WM.InventoryControl.Application.Validators
{
    public static class SaleValidator
    {
        public static Sale AddSale(int quantity, decimal price)
        {
            if (quantity.Equals(0)) throw new Exception("O Quantity e obrigatório.");

            if (price.Equals(decimal.Zero)) throw new Exception("O Preço e Obrigatório");

            return new Sale(Guid.NewGuid(), quantity, price, DateTime.Now);
        }

        public static SaleProduct AddSaleProduct(Guid saleId, Guid productId, int quantityUnitProduct)
        {
            if (string.IsNullOrEmpty(saleId.ToString())) throw new Exception("O saleId e obrigatório");

            if (string.IsNullOrEmpty(productId.ToString())) throw new Exception("O productId e obrigatório");

            if (quantityUnitProduct.Equals(0)) throw new Exception("A Quantidade de produtos deve ser maior que zero.");

            return new SaleProduct(Guid.NewGuid(), saleId, productId, quantityUnitProduct);
        }
    }
}
