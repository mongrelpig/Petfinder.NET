using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using PetfinderNet.Extensions;
using PetfinderNet.Models;

namespace PetfinderNet.Converters
{
    /// <summary>
    /// Custom JSON converter for converting a pet response
    /// to a Pet object.
    /// </summary>
    public class PetConverter : PetfinderJsonConverter<Pet>
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
            var pet = new Pet();

            var options = json.FindList("options", "option");
            foreach (var option in options)
                pet.Options.Add(option.FindValue<string>("$t"));

            var photos = json.FindList("media", "photos", "photo");
            foreach (var photo in photos)
                pet.Photos.Add(serializer.Deserialize<PetPhoto>(photo.CreateReader()));

            var breeds = json.FindList("breeds", "breed");
            foreach (var breed in breeds)
                pet.Breeds.Add(breed.FindValue<string>("$t"));

            pet.Status = ParsePetStatus(json.FindValue<string>("status", "$t"));
            pet.Age = json.FindValue<string>("age", "$t");
            pet.Size = json.FindValue<string>("size", "$t");
            pet.Contact = serializer.Deserialize<Contact>(json.FindToken("contact").CreateReader());
            pet.Id = json.FindValue<long>("id", "$t");
            pet.ShelterPetId = json.FindValue<string>("shelterPetId", "id");
            pet.Name = json.FindValue<string>("name", "$t");
            pet.Sex = ParsePetSex(json.FindValue<string>("sex", "$t"));
            pet.Description = json.FindValue<string>("description", "$t");
            pet.IsMix = json.FindValue<string>("mix", "$t") == "yes";
            pet.ShelterId = json.FindValue<string>("shelterId", "$t");
            pet.LastUpdated = DateTimeOffset.Parse(json.FindValue<string>("lastUpdate", "$t"));
            pet.Animal = json.FindValue<string>("animal", "$t");

            return pet;
        }

        /// <summary>
        /// Parses a string representation of a pet's sex into
        /// an enum representation.
        /// </summary>
        /// <param name="sex">The sex of the pet (M or F)</param>
        /// <returns>The enum matching the pet's sex</returns>
        private Sex ParsePetSex(string sex)
        {
            return sex == "M" ? Sex.Male : Sex.Female;
        }

        /// <summary>
        /// Parses a string representation of a pet's status into
        /// an enum representation.
        /// </summary>
        /// <param name="status">The status of the pet:
        /// A - Adoptable
        /// H - On hold
        /// P - Pending adoption
        /// X - Removed
        /// </param>
        /// <returns>The enum matching the pet's status</returns>
        private PetStatus ParsePetStatus(string status)
        {
            switch (status)
            {
                case "A":
                    return PetStatus.Adoptable;
                case "H":
                    return PetStatus.Hold;
                case "P":
                    return PetStatus.Pending;
                default:
                    return PetStatus.Removed;
            }
        }
    }
}
