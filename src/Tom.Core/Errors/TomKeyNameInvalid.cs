namespace Tom.Core.Errors;

public record TomKeyNameInvalid(string Name, string Reason = "");