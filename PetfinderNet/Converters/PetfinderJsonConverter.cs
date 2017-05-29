using Newtonsoft.Json;
using System;

namespace PetfinderNet.Converters
{
    /// <summary>
    /// This class indicates whether or not a JsonConverter can be used
    /// to convert an object of a particular type.
    /// </summary>
    /// <typeparam name="T">The type of object supported by the converter.</typeparam>
    public abstract class PetfinderJsonConverter<T> : JsonConverter
    {
        /// <summary>
        /// Whether or not the object can be serialized.
        /// 
        /// At the moment the API does not need to serialize objects.
        /// </summary>
        public override bool CanWrite => false;

        /// <summary>
        /// Determines whether or not the converter can convert an object
        /// of the specified type.
        /// </summary>
        /// <param name="objectType">The type of the object looking to be converted.</param>
        /// <returns></returns>
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(T);
        }

        /// <summary>
        /// Writes the object to the specified JsonWriter.
        /// 
        /// At the moment the API does not need to serialize objects.
        /// </summary>
        /// <param name="writer">The JsonWriter to write to.</param>
        /// <param name="value">The object to write.</param>
        /// <param name="serializer">The serializer used to serialize the object.</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
