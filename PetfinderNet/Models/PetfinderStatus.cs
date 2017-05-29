using Newtonsoft.Json;
using PetfinderNet.Converters;

namespace PetfinderNet.Models
{
    /// <summary>
    /// This class represents the status of a Petfinder response.
    /// It contains the status code and an optional message explaining the code.
    /// </summary>
    [JsonConverter(typeof(StatusConverter))]
    public class PetfinderStatus
    {
        /// <summary>
        /// The status code of the response.
        /// </summary>
        public PetfinderStatusCodes Code { get; set; }

        /// <summary>
        /// An optional message describing the code.
        /// </summary>
        public string Message { get; set; }
    }
}
