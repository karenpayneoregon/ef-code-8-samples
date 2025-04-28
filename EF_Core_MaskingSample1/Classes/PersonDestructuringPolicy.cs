using EF_Core_MaskingSample1.Models;
using Serilog.Core;
using Serilog.Events;

namespace EF_Core_MaskingSample1.Classes;

/// <summary>
/// Defines a custom destructuring policy for handling objects of type <see cref="Person"/>.
/// </summary>
/// <remarks>
/// This class customizes the way <see cref="Person"/> objects are logged by Serilog.
/// It extracts specific properties such as <c>FirstName</c>, <c>LastName</c>, and <c>CreditCard</c> for structured logging.
/// </remarks>
public class PersonDestructuringPolicy : IDestructuringPolicy
{
    public bool TryDestructure(object value, ILogEventPropertyValueFactory propertyValueFactory, out LogEventPropertyValue result)
    {
        if (value is Person p)
        {
            result = propertyValueFactory.CreatePropertyValue(
                new
                {
                    p.FirstName, 
                    p.LastName, 
                    p.MaskedCreditCard
                });
            return true;
        }

        result = null!;
        return false;
    }
}