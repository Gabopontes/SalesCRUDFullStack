namespace SalesCRUD.Domain
{
    public class SaleItem
    {
        public Guid ProductId { get; private set; }
        public int Quantity { get; private set; }
        public decimal UnitPrice { get; private set; }
        public decimal TotalAmount { get; private set; }

        public SaleItem(Guid productId, int quantity, decimal unitPrice)
        {
            ProductId = productId;
            Quantity = quantity;
            UnitPrice = unitPrice;
            TotalAmount = quantity * unitPrice;
        }

        public void ApplyDiscount(decimal discountRate)
        {
            TotalAmount -= TotalAmount * discountRate;
        }
    }
}