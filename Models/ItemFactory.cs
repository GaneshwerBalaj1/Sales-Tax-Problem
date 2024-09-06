namespace InventoryManagement.Models
{
    public class ItemFactory : IItemFactory
    {
        public Item CreateItem(string itemName, decimal itemCost, int quantity, string itemType, bool isImported)
        {
            return itemType.ToLower() switch
            {
                "book" => new Item(itemName, isImported, itemCost, quantity, "Book"),
                "food" => new Item(itemName, isImported, itemCost, quantity, "Food"),
                "medical" => new Item(itemName, isImported, itemCost, quantity, "Medical"),
                "other" => new Item(itemName, isImported, itemCost, quantity, "Other"),
                _ => throw new ArgumentException($"Unknown item type: {itemType}"),
            };
        }
    }
}
