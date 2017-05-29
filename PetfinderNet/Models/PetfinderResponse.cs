using Newtonsoft.Json;
using PetfinderNet.Converters;

namespace PetfinderNet.Models
{
    /// <summary>
    /// This class represents a response from the Petfinder API. It contains
    /// a PetfinderHeader, which is included with all responses and a result of
    /// type T that contains the results of the request.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [JsonConverter(typeof(PetfinderResponseConverter))]
    public class PetfinderResponse<T>
    {
        /// <summary>
        /// A header containing the version of the API, a status code,
        /// and a timestamp.
        /// </summary>
        public PetfinderHeader Header { get; set; }

        /// <summary>
        /// The result of the request.
        /// </summary>
        public T Result { get; set; }
    }
}
