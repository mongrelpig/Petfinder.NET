using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using PetfinderNet.Extensions;
using PetfinderNet.Models;

namespace PetfinderNet.Converters
{
    /// <summary>
    /// Custom JSON converter for converting a shelter list response  to a
    /// ShelterList object.
    /// </summary>
    public class ShelterListConverter : PetfinderJsonConverter<ShelterList>
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
            var shelterList = new ShelterList();

            var shelters = json.FindList("shelter");
            foreach (var shelter in shelters)
                shelterList.Add(serializer.Deserialize<Shelter>(shelter.CreateReader()));

            return shelterList;
        }
    }
}
