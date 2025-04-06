namespace WebApplication1.Classes;

public class DataOperations
{
    /// <summary>
    /// Simulates removing a customer with the specified identifier from the data source.
    /// </summary>
    /// <param name="id">The unique identifier of the customer to be removed.</param>
    /// <returns>
    /// <c>true</c> if the customer was successfully removed; otherwise, <c>false</c>.
    /// </returns>
    public static bool RemoveCustomer(int id) => true;

    public static void ArchiveOrder(int itemId)
    {
        Console.WriteLine($"Order {itemId} archived.");
    }
}
