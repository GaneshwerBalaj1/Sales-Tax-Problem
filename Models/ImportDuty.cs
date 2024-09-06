namespace InventoryManagement.Models
{
    public class ImportDuty : ITaxType
    {
        public decimal taxRate { get; }

        public ImportDuty(decimal taxRate)
        {
            this.taxRate = taxRate;
        }

        public decimal CalculateTax(Item item)
        {
            return item.IsItemImported ? item.ItemCost * item.Quantity * taxRate : 0;
        }
    }
}