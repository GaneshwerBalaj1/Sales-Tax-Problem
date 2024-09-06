namespace InventoryManagement.Models
{
    public interface IInputHandler
    {
        IEnumerable<Item> ProcessInput(IEnumerable<string> inputLines, IItemFactory itemFactory, IInputParser inputParser);
    }
}