using InventoryManagement.Models;

namespace InventoryManagement.Services
{
    public class ConsoleInputHandler : IInputHandler
    {
        public IEnumerable<Item> ProcessInput(IEnumerable<string> inputLines, IItemFactory itemFactory, IInputParser inputParser)
        {
            var items = new List<Item>();

            foreach (var line in inputLines)
            {
                var itemDetails = inputParser.ParseItemDetails(line);
                if (itemDetails.HasValue)
                {
                    var (itemName, itemPrice, quantity, itemType, isImported) = itemDetails.Value;
                    var item = itemFactory.CreateItem(itemName, itemPrice, quantity, itemType, isImported);
                    items.Add(item);
                }
            }

            return items;
        }
    }
}