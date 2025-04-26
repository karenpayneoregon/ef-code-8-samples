using EF_Core_MaskingSample.Models;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace EF_Core_MaskingSample.Interceptors;

/// <summary>
/// Represents an interceptor that masks the credit card numbers of <see cref="Person"/> entities
/// during the materialization process in Entity Framework Core.
/// </summary>
/// <remarks>
/// This interceptor ensures that credit card numbers are partially masked, displaying only
/// the last four digits, while the rest is replaced with "****-****-****-". If the credit card
/// number is null or shorter than four characters, it defaults to "****-****-****-****".
/// </remarks>
public class CreditCardMaskingInterceptor : IMaterializationInterceptor
{
    /// <summary>
    /// Initializes an entity instance during the materialization process in Entity Framework Core.
    /// </summary>
    /// <param name="materializationData">
    /// Contains contextual information about the materialization process, such as the entity type and the DbContext.
    /// </param>
    /// <param name="entity">
    /// The entity instance being materialized. This is typically an instance of a class mapped to a database table.
    /// </param>
    /// <returns>
    /// The initialized entity instance. If the entity is of type <see cref="Person"/>, the credit card number
    /// is masked to display only the last four digits. Otherwise, the entity is returned as-is.
    /// </returns>
    /// <remarks>
    /// This method is specifically designed to handle <see cref="Person"/> entities by masking their credit card numbers.
    /// If the credit card number is null or shorter than four characters, it defaults to "****-****-****-****".
    /// </remarks>
    public object InitializedInstance(MaterializationInterceptionData materializationData, object entity)
    {
        if (entity is not Person person)
            return entity;

        if (!string.IsNullOrEmpty(person.CreditCard) && person.CreditCard.Length >= 4)
        {
            // Mask all but the last 4 digits
            person.CreditCard = $"****-****-****-{person.CreditCard[^4..]}";
        }
        else
        {
            person.CreditCard = "****-****-****-****";
        }

        return entity;
    }
}