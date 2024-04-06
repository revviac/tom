namespace Tom.Core.History;

/// <summary>
///     Represents a data point of a history snapshot
/// </summary>
/// <param name="Timestamp">Timestamp the snapshot has been taken at</param>
/// <param name="Value">Snapshot value</param>
/// <typeparam name="T">Snapshot value type</typeparam>
public record DataPoint<T>(DateTimeOffset Timestamp, T Value);