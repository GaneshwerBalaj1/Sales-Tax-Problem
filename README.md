# Sales Tax Problem

## Overview

This project is a scalable and modular solution for calculating sales tax. It is designed to handle various types of items, including books, food, medical supplies, and other general items, with support for imported items and different tax rates.

## Features

- **Item Types**: Supports Book, Food, Medical, and Other items. Can be scaled in future.
- **Tax Calculation**: Computes tax based on item type and import status.
- **Modularity**: Easily extendable to include more item types and tax rules.
- **Round-Up**: Tax values are rounded up to the nearest 0.05.

## Structure

### Namespace

The project uses the `InventoryManagement.Models` and `InventoryManagement.Services` namespace to organize different classes and enumerations.

### Classes

- **`Item`**: Abstract base class representing a general item with common properties and tax calculation logic.
- **`Book`**: Inherits from `Item` and represents a book item.
- **`Food`**: Inherits from `Item` and represents a food item.
- **`Medical`**: Inherits from `Item` and represents a medical item.
- **`OtherItem`**: Inherits from `Item` and represents any other item.

### Enumerations

- **`ItemType`**: Enum defining various item types:
  - `Book`
  - `Food`
  - `Medical`
  - `Other`

## Tax Calculation

The tax calculation logic considers whether an item is imported and its type. The tax rates are as follows:

- **Import Duty**: 5% for imported items.
- **Sales Tax**:
  - 10% for other items.
  - 0% for books, food, and medical supplies.

### Rounding

Tax amounts are rounded up to the nearest 0.05 using the `RoundUpToNearest05` method to ensure that the final tax amount is always a multiple of 0.05.

## Example Usage

```csharp
var book = new Book("Rich Dad Poor Dad", false, 10.99m, 2);
var food = new Food("Avacado", true, 1.50m, 10);
var medical = new Medical("Paracetamol", false, 5.00m, 1);
var otherItem = new OtherItem("Boat Rockerz 450", true, 20.00m, 1);

Console.WriteLine($"Book Tax: {book.CalculateTax()}");  // Output: 0.00
Console.WriteLine($"Food Tax: {food.CalculateTax()}");  // Output: 0.15
Console.WriteLine($"Medical Tax: {medical.CalculateTax()}");  // Output: 0.00
Console.WriteLine($"Other Item Tax: {otherItem.CalculateTax()}");  // Output: 3.00

Installation
Clone the repository and build the project using .NET8 development environment.
git clone https://github.com/GaneshwerBalaj1/Sales-Tax-Problem
cd sales-tax-calculator
dotnet build
