using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PetfinderNet.Models;
using System;
using System.Reflection;
using PetfinderNet.Extensions;

namespace PetfinderNet.Converters
{
    /// <summary>
    /// Custom JSON converter for converting a response from the API
    /// into a PetfinderResponse object.
    /// </summary>
    public class PetfinderResponseConverter : JsonConverter
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
            return objectType == typeof(PetfinderResponse<>);
        }

        /// <summary>
        /// Reads the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The JsonReader to read from.</param>
        /// <param name="objectType">Type of the object.</param>
        /// <param name="existingValue">The existing value of object being read.</param>
        /// <param name="serializer">The calling serializer.</param>
        /// <returns></returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            //Create generic result
            var responseType = typeof(PetfinderResponse<>);
            var genericType = objectType.GenericTypeArguments[0];
            dynamic response = Activator.CreateInstance(responseType.MakeGenericType(genericType));

            //Load the JSON
            var json = JObject.Load(reader);

            //Parse the header
            response.Header = serializer.Deserialize<PetfinderHeader>(json.FindToken("petfinder", "header").CreateReader());

            //Get the name of the element that contains the payload
            var propertyName = genericType.GetTypeInfo().GetCustomAttribute<PetfinderResultAttribute>().PropertyName;

            //Deserialize the generic object
            dynamic result = Convert.ChangeType(serializer.Deserialize(json.FindToken("petfinder", propertyName).CreateReader(), genericType), genericType);
            response.Result = result;

            return response;
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
