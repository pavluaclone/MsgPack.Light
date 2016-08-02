using System;
using System.Runtime.Serialization;

namespace MsgPack.Light
{
    public static class ExceptionUtils
    {
        public static Exception BadTypeException(DataTypes actual, params DataTypes[] expectedCodes)
        {
            return new SerializationException($"Got {actual:G} (0x{actual:X}), while expecting one of these: {string.Join(", ", expectedCodes)}");
        }

        public static Exception NotEnoughBytes(uint actual, uint expected)
        {
            return new SerializationException($"Expected {expected} bytes, got {actual} bytes.");
        }

        public static Exception NotEnoughBytes(int actual, int expected)
        {
            return new SerializationException($"Expected {expected} bytes, got {actual} bytes.");
        }

        public static Exception NotEnoughBytes(long actual, uint expected)
        {
            return new SerializationException($"Expected {expected} bytes, got {actual} bytes.");
        }

        public static Exception NotEnoughBytes(uint actual, long expected)
        {
            return new SerializationException($"Expected {expected} bytes, got {actual} bytes.");
        }

        public static Exception CantReadReadOnlyCollection(Type type)
        {
            return new SerializationException($"Can't deserialize into read-only collection {type.Name}. Create a specialized converter for that.");
        }

        public static Exception NoConverterForCollectionElement(Type type, string elementName)
        {
            return new SerializationException($"Provide converter for {elementName}: {type.Name}");
        }

        public static Exception IntDeserializationFailure(DataTypes type)
        {
            return new SerializationException($"Waited for an int, got {type:G} (0x{type:X})");
        }

        public static Exception IntSerializationFailture(long value)
        {
            return new SerializationException($"Can't serialize {value}");
        }

        public static Exception IntSerializationFailture(ulong value)
        {
            return new SerializationException($"Can't serialize {value}");
        }
    }
}
