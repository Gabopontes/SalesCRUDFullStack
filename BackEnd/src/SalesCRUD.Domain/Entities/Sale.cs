using System;
using System.Collections.Generic;
using System.Linq;

namespace SalesCRUD.Domain
{
    public class Sale
    {
        public Guid Id { get; private set; }
        public string SaleNumber { get; private set; }
        public DateTime SaleDate { get; private set; }
        public Guid CustomerId { get; private set; }
        public Guid BranchId { get; private set; }
        public decimal TotalAmount { get; private set; }
        public bool IsCancelled { get; private set; }
        public List<SaleItem> Items { get; private set; } = new List<SaleItem>();

        public Sale(string saleNumber, DateTime saleDate, Guid customerId, Guid branchId)
        {
            Id = Guid.NewGuid();
            SaleNumber = saleNumber;
            SaleDate = saleDate;
            CustomerId = customerId;
            BranchId = branchId;
            IsCancelled = false;
        }

        public void AddItem(Guid productId, int quantity, decimal unitPrice)
        {
            if (quantity > 20)
            {
                throw new InvalidOperationException("Cannot sell more than 20 identical items.");
            }

            var item = new SaleItem(productId, quantity, unitPrice);
            Items.Add(item);
            TotalAmount += item.TotalAmount;
        }

        public void ApplyDiscounts()
        {
            foreach (var item in Items)
            {
                if (item.Quantity >= 10 && item.Quantity <= 20)
                {
                    item.ApplyDiscount(0.20m); // 20% de desconto
                }
                else if (item.Quantity >= 4)
                {
                    item.ApplyDiscount(0.10m); // 10% de desconto
                }
            }
            TotalAmount = Items.Sum(i => i.TotalAmount);
        }

        public void Cancel()
        {
            IsCancelled = true;
        }

        public void Update(string saleNumber, DateTime saleDate, Guid customerId, Guid branchId)
        {
            SaleNumber = saleNumber;
            SaleDate = saleDate;
            CustomerId = customerId;
            BranchId = branchId;
        }
    }
}