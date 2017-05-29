using Newtonsoft.Json;
using PetfinderNet.Converters;

namespace PetfinderNet.Models
{
    /// <summary>
    /// This class represents an animal shelter.
    /// </summary>
    [PetfinderResult("shelter")]
    [JsonConverter(typeof(ShelterConverter))]
    public class Shelter
    {
        /// <summary>
        /// The country the shelter is located in.
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// The longitude of the shelter.
        /// </summary>
        public double Longitude { get; set; }

        /// <summary>
        /// The name of the shelter.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The shelter's phone number.
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// The state the shelter is located in.
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// The second line of the shelter's address.
        /// </summary>
        public string Address2 { get; set; }

        /// <summary>
        /// The shelter's email address.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// The city the shelter is located in.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// The zip code the shelter is located in.
        /// </summary>
        public string Zip { get; set; }

        /// <summary>
        /// The shelter's fax number.
        /// </summary>
        public string Fax { get; set; }

        /// <summary>
        /// The shelter's latitude.
        /// </summary>
        public double Latitude { get; set; }

        /// <summary>
        /// The ID of the shelter.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The shelter's address.
        /// </summary>
        public string Address1 { get; set; }
    }
}
