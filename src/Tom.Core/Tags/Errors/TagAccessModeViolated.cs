namespace Tom.Core.Tags.Errors;

public record TagAccessModeViolated(
    Guid TagId,
    AccessMode AccessMode,
    AccessOperation Operation,
    string FriendlyName = "");