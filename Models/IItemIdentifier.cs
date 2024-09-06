namespace InventoryManagement.Models
{
    public interface IItemIdentifier
    {
        string DetermineItemType(string itemName);
    }
}