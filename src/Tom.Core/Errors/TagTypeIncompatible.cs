using Tom.Core.Tags;

namespace Tom.Core.Errors;

public record TagTypeIncompatible(string SerializedValue, TagType ExpectedType, string TagName = "", string ServerFriendlyName = "");