namespace InventoryManagement.Models
{
    public interface IItemFactory
    {
        Item GetItem(string itemName, decimal itemCost, int quantity, ItemType itemType, bool isItemImported);
    }

    public class ItemFactory : IItemFactory
    {
        public Item GetItem(string itemName, decimal itemCost, int quantity, ItemType itemType, bool isItemImported)
        {
            return itemType switch
            {
                ItemType.Book => new Book(itemName, isItemImported, itemCost, quantity),
                ItemType.Food => new Food(itemName, isItemImported, itemCost, quantity),
                ItemType.Medical => new Medical(itemName, isItemImported, itemCost, quantity),
                ItemType.Other => new Other(itemName, isItemImported, itemCost, quantity),
                _ => throw new NotImplementedException(),
            };
        }
    }
}
