using Newtonsoft.Json;
using PetfinderNet.Converters;
using System;
using System.Collections.Generic;

namespace PetfinderNet.Models
{
    /// <summary>
    /// This class represents a pet.
    /// </summary>
    [PetfinderResult("pet")]
    [JsonConverter(typeof(PetConverter))]
    public class Pet
    {
        /// <summary>
        /// The ID of the pet.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// The adoption status of the pet.
        /// </summary>
        public PetStatus Status { get; set; }

        /// <summary>
        /// A list of options for the pet.
        /// </summary>
        public IList<string> Options { get; set; }

        /// <summary>
        /// The age of the pet.
        /// </summary>
        public string Age { get; set; }

        /// <summary>
        /// The size of the pet.
        /// </summary>
        public string Size { get; set; }

        /// <summary>
        /// A list of photos of the pet.
        /// </summary>
        public IList<PetPhoto> Photos { get; set; }

        /// <summary>
        /// The contact for the pet.
        /// </summary>
        public Contact Contact { get; set; }

        /// <summary>
        /// The name of the pet.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The sex of the pet.
        /// </summary>
        public Sex Sex { get; set; }

        /// <summary>
        /// A list of breeds that describe the pet.
        /// </summary>
        public IList<string> Breeds { get; set; }

        /// <summary>
        /// The ID of the pet relative to the shelter it belongs to.
        /// </summary>
        public string ShelterPetId { get; set; }

        /// <summary>
        /// A description of the pet.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Whether or not the pet is a mixed breed.
        /// </summary>
        public bool IsMix { get; set; }

        /// <summary>
        /// The ID of the shelter the pet belongs to.
        /// </summary>
        public string ShelterId { get; set; }

        /// <summary>
        /// The last date and time that the pet was updated.
        /// </summary>
        public DateTimeOffset LastUpdated { get; set; }

        /// <summary>
        /// The type of animal that the pet is.
        /// </summary>
        public string Animal { get; set; }

        /// <summary>
        /// Creates a new Pet.
        /// </summary>
        public Pet()
        {
            Breeds = new List<string>();
            Options = new List<string>();
            Photos = new List<PetPhoto>();
        }
    }
}
