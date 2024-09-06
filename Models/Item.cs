namespace InventoryManagement.Models
{
    public class Item
    {
        public string ItemName { get; set; }
        public bool IsItemImported { get; set; }
        public decimal ItemCost { get; set; }
        public int Quantity { get; set; }
        public string ItemType { get; set; }

        public Item(string itemName, bool isItemImported, decimal itemCost, int quantity, string itemType)
        {
            ItemName = itemName;
            IsItemImported = isItemImported;
            ItemCost = itemCost;
            Quantity = quantity;
            ItemType = itemType;
        }
    }
}