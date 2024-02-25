namespace NorthWind2024StarterApp.Models;

#pragma warning disable CS8602, CS8634, CS8618
public record ProductItem(string ProductName, Category Category, decimal? UnitPrice, short Quantity);