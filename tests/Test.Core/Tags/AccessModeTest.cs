using Tom.Core.Tags;

namespace Test.Core.Tags;

/// <summary>
///     Sanity checks for AccessMode flags
/// </summary>
public class AccessModeTest
{
    [Test]
    public void AccessMode_ReadWrite_IsReadable()
    {
        Assert.That(AccessMode.ReadWrite.IsReadable(), Is.True);
    }

    [Test]
    public void AccessMode_ReadWrite_IsWriteable()
    {
        Assert.That(AccessMode.ReadWrite.IsWriteable(), Is.True);
    }

    [Test]
    public void AccessMode_ReadWrite_IsNotWriteOnly()
    {
        Assert.That(AccessMode.ReadWrite.IsWriteOnly(), Is.False);
    }

    [Test]
    public void AccessMode_ReadWrite_IsNotReadOnly()
    {
        Assert.That(AccessMode.ReadWrite.IsReadOnly(), Is.False);
    }

    [Test]
    public void AccessMode_ReadWrite_IsUnionOfReadableAndWriteable()
    {
        Assert.That(AccessMode.Readable | AccessMode.Writeable, Is.EqualTo(AccessMode.ReadWrite));
    }

    [Test]
    public void AccessMode_Readable_IsReadOnly()
    {
        Assert.That(AccessMode.Readable.IsReadOnly(), Is.True);
    }

    [Test]
    public void AccessMode_Readable_IsNotWriteable()
    {
        Assert.That(AccessMode.Readable.IsWriteable(), Is.False);
    }

    [Test]
    public void AccessMode_Readable_IsNotWriteOnly()
    {
        Assert.That(AccessMode.Readable.IsWriteOnly(), Is.False);
    }

    [Test]
    public void AccessMode_Writeable_IsWriteOnly()
    {
        Assert.That(AccessMode.Writeable.IsWriteOnly(), Is.True);
    }

    [Test]
    public void AccessMode_Writeable_IsNotReadable()
    {
        Assert.That(AccessMode.Writeable.IsReadable(), Is.False);
    }

    [Test]
    public void AccessMode_Writeable_IsNotReadOnly()
    {
        Assert.That(AccessMode.Writeable.IsReadOnly(), Is.False);
    }
}