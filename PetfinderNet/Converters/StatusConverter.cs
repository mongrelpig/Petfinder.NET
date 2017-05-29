using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using PetfinderNet.Extensions;
using PetfinderNet.Models;

namespace PetfinderNet.Converters
{
    /// <summary>
    /// Custom JSON converter for converting a response's status into a
    /// PetfinderStatus object.
    /// </summary>
    public class StatusConverter : PetfinderJsonConverter<PetfinderStatus>
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
            var status = new PetfinderStatus()
            {
                Code = (PetfinderStatusCodes)json.FindValue<int>("code", "$t"),
                Message = json.FindValue<string>("message", "$t")
            };
            return status;
        }
    }
}
