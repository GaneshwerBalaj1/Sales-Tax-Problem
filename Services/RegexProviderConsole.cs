using InventoryManagement.Models;

namespace InventoryManagement.Services
{
    public class RegexProviderConsole : IRegexProvider
    {
        public string RegexPattern => @"^(\d+) (.+) at (\d+(\.\d{1,2})?)$";
    }
}