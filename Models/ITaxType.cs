namespace InventoryManagement.Models
{
    public interface ITaxType
    {
        decimal taxRate { get; }

        decimal CalculateTax(Item item);
    }
}