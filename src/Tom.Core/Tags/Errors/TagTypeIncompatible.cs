namespace Tom.Core.Tags.Errors;

public record TagTypeIncompatible(string SerializedValue, TagType ExpectedType, string TagName = "", string ServerFriendlyName = "");