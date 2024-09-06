using InventoryManagement.Models;
using InventoryManagement.Services;

internal class Program
{
    private static void Main(string[] args)
    {
        IItemFactory itemFactory = new ItemFactory();
        IInputSource consoleInputSource = new ConsoleInputSource();
        List<ITaxType> taxes = new();
        ITaxType salexTax = new SalesTax(0.1m);
        ITaxType importDuty = new ImportDuty(0.05m);
        taxes.Add(salexTax);
        taxes.Add(importDuty);
        ITaxCalculator taxCalculator = new TaxCalculator(taxes);

        IItemIdentifier itemIdentifier = new ItemIdentifier();
        IRegexProvider consoleRegexProvider = new RegexProviderConsole();
        IInputParser inputParser = new InputParser(consoleRegexProvider, itemIdentifier);
        IInputHandler consoleInputHandler = new ConsoleInputHandler();

        var inputLines = consoleInputSource.GetInput();
        var items = consoleInputHandler.ProcessInput(inputLines, itemFactory, inputParser);
        var receipt = new Receipt(items, taxCalculator);
        receipt.Print();
    }
}