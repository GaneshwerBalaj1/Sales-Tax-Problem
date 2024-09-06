namespace InventoryManagement.Models
{
    public class ItemFactory : IItemFactory
    {
        private readonly IDictionary<string, Func<string, decimal, int, bool, Item>> _itemCreators;

        public ItemFactory()
        {
            _itemCreators = new Dictionary<string, Func<string, decimal, int, bool, Item>>
        {
            { "Book", (name, cost, qty, imported) => new Item(name, imported, cost, qty, "Book") },
            { "Food", (name, cost, qty, imported) => new Item(name, imported, cost, qty, "Food") },
            { "Medical", (name, cost, qty, imported) => new Item(name, imported, cost, qty, "Medical") },
            { "Other", (name, cost, qty, imported) => new Item(name, imported, cost, qty, "Other") }
        };
        }

        public Item CreateItem(string itemName, decimal itemCost, int quantity, string itemType, bool isImported)
        {
            if (_itemCreators.ContainsKey(itemType))
            {
                return _itemCreators[itemType](itemName, itemCost, quantity, isImported);
            }

            throw new ArgumentException($"Unknown item type: {itemType}");
        }
    }
}