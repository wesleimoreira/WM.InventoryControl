﻿namespace WM.InventoryControl.Domain.Entities
{
    public class Purchase(Guid Id, int Quantity, decimal Price, DateTime DatePurchase) : EntityBase(Id)
    {
        public decimal Price { get; private set; } = Price;
        public int Quantity { get; private set; } = Quantity;
        public DateTime DatePurchase { get; private set; } = DatePurchase;

        // EF
        public IEnumerable<PurchaseProduct> PurchaseProducts { get; private set; } = default!;
    }
}
