namespace Tom.Core.Servers.Errors;

public record TagServerNotFound(Guid ServerId, string FriendlyName = "");