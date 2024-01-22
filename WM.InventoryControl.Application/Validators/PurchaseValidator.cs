using WM.InventoryControl.Domain.Entities;

namespace WM.InventoryControl.Application.Validators
{
    public static class PurchaseValidator
    {
        public static Purchase AddPurchase(int quantity, decimal price)
        {
            if (quantity.Equals(0)) throw new Exception("O Quantity e obrigatório.");

            if (price.Equals(decimal.Zero)) throw new Exception("O Preço e Obrigatório");

            return new Purchase(Guid.NewGuid(), quantity, price, DateTime.Now);
        }

        public static PurchaseProduct AddPurchaseProduct(Guid purchaseId, Guid productId, int quantityUnitProduct)
        {
            if (string.IsNullOrEmpty(purchaseId.ToString())) throw new Exception("O purchaseId e obrigatório");

            if (string.IsNullOrEmpty(productId.ToString())) throw new Exception("O productId e obrigatório");

            if (quantityUnitProduct.Equals(0)) throw new Exception("A Quantidade de produtos deve ser maior que zero.");

            return new PurchaseProduct(Guid.NewGuid(), purchaseId, productId, quantityUnitProduct);
        }
    }
}
