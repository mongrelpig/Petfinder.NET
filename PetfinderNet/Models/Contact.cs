using Newtonsoft.Json;
using PetfinderNet.Converters;

namespace PetfinderNet.Models
{
    /// <summary>
    /// This class represents a contact for a pet.
    /// </summary>
    [JsonConverter(typeof(ContactConverter))]
    public class Contact
    {
        /// <summary>
        /// The phone number of the contact.
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// The state the contact lives in.
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// The contact's email address.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// The city the contact lives in.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// The contact's second address line.
        /// </summary>
        public string Address2 { get; set; }

        /// <summary>
        /// The contact's Zip code.
        /// </summary>
        public string Zip { get; set; }

        /// <summary>
        /// The contact's fax number.
        /// </summary>
        public string Fax { get; set; }
        
        /// <summary>
        /// The contact's address.
        /// </summary>
        public string Address1 { get; set; }
    }
}
