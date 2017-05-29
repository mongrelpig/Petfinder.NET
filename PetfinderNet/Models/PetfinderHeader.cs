using System;
using Newtonsoft.Json;
using PetfinderNet.Converters;

namespace PetfinderNet.Models
{
    /// <summary>
    /// This class contains information from the header of a Petfinder response.
    /// This header is included in all responses.
    /// </summary>
    [PetfinderResult("header")]
    [JsonConverter(typeof(HeaderConverter))]
    public class PetfinderHeader
    {
        /// <summary>
        /// The version of the API.
        /// </summary>
        public string Version { get; set; }
        
        /// <summary>
        /// The date and time that the response was sent.
        /// </summary>
        public DateTimeOffset Timestamp { get; set; }

        /// <summary>
        /// The status of the response.
        /// </summary>
        public PetfinderStatus Status { get; set; }
    }
}
