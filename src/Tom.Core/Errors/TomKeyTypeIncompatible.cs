using Tom.Core.Tags;

namespace Tom.Core.Errors;

public record TomKeyTypeIncompatible(string KeyName, string SerializedValue, TagType ExpectedType);