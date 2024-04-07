using Tom.Core.Tags;

namespace Test.Core.Tags;

using static TagTypeValidator;

public class TagTypeValidatorTest
{
    [Test]
    public void TagTypeValidator_TagTypeFloat_IsCompatibleWithFloat()
    {
        Assert.That(TypesCompatible(typeof(float), TagType.Float), Is.True);
    }

    [Test]
    public void TagTypeValidator_TagTypeDouble_IsCompatibleWithDouble()
    {
        Assert.That(TypesCompatible(typeof(double), TagType.Double), Is.True);
    }

    [Test]
    public void TagTypeValidator_TagTypeInt_IsCompatibleWithInt()
    {
        Assert.That(TypesCompatible(typeof(int), TagType.Int), Is.True);
    }

    [Test]
    public void TagTypeValidator_TagTypeLong_IsCompatibleWithLong()
    {
        Assert.That(TypesCompatible(typeof(long), TagType.Long), Is.True);
    }
}