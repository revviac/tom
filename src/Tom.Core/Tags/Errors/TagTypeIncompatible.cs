namespace Tom.Core.Tags.Errors;

public record TagTypeIncompatible(
    string SerializedValue,
    TagType ExpectedType,
    Guid TagId = default,
    Guid ServerId = default,
    string TagFriendlyName = "",
    string ServerFriendlyName = "");