using Newtonsoft.Json;
using PetfinderNet.Converters;
using System.Collections;
using System.Collections.Generic;

namespace PetfinderNet.Models
{
    /// <summary>
    /// This class contains a list of shelters.
    /// </summary>
    [PetfinderResult("shelters")]
    [JsonConverter(typeof(ShelterListConverter))]
    public class ShelterList : IEnumerable<Shelter>
    {
        /// <summary>
        /// A list of shelters.
        /// </summary>
        private readonly List<Shelter> _shelters = new List<Shelter>();

        /// <summary>
        /// Returns the enumerator for the collection.
        /// </summary>
        /// <returns>An IEnumerator of type Shelter</returns>
        public IEnumerator<Shelter> GetEnumerator()
        {
            return _shelters.GetEnumerator();
        }

        /// <summary>
        /// Adds a shelter to the collection.
        /// </summary>
        /// <param name="shelter">The shelter to add.</param>
        public void Add(Shelter shelter)
        {
            _shelters.Add(shelter);
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
