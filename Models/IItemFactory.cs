namespace InventoryManagement.Models
{
    public interface IItemFactory
    {
        Item CreateItem(string itemName, decimal itemCost, int quantity, string itemType, bool isImported);
    }
}