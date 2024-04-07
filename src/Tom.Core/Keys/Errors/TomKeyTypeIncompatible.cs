using Tom.Core.Tags;

namespace Tom.Core.Keys.Errors;

public record TomKeyTypeIncompatible(string KeyName, string SerializedValue, TagType ExpectedType);