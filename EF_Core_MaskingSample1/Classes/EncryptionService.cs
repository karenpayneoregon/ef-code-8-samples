using Microsoft.AspNetCore.DataProtection;

namespace EF_Core_MaskingSample1.Classes;

public class EncryptionService(IDataProtectionProvider provider)
{
    private readonly IDataProtector _protector = provider.CreateProtector("CreditCardProtection");

    public string Encrypt(string input)
    {
        return string.IsNullOrWhiteSpace(input) ? string.Empty : _protector.Protect(input);
    }

    public string Decrypt(string input)
    {
        return string.IsNullOrWhiteSpace(input) ? string.Empty : _protector.Unprotect(input);
    }
}