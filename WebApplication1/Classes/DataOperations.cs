using Serilog;

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

    /// <summary>
    /// Archives an order with the specified identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the order to be archived.</param>
    public static void ArchiveOrder(int id)
    {
        Log.Information("Order number '{P1}' archived.",id);
    }
}
