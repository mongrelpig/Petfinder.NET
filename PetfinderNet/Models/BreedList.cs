using Newtonsoft.Json;
using PetfinderNet.Converters;
using System.Collections.Generic;

namespace PetfinderNet.Models
{
    /// <summary>
    /// This class represents a list of breeds.
    /// </summary>
    [PetfinderResult("breeds")]
    [JsonConverter(typeof(BreedListConverter))]
    public class BreedList
    {
        /// <summary>
        /// The animal that breeds are being listed for.
        /// </summary>
        public string Animal { get; set; }

        /// <summary>
        /// A list of breeds for the animal.
        /// </summary>
        public IList<string> Breeds { get; set; }

        /// <summary>
        /// Creates a new BreedList.
        /// </summary>
        public BreedList()
        {
            Breeds = new List<string>();
        }
    }
}
