using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using PetfinderNet.Converters;

namespace PetfinderNet.Models
{
    /// <summary>
    /// This class contains a list of pets.
    /// </summary>
    [PetfinderResult("pets")]
    [JsonConverter(typeof(PetListJsonConverter))]
    public class PetList : IEnumerable<Pet>
    {
        /// <summary>
        /// A list of pets.
        /// </summary>
        private readonly List<Pet> _pets = new List<Pet>();

        /// <summary>
        /// Returns the enumerator for the collection.
        /// </summary>
        /// <returns>An IEnumerator of type Pet</returns>
        public IEnumerator<Pet> GetEnumerator()
        {
            return _pets.GetEnumerator();
        }

        /// <summary>
        /// Adds a pet to the collection.
        /// </summary>
        /// <param name="pet">The pet to add.</param>
        public void Add(Pet pet)
        {
            _pets.Add(pet);
        }

        /// <summary>
        /// Returns the enumerator for the collection.
        /// </summary>
        /// <returns>The enumerator for the collection.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
