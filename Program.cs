using InventoryManagement.Models;
using InventoryManagement.Services;

namespace InventoryManagement
{
    public class Program
    {
        private static List<Item> cartItems = new();
        private static readonly IItemFactory itemFactory = new ItemFactory();

        static void Main(string[] args)
        {
            cartItems = GetCartItems();

            var receipt = new Receipt(cartItems);
            receipt.Print();

            Console.ReadLine();
        }

        private static List<Item> GetCartItems()
        {
            Console.WriteLine("Enter sample input number (0/1/2/3):");
            if (!int.TryParse(Console.ReadLine(), out int n) || n < 0 || n > 3)
            {
                Console.WriteLine("Please enter a number between 0 and 3.");
                return cartItems;
            }

            switch (n)
            {
                case 0:
                    AddSampleItems(
                        ("Book", 12.49m, 1, ItemType.Book, false),
                        ("Music CD", 14.99m, 1, ItemType.Other, false),
                        ("Chocolate bar", 0.85m, 1, ItemType.Food, false));
                    break;

                case 1:
                    AddSampleItems(
                        ("Imported box of chocolates", 10.00m, 1, ItemType.Food, true),
                        ("Imported bottle of perfume", 47.50m, 1, ItemType.Other, true));
                    break;

                case 2:
                    AddSampleItems(
                        ("Imported bottle of perfume", 27.99m, 1, ItemType.Other, true),
                        ("Bottle of perfume", 18.99m, 1, ItemType.Other, false),
                        ("Packet of headache pills", 9.75m, 1, ItemType.Medical, false),
                        ("Box of imported chocolates", 11.25m, 1, ItemType.Food, true));
                    break;

                case 3:
                    AddCustomItems();
                    break;
            }

            return cartItems;
        }

        private static void AddSampleItems(params (string itemName, decimal itemPrice, int Quantity, ItemType itemType, bool isItemImported)[] items)
        {
            foreach (var item in items)
            {
                cartItems.Add(itemFactory.GetItem(item.itemName, item.itemPrice, item.Quantity, item.itemType, item.isItemImported));
            }
        }

        private static void AddCustomItems()
        {
            cartItems.Clear();
            while (true)
            {
                Console.WriteLine("Enter item name (or type 'done' to finish):");
                string? itemName = Console.ReadLine()?.Trim();

                if (string.IsNullOrWhiteSpace(itemName))
                {
                    Console.WriteLine("Item name cannot be empty. Please enter a valid name.");
                    continue;
                }
                if (string.Compare(itemName.ToLower(), "done") == 0) break;

                if (!GetValidInput("Enter item price:", out decimal itemPrice)) continue;
                if (!GetValidInput("Enter item quantity:", out int itemQuantity)) continue;

                Console.WriteLine("Select item type (1: Book, 2: Food, 3: Medical, 4: Other):");
                if (!int.TryParse(Console.ReadLine(), out int itemTypeInt) || itemTypeInt < 1 || itemTypeInt > 4)
                {
                    Console.WriteLine("Invalid item type. Please try again.");
                    continue;
                }
                ItemType itemType = (ItemType)itemTypeInt;

                bool isItemImported = GetIsItemImported();

                cartItems.Add(itemFactory.GetItem(itemName, itemPrice, itemQuantity, itemType, isItemImported));
            }
        }


        private static bool GetIsItemImported()
        {
            while (true)
            {
                Console.WriteLine("Is the item imported? (yes/no):");
                string? input = Console.ReadLine()?.ToLower();

                if (input == "yes")
                {
                    return true;
                }
                else if (input == "no")
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter 'yes' or 'no'.");
                }
            }
        }

        private static bool GetValidInput<T>(string prompt, out T result) where T : struct
        {
            Console.WriteLine(prompt);
            string? input = Console.ReadLine();

            result = default;

            if (typeof(T) == typeof(decimal) && decimal.TryParse(input, out decimal decimalResult))
            {
                result = (T)(object)decimalResult;
                return true;
            }
            else if (typeof(T) == typeof(int) && int.TryParse(input, out int intResult))
            {
                result = (T)(object)intResult;
                return true;
            }

            Console.WriteLine("Invalid input. Please try again.");
            return false;
        }
    }
}
