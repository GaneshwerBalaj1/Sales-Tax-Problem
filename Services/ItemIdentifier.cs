namespace InventoryManagement.Models
{
    public class ItemIdentifier : IItemIdentifier
    {
        public string DetermineItemType(string itemName)
        {
            if (itemName.Contains("book", StringComparison.OrdinalIgnoreCase)) return "Book";
            if (itemName.Contains("chocolate", StringComparison.OrdinalIgnoreCase) || itemName.Contains("food", StringComparison.OrdinalIgnoreCase)) return "Food";
            if (itemName.Contains("pill", StringComparison.OrdinalIgnoreCase) || itemName.Contains("medical", StringComparison.OrdinalIgnoreCase)) return "Medical";
            return "Other";
        }
    }
}