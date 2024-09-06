namespace InventoryManagement.Models
{
    public interface IInputParser
    {
        (string itemName, decimal itemPrice, int quantity, string itemType, bool isImported)? ParseItemDetails(string input);
    }
}