using InventoryManagement.Models;

namespace InventoryManagement.Services
{
    public class Receipt(List<Item> items)
    {
        private readonly List<Item> items = items;

        public void Print()
        {
            Console.WriteLine("\n");
            Console.WriteLine("Your Billing details are below");
            Console.WriteLine("------- Date : " + DateTime.Now.ToString("dd/MM/yyyy") + " -------");
            Console.WriteLine("");
            Console.WriteLine("Item Name (Quantity)            Cost     Tax      Total");

            decimal totalTaxes = 0;
            decimal totalCost = 0;

            foreach (var item in items)
            {
                decimal itemTax = item.CalculateTax();
                decimal itemTotal = (item.ItemCost * item.Quantity) + itemTax;
                totalTaxes += itemTax;
                totalCost += itemTotal;
                Console.WriteLine(
                    $"{item.ItemName} ({item.Quantity})".PadRight(30)
                        + $"{(item.ItemCost * item.Quantity):F2}".PadRight(10)
                        + $"{itemTax:F2}".PadRight(10)
                        + $"{itemTotal:F2}"
                );
            }

            Console.WriteLine("\n");
            Console.WriteLine($"----------------- Total Items : {items.Count} -----------------\n");
            Console.WriteLine($"Total Taxes: {totalTaxes:F2}");
            Console.WriteLine($"Grand Total: {totalCost:F2}");
        }
    }
}
