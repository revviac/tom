namespace Tom.Core.Objects.Errors;

public record TomObjectContainsDuplicateKeys(Guid ObjectId, string KeyName, string ObjectFriendlyName = "");