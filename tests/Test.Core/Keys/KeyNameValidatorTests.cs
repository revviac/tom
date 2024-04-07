using Tom.Core.Keys.Validation;

namespace Test.Core.Keys;

using static KeyNameValidator;
using static InvalidKeyNameReasons;

public class KeyNameValidatorTests
{
    [Test]
    public void KeyNameValidator_ReturnsSuccess_OnValidKeyNames()
    {
        var validNames = new string[]
        {
            "key",
            "Key",
            "kEy",
            "_key",
            "__key",
            "key_key",
            "key1",
            "key_1"
        };
        var results = validNames.Select(ValidateKeyName).ToArray();

        for (int i = 0; i < validNames.Length; i++)
        {
            Assert.That(results[i].IsT0, Is.True);
        }
    }

    [Test]
    public void KeyNameValidator_ReturnsError_OnEmptyName()
    {
        var expectedReason = EmptyName;

        var result = ValidateKeyName("");

        Assert.Multiple(() =>
        {
            Assert.That(result.IsT1, Is.True);
            Assert.That(result.AsT1.Reason, Is.EqualTo(expectedReason));
        });
    }

    [Test]
    public void KeyNameValidator_ReturnsError_OnNameThatExceedsMaximumAllowedLength()
    {
        var keySize = MaxAllowedKeyLength + 1;
        var keyName = new string('a', keySize);
        var expectedReason = ExceededMaximumAllowedLength(keySize, MaxAllowedKeyLength);

        var result = ValidateKeyName(keyName);

        Assert.Multiple(() =>
        {
            Assert.That(result.IsT1, Is.True);
            Assert.That(result.AsT1.Reason, Is.EqualTo(expectedReason));
        });
    }

    [Test]
    public void KeyNameValidator_ReturnsError_OnEncounteredWhitespace()
    {
        var keyName = "my key";
        var expectedReason = EncounteredWhitespace(2);

        var result = ValidateKeyName(keyName);

        Assert.Multiple(() =>
        {
            Assert.That(result.IsT1, Is.True);
            Assert.That(result.AsT1.Reason, Is.EqualTo(expectedReason));
        });
    }

    [Test]
    public void KeyNameValidator_ReturnsError_OnBlacklistedSpecialCharacters()
    {
        var invalidNames = new string[]
        {
            "!key",
            "k@ey",
            "key.",
            "key,key,key",
            "áccéñts_are_not_allowed"
        };
        var expectedReasons = new string[]
        {
            EncounteredSpecialCharacter(0, '!'),
            EncounteredSpecialCharacter(1, '@'),
            EncounteredSpecialCharacter(3, '.'),
            EncounteredSpecialCharacter(3, ','),
            EncounteredSpecialCharacter(0, 'á')
        };

        var results = invalidNames.Select(ValidateKeyName).ToArray();

        for (int i = 0; i < invalidNames.Length; i++)
        {
            Assert.Multiple(() =>
            {
                Assert.That(results[i].IsT1, Is.True);
                Assert.That(results[i].AsT1.Reason, Is.EqualTo(expectedReasons[i]));
            });
        }
    }

    [Test]
    public void KeyNameValidator_ReturnsError_IfFirstCharacterIsADigit()
    {
        var invalidNames = Enumerable.Range(0, 9).Select(i => $"{i}key").ToArray();
        var expectedReason = FirstCharacterCannotBeADigit;

        var results = invalidNames.Select(ValidateKeyName).ToArray();

        for (int i = 0; i < invalidNames.Length; i++)
        {
            Assert.Multiple(() =>
            {
                Assert.That(results[i].IsT1, Is.True);
                Assert.That(results[i].AsT1.Reason, Is.EqualTo(expectedReason));
            });
        }
    }
}