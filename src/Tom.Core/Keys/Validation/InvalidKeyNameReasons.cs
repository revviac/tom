namespace Tom.Core.Keys.Validation;

public static class InvalidKeyNameReasons
{
    public const string EmptyName = "The key name is empty";

    public const string FirstCharacterCannotBeADigit = "The first character of the key name cannot be a digit";

    public static string ExceededMaximumAllowedLength(int length, int allowedLength) =>
        $"The key name's length ({length}) has exceeded the maximum allowed length ({allowedLength})";

    public static string EncounteredSpecialCharacter(int position, char symbol) =>
        $"Encountered a blacklisted special character {symbol} at the position {position}";

    public static string EncounteredWhitespace(int position) =>
        $"Encountered a whitespace at the position {position}";
}