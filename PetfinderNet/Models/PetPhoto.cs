using System;
using Newtonsoft.Json;
using PetfinderNet.Converters;

namespace PetfinderNet.Models
{
    /// <summary>
    /// This class contains information about a pet's
    /// photograph.
    /// </summary>
    [JsonConverter(typeof(PetPhotoConverter))]
    public class PetPhoto
    {
        /// <summary>
        /// The URL to the photo.
        /// </summary>
        public Uri Url { get; set; }

        /// <summary>
        /// The size of the photo (width x height).
        /// </summary>
        public string Size { get; set; }

        /// <summary>
        /// The ID of the photo.
        /// </summary>
        public int Id { get; set; }
    }
}
