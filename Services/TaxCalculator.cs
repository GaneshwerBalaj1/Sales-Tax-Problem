using InventoryManagement.Models;

namespace InventoryManagement.Services
{
    public class TaxCalculator : ITaxCalculator
    {
        private readonly IEnumerable<ITaxType> taxTypes;

        public TaxCalculator(IEnumerable<ITaxType> taxRules)
        {
            taxTypes = taxRules;
        }

        public decimal CalculateTax(Item item)
        {
            decimal totalTax = taxTypes.Sum(rule => rule.CalculateTax(item));
            return RoundUpToNearest05(totalTax);
        }

        private static decimal RoundUpToNearest05(decimal amount) => Math.Ceiling(amount * 20) / 20;
    }
}