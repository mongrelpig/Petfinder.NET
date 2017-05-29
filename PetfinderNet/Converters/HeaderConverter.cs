using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using PetfinderNet.Extensions;
using PetfinderNet.Models;

namespace PetfinderNet.Converters
{
    /// <summary>
    /// Custom JSON converter for converting the header of a response
    /// to a PetfinderHeader object.
    /// </summary>
    public class HeaderConverter : PetfinderJsonConverter<PetfinderHeader>
    {
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
            var json = JObject.Load(reader);
            var header = new PetfinderHeader()
            {
                Timestamp = DateTimeOffset.Parse(json.FindValue<string>("timestamp", "$t")),
                Version = json.FindValue<string>("version", "$t"),
                Status = serializer.Deserialize<PetfinderStatus>(json.FindToken("status").CreateReader())
            };
            return header;
        }
    }
}
