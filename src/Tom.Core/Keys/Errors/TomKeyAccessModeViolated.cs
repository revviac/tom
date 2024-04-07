using Tom.Core.Tags;

namespace Tom.Core.Keys.Errors;

public record TomKeyAccessModeViolated(
    Guid ObjectId,
    string KeyName,
    AccessMode TagMode,
    AccessOperation Operation);