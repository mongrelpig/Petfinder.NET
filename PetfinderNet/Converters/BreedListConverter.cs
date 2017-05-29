using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using PetfinderNet.Extensions;
using PetfinderNet.Models;

namespace PetfinderNet.Converters
{
    /// <summary>
    /// Custom JSON converter for converting a breed list response to
    /// a BreedList object.
    /// </summary>
    public class BreedListConverter : PetfinderJsonConverter<BreedList>
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
            var breeds = new BreedList {Animal = json.FindValue<string>("@animal")};

            var breedList = json.FindList("breed");
            foreach (var breed in breedList)
                breeds.Breeds.Add(breed.FindValue<string>("$t"));

            return breeds;
        }
    }
}
