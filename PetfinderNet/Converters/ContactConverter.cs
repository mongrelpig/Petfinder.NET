using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using PetfinderNet.Extensions;
using PetfinderNet.Models;

namespace PetfinderNet.Converters
{
    /// <summary>
    /// Custom JSON converter for converting a contact response
    /// to a Contact object.
    /// </summary>
    public class ContactConverter : PetfinderJsonConverter<Contact>
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
            var contact = new Contact()
            {
                Phone = json.FindValue<string>("phone", "$t"),
                State = json.FindValue<string>("state", "$t"),
                Address2 = json.FindValue<string>("address2", "$t"),
                Email = json.FindValue<string>("email", "$t"),
                City = json.FindValue<string>("city", "$t"),
                Zip = json.FindValue<string>("zip", "$t"),
                Fax = json.FindValue<string>("fax", "$t"),
                Address1 = json.FindValue<string>("address1", "$t")
            };
            return contact;
        }
    }
}
