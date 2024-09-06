using InventoryManagement.Models;
namespace InventoryManagement.Services
{
    public class ConsoleInputSource : IInputSource
    {
        public IEnumerable<string> GetInput()
        {
            Console.WriteLine("Enter item details (e.g., '1 book at 12.49'). Press Enter on an empty line to finish:");

            var inputLines = new List<string>();
            string? line;

            while (!string.IsNullOrEmpty(line = Console.ReadLine()))
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    inputLines.Add(line.Trim());
                }
            }

            return inputLines;
        }
    }
}
