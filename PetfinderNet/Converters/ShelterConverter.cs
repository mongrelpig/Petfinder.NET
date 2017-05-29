using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using PetfinderNet.Extensions;
using PetfinderNet.Models;

namespace PetfinderNet.Converters
{
    /// <summary>
    /// Custom JSON converter for converting a shelter response into a
    /// Shelter object.
    /// </summary>
    public class ShelterConverter : PetfinderJsonConverter<Shelter>
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
            var shelter = new Shelter()
            {
                Country = json.FindValue<string>("country", "$t"),
                Longitude = json.FindValue<double>("longitude", "$t"),
                Name = json.FindValue<string>("name", "$t"),
                Phone = json.FindValue<string>("phone", "$t"),
                State = json.FindValue<string>("state", "$t"),
                Address1 = json.FindValue<string>("address1", "$t"),
                Address2 = json.FindValue<string>("address2", "$t"),
                Email = json.FindValue<string>("email", "$t"),
                City = json.FindValue<string>("city", "$t"),
                Zip = json.FindValue<string>("zip", "$t"),
                Fax = json.FindValue<string>("fax", "$t"),
                Latitude = json.FindValue<double>("latitude", "$t"),
                Id = json.FindValue<string>("id", "$t")
            };
            return shelter;
        }
    }
}
