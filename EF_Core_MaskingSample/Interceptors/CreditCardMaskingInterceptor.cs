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
    /// Initializes an entity instance during the materialization process in Entity Framework Core,
    /// applying specific logic for masking sensitive data.
    /// </summary>
    /// <param name="materializationData">
    /// Provides contextual information about the materialization process, including the entity type
    /// and the associated <see cref="Microsoft.EntityFrameworkCore.DbContext"/>.
    /// </param>
    /// <param name="entity">
    /// The entity instance being materialized. If the entity is of type <see cref="Person"/>,
    /// its credit card number is masked to display only the last four digits.
    /// </param>
    /// <returns>
    /// The initialized entity instance. For <see cref="Person"/> entities, the credit card number
    /// is masked. For other entity types, the instance is returned without modification.
    /// </returns>
    /// <remarks>
    /// This method ensures that credit card numbers in <see cref="Person"/> entities are masked
    /// for security purposes. If the credit card number is null or shorter than four characters,
    /// it defaults to "XXXX-XXXX-XXXX-XXXX".
    /// </remarks>
    public object InitializedInstance(MaterializationInterceptionData materializationData, object entity)
    {
        if (entity is not Person person)
            return entity;

        if (!string.IsNullOrEmpty(person.CreditCard) && person.CreditCard.Length >= 4)
        {
            // Mask all but the last 4 digits
            person.CreditCard = $"XXXX-XXXX-XXXX-{person.CreditCard[^4..]}";
        }
        else
        {
            person.CreditCard = "XXXX-XXXX-XXXX-XXXX";
        }

        return entity;
    }
}