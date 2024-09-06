namespace InventoryManagement.Models
{
    public interface ITaxCalculator
    {
        decimal CalculateTax(Item item);
    }
}