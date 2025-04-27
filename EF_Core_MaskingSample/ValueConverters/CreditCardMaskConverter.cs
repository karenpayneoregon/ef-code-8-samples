using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EF_Core_MaskingSample.ValueConverters;
public class CreditCardMaskConverter : ValueConverter<string, string>
{
    public CreditCardMaskConverter()
        : base(
            v => v, // Write to database as-is
            v => MaskCreditCard(v)) // Read from database masked
    {
    }

    private static string MaskCreditCard(string creditCard)
    {
        if (string.IsNullOrWhiteSpace(creditCard))
            return "XXXX-XXXX-XXXX-XXXX";

        var digitsOnly = new string(creditCard.Where(char.IsDigit).ToArray());

        if (digitsOnly.Length < 4)
            return "XXXX-XXXX-XXXX-XXXX";

        return $"XXXX-XXXX-XXXX-{digitsOnly[^4..]}";
    }
}