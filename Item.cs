namespace InventoryManagement.Models
{
    public enum ItemType
    {
        Book = 1,
        Food = 2,
        Medical = 3,
        Other = 4
    }

    public abstract class Item
    {
        public string ItemName { get; set; }
        public bool IsItemImported { get; set; }
        public decimal ItemCost { get; set; }
        public int Quantity { get; set; }
        public ItemType ItemType { get; protected set; }

        protected Item(string itemName, bool isItemImported, decimal itemCost, int quantity)
        {
            ItemName = itemName;
            IsItemImported = isItemImported;
            ItemCost = itemCost;
            Quantity = quantity;
        }

        public virtual decimal CalculateTax()
        {
            decimal tax = 0;

            if (IsItemImported)
            {
                tax = ItemCost * Quantity * 0.05m;
            }

            return RoundUpToNearest05(tax);
        }

        protected static decimal RoundUpToNearest05(decimal amount) => Math.Ceiling(amount * 20) / 20;
    }

    public class Book : Item
    {
        public Book(string itemName, bool isItemImported, decimal itemCost, int quantity)
            : base(itemName, isItemImported, itemCost, quantity)
        {
            ItemType = ItemType.Book;
        }
    }

    public class Medical : Item
    {
        public Medical(string itemName, bool isItemImported, decimal itemCost, int quantity)
            : base(itemName, isItemImported, itemCost, quantity)
        {
            ItemType = ItemType.Medical;
        }
    }

    public class Food : Item
    {
        public Food(string itemName, bool isItemImported, decimal itemCost, int quantity)
            : base(itemName, isItemImported, itemCost, quantity)
        {
            ItemType = ItemType.Food;
        }
    }

    public class Other : Item
    {
        public Other(string itemName, bool isItemImported, decimal itemCost, int quantity)
            : base(itemName, isItemImported, itemCost, quantity)
        {
            ItemType = ItemType.Other;
        }

        public override decimal CalculateTax()
        {
            decimal importDuty = 0;

            if (IsItemImported)
            {
                importDuty = ItemCost * Quantity * 0.05m;
            }

            var salesTax = ItemCost * Quantity * 0.1m;
            return RoundUpToNearest05(importDuty) + salesTax;
        }
    }
}
