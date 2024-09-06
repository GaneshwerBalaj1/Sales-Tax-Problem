namespace InventoryManagement.Models
{
    public class SalesTax : ITaxType
    {
        public decimal taxRate { get; }

        public SalesTax(decimal taxRate)
        {
            this.taxRate = taxRate;
        }

        public decimal CalculateTax(Item item)
        {
            return item.ItemType == "Other" ? item.ItemCost * item.Quantity * taxRate : 0;
        }
    }
}