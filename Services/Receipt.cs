using InventoryManagement.Models;

namespace InventoryManagement.Services
{
    public class Receipt
    {
        private readonly IEnumerable<Item> itemsList;
        private readonly ITaxCalculator taxCalculator;

        public Receipt(IEnumerable<Item> items, ITaxCalculator taxCalculator)
        {
            itemsList = items;
            this.taxCalculator = taxCalculator;
        }

        public void Print()
        {
            foreach (var item in itemsList)
            {
                decimal itemTax = taxCalculator.CalculateTax(item);
                decimal itemTotal = (item.ItemCost * item.Quantity) + itemTax;
                Console.WriteLine($"{item.Quantity} {item.ItemName}: {(itemTotal):F2}");
            }

            var totalTaxes = itemsList.Sum(item => taxCalculator.CalculateTax(item));
            var totalCost = itemsList.Sum(item => (item.ItemCost * item.Quantity) + taxCalculator.CalculateTax(item));

            Console.WriteLine();
            Console.WriteLine($"Sales Taxes: {totalTaxes:F2}");
            Console.WriteLine($"Total: {totalCost:F2}");
        }
    }
}