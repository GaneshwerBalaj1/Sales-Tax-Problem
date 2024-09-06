# Inventory Management System

## Overview

This Inventory Management System is a C# application designed to handle item input, categorize items, calculate taxes, and generate receipts.
## Components

### Models

- **Item**: Represents an item with properties like `ItemName`, `IsItemImported`, `ItemCost`, `Quantity`, and `ItemType`.
- **IItemFactory**: Factory interface for creating items.
- **IItemIdentifier**: Interface for determining item types.
- **ITaxType**: Interface for tax calculation types (e.g., `SalesTax`, `ImportDuty`).
- **ITaxCalculator**: Interface for tax calculation.

### Services

- **ConsoleInputHandler**: Handles processing of input lines to create items.
- **ConsoleInputSource**: Reads input from the console.
- **InputParser**: Parses input lines to extract item details using regex and item identifier.
- **Receipt**: Generates and prints a receipt based on items and taxes.
- **RegexProviderConsole**: Provides regex pattern for input parsing.
- **TaxCalculator**: Calculates the total tax based on a list of tax types.

### Interfaces

- **IInputHandler**: Interface for handling input processing.
- **IInputParser**: Interface for parsing input lines.
- **IInputSource**: Interface for input source (e.g., console).
- **IRegexProvider**: Interface for providing regex patterns.
- **ITaxType**: Interface for defining tax calculation types.
- **ITaxCalculator**: Interface for calculating tax.

### Tax Types

- **SalesTax**: Calculates sales tax for items classified as "Other".
- **ImportDuty**: Calculates import duty for imported items.

## Installation and Setup

1. **Prerequisites**:
   - Ensure you have the [.NET SDK](https://dotnet.microsoft.com/download) installed on your machine.
   - Use an IDE or code editor like [Visual Studio](https://visualstudio.microsoft.com/), [Visual Studio Code](https://code.visualstudio.com/), or [JetBrains Rider](https://www.jetbrains.com/rider/).

2. **Clone or Download the Repository**:
   - Clone the repository from GitHub:
     ```sh
     git clone https://github.com/GaneshwerBalaj1/Sales-Tax-Problem.git
     ```
   - Alternatively, download the code as a ZIP file from the repository and extract it.

3. **Open the Project**:
   - Open your project in your chosen IDE or code editor. If you’re using Visual Studio, open the `.sln` (solution) file.

4. **Build the Project**:
   - Build the project to ensure that everything is set up correctly:
     ```sh
     dotnet build
     ```

## Running the Application

1. **Run the Application**:
   - Run the application using the following command:
     ```sh
     dotnet run
     ```

2. **Provide Input**:
   - The application will prompt you to enter item details in the console. Enter the details as specified in your `RegexProviderConsole` regex pattern, for example:
     ```
     1 book at 12.49
     1 imported box of chocolates at 10.00
     1 bottle of perfume at 47.50
     ```
   - Press Enter on an empty line to finish input.

3. **View Output**:
   - After providing the input, the application will display the receipt, including item details and calculated taxes.

## Example

Here is how the program is structured and executed:

```csharp
internal class Program
{
    private static void Main(string[] args)
    {
        IItemFactory itemFactory = new ItemFactory();
        IInputSource consoleInputSource = new ConsoleInputSource();
        List<ITaxType> taxes = new();
        ITaxType salesTax = new SalesTax(0.1m);
        ITaxType importDuty = new ImportDuty(0.05m);
        taxes.Add(salesTax);
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
