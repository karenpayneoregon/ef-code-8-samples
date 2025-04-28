using Microsoft.AspNetCore.DataProtection;

namespace EF_Core_MaskingSample1.Classes;

/// <summary>
/// Provides encryption and decryption services for sensitive data using data protection.
/// </summary>
/// <remarks>
/// This class utilizes <see cref="IDataProtectionProvider"/> to create a data protector
/// for encrypting and decrypting sensitive information such as credit card details.
/// </remarks>
public class EncryptionService(IDataProtectionProvider provider)
{
    private readonly IDataProtector _protector = provider.CreateProtector("CreditCardProtection");

    /// <summary>
    /// Encrypts the specified input string using the data protection mechanism.
    /// </summary>
    /// <param name="input">
    /// The plain text string to be encrypted. If the input is <c>null</c> or whitespace, 
    /// an empty string is returned.
    /// </param>
    /// <returns>
    /// The encrypted string. If the input is <c>null</c> or whitespace, an empty string is returned.
    /// </returns>
    /// <remarks>
    /// This method uses the <see cref="IDataProtector.Protect"/> method to securely encrypt the input.
    /// </remarks>
    public string Encrypt(string input) => string.IsNullOrWhiteSpace(input) ? string.Empty : _protector.Protect(input);

    /// <summary>
    /// Decrypts the specified encrypted string using the data protection mechanism.
    /// </summary>
    /// <param name="input">
    /// The encrypted string to be decrypted. If the input is <c>null</c> or whitespace, 
    /// an empty string is returned.
    /// </param>
    /// <returns>
    /// The decrypted plain text string. If the input is <c>null</c> or whitespace, an empty string is returned.
    /// </returns>
    /// <remarks>
    /// This method uses the <see cref="IDataProtector.Unprotect"/> method to securely decrypt the input.
    /// </remarks>
    public string Decrypt(string input) => string.IsNullOrWhiteSpace(input) ? string.Empty : _protector.Unprotect(input);
}