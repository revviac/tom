namespace Tom.Core.Objects.Errors;

public record TomObjectHasNoKeys(Guid ObjectId, string FriendlyName = "");