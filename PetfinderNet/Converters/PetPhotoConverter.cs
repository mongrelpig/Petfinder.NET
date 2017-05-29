using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using PetfinderNet.Extensions;
using PetfinderNet.Models;

namespace PetfinderNet.Converters
{
    /// <summary>
    /// Custom JSON converter for converting a pet photo response into
    /// a PetPhoto object.
    /// </summary>
    public class PetPhotoConverter : PetfinderJsonConverter<PetPhoto>
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
            var photo = new PetPhoto()
            {
                Id = json.FindValue<int>("@id"),
                Size = json.FindValue<string>("@size"),
                Url = new Uri(json.FindValue<string>("$t"))
            };
            return photo;
        }
    }
}
