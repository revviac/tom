using Tom.Core.History.Data;
using Tom.Core.Tags;

namespace Test.Core.History;

public class SnapshotCastingTest
{
    [Test]
    public void TomSnapshots_MustUnwrapToDataPoint_IfTypesAreCompatible()
    {
        // Arrange
        var timestamp = DateTimeOffset.UtcNow;

        var intSnapshot = new TomSnapshot(timestamp, 1, TagType.Int);
        var floatSnapshot = new TomSnapshot(timestamp, 1.3f, TagType.Float);
        var longSnapshot = new TomSnapshot(timestamp, 1L, TagType.Long);
        var doubleSnapshot = new TomSnapshot(timestamp, 1.3, TagType.Double);

        // Act
        var intDataPointResult = intSnapshot.Unwrap<int>();
        var floatDataPointResult = floatSnapshot.Unwrap<float>();
        var longDataPointResult = longSnapshot.Unwrap<long>();
        var doubleDataPointResult = doubleSnapshot.Unwrap<double>();

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(intDataPointResult.IsT0, Is.True);
            Assert.That(floatDataPointResult.IsT0, Is.True);
            Assert.That(longDataPointResult.IsT0, Is.True);
            Assert.That(doubleDataPointResult.IsT0, Is.True);
        });
    }

    [Test]
    public void TomSnapshots_MustUnwrapToError_OnIncompatibleTypes()
    {
        // Arrange
        var timestamp = DateTimeOffset.UtcNow;

        var snapshot = new TomSnapshot(timestamp, 1, TagType.Int);

        // Act
        var intToFloatResult = snapshot.Unwrap<float>();
        var intToDoubleResult = snapshot.Unwrap<double>();
        var intToLongResult = snapshot.Unwrap<long>();

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(intToFloatResult.IsT1, Is.True);
            Assert.That(intToDoubleResult.IsT1, Is.True);
            Assert.That(intToLongResult.IsT1, Is.True);
        });
    }

    [Test]
    public void TomSnapshots_MustCorrectlyCastValues_ForCompatibleTypes()
    {
        // Arrange
        var timestamp = DateTimeOffset.UtcNow;

        var intSnapshot = new TomSnapshot(timestamp, 1, TagType.Int);
        var floatSnapshot = new TomSnapshot(timestamp, 1.3f, TagType.Float);
        var longSnapshot = new TomSnapshot(timestamp, 1L, TagType.Long);
        var doubleSnapshot = new TomSnapshot(timestamp, 1.3, TagType.Double);

        var expectedIntDataPoint = new DataPoint<int>(timestamp, 1);
        var expectedFloatDataPoint = new DataPoint<float>(timestamp, 1.3f);
        var expectedLongDataPoint = new DataPoint<long>(timestamp, 1L);
        var expectedDoubleDataPoint = new DataPoint<double>(timestamp, 1.3);

        // Act
        var intDataPointResult = intSnapshot.Unwrap<int>();
        var floatDataPointResult = floatSnapshot.Unwrap<float>();
        var longDataPointResult = longSnapshot.Unwrap<long>();
        var doubleDataPointResult = doubleSnapshot.Unwrap<double>();

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(intDataPointResult.AsT0, Is.EqualTo(expectedIntDataPoint));
            Assert.That(floatDataPointResult.AsT0, Is.EqualTo(expectedFloatDataPoint));
            Assert.That(longDataPointResult.AsT0, Is.EqualTo(expectedLongDataPoint));
            Assert.That(doubleDataPointResult.AsT0, Is.EqualTo(expectedDoubleDataPoint));
        });
    }
}