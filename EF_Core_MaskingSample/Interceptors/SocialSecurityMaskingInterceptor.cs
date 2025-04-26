using EF_Core_MaskingSample.Models;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace EF_Core_MaskingSample.Interceptors;

/// <summary>
/// Represents an interceptor that masks the social security numbers of <see cref="Person"/> entities
/// during the materialization process in Entity Framework Core.
/// </summary>
/// <remarks>
/// This interceptor ensures that the social security number is partially masked, displaying only
/// the last four digits, while the rest is replaced with "XXX-XX-". If the social security number
/// is null or shorter than four characters, it defaults to "XXX-XX-XXXX".
/// </remarks>
public class SocialSecurityMaskingInterceptor : IMaterializationInterceptor
{
    /// <summary>
    /// Initializes an entity instance during the materialization process in Entity Framework Core.
    /// </summary>
    /// <param name="materializationData">
    /// The <see cref="MaterializationInterceptionData"/> containing context and metadata about the materialization process.
    /// </param>
    /// <param name="entity">
    /// The entity instance being materialized.
    /// </param>
    /// <returns>
    /// The modified entity instance with the social security number masked, if applicable.
    /// </returns>
    /// <remarks>
    /// This method checks if the entity being materialized is of type <see cref="Person"/>. If so, it masks the
    /// social security number by replacing all but the last four digits with "XXX-XX-". If the social security
    /// number is null or shorter than four characters, it defaults to "XXX-XX-XXXX".
    /// </remarks>
    public object InitializedInstance(MaterializationInterceptionData materializationData, object entity)
    {
        if (entity is not Person person) return entity;
        if (!string.IsNullOrEmpty(person.SocialSecurity) && person.SocialSecurity.Length >= 4)
        {
            person.SocialSecurity = $"XXX-XX-{person.SocialSecurity[^4..]}";
        }
        else
        {
            person.SocialSecurity = "XXX-XX-XXXX";
        }

        return entity;
    }
}