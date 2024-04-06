using System.Runtime.CompilerServices;
using OneOf;
using OneOf.Types;
using Tom.Core.Errors;

namespace Tom.Core.Keys.Validation;

/// <summary>
///     A helper class that can be used to validate key names
/// </summary>
public static class KeyNameValidator
{
    /// <summary>
    ///     Long key names should be discouraged - if the key length is more than
    /// </summary>
    public const short MaxAllowedKeyLength = 255;

    /// <summary>
    ///     If the key name contains special characters (aside from the underscore _), starts with a digit
    ///     or has letters from any alphabet aside english, it's considered invalid for compatibility reasons.
    ///     Example of valid key names: "key123", "_key123", "my_key_Name", etc. Examples of invalid names:
    ///     "1istartwithadigit", "i contain spaces", "this!has@bad,separators", "áccéñts_are_not_allowed", "" (empty),
    ///     "someverylongkeynameaaaaa(...)aaa" (more than 255 characters long), etc.
    /// </summary>
    /// <param name="keyName">Key name to validate</param>
    /// <returns>Success if the key is valid, otherwise TomKeyInvalid with a reason is returned</returns>
    public static OneOf<Success, TomKeyNameInvalid> ValidateKeyName(string keyName)
    {
        int numCharacters = keyName.Length;

        if (numCharacters == 0)
        {
            return new TomKeyNameInvalid(keyName, InvalidKeyNameReasons.EmptyName);
        }

        if (numCharacters > MaxAllowedKeyLength)
        {
            return new TomKeyNameInvalid(keyName, InvalidKeyNameReasons.ExceededMaximumAllowedLength(numCharacters, MaxAllowedKeyLength));
        }

        char symbol = keyName[0];
        if (symbol is >= '0' and <= '9')
        {
            return new TomKeyNameInvalid(keyName, InvalidKeyNameReasons.FirstCharacterCannotBeADigit);
        }

        if (!symbol.IsWhitelisted())
        {
            return new TomKeyNameInvalid(keyName, InvalidKeyNameReasons.EncounteredSpecialCharacter(0, symbol));
        }

        for (int position = 1; position < numCharacters; position++)
        {
            symbol = keyName[position];
            if (symbol == ' ')
            {
                return new TomKeyNameInvalid(keyName, InvalidKeyNameReasons.EncounteredWhitespace(position));
            }

            if (symbol.IsWhitelisted())
            {
                continue;
            }

            return new TomKeyNameInvalid(keyName, InvalidKeyNameReasons.EncounteredSpecialCharacter(position, symbol));
        }

        return new Success();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static bool IsWhitelisted(this char symbol)
    {
        // Only allow an underscore, digits and english characters
        return symbol is '_' or (>= '0' and <= '9') or (>= 'a' and <= 'z') or (>= 'A' and <= 'Z');
    }
}