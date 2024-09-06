namespace InventoryManagement.Models
{
    public interface IInputSource
    {
        IEnumerable<string> GetInput();
    }
}