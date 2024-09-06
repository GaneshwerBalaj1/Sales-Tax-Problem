using InventoryManagement.Models;
using System.Globalization;
using System.Text.RegularExpressions;

namespace InventoryManagement.Services
{
    public class InputParser : IInputParser
    {
        private readonly Regex _regex;
        private readonly IItemIdentifier _itemTypeProvider;

        public InputParser(IRegexProvider regexProvider, IItemIdentifier itemTypeProvider)
        {
            _regex = new Regex(regexProvider.RegexPattern, RegexOptions.Compiled);
            _itemTypeProvider = itemTypeProvider;
        }

        public (string itemName, decimal itemPrice, int quantity, string itemType, bool isImported)? ParseItemDetails(string input)
        {
            try
            {
                var match = _regex.Match(input);
                if (!match.Success)
                {
                    Console.WriteLine($"Invalid input format: {input}");
                    return null;
                }

                var quantity = int.Parse(match.Groups[1].Value);
                var itemName = match.Groups[2].Value;
                var itemPrice = decimal.Parse(match.Groups[3].Value, NumberStyles.Currency, CultureInfo.InvariantCulture);
                var isImported = itemName.Contains("imported", StringComparison.OrdinalIgnoreCase);
                var itemType = _itemTypeProvider.DetermineItemType(itemName);

                return (itemName, itemPrice, quantity, itemType, isImported);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error parsing input '{input}': {ex.Message}");
                return null;
            }
        }
    }
}