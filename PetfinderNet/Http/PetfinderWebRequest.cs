using Newtonsoft.Json;
using PetfinderNet.Models;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PetfinderNet.Http
{
    /// <summary>
    /// This class encapsulates an HTTP request to the Petfinder API. It handles
    /// authentication and deserialization.
    /// </summary>
    /// <typeparam name="T">The type of object contained in the response.</typeparam>
    internal class PetfinderWebRequest<T>
    {
        /// <summary>
        /// The base URL for the Petfinder API.
        /// </summary>
        private const string BaseUrl = "http://api.petfinder.com/";

        /// <summary>
        /// The API key used to authenticate requests.
        /// </summary>
        private readonly string _apiKey;

        /// <summary>
        /// Creates a new PetfinderWebRequest.
        /// </summary>
        /// <param name="apiKey">The API key used to authenticate requests.</param>
        public PetfinderWebRequest(string apiKey)
        {
            _apiKey = apiKey;
        }

        /// <summary>
        /// Performs an HTTP GET request to the Petfinder API.
        /// </summary>
        /// <param name="resource">The Petfinder resource to request.</param>
        /// <param name="parameters">A list of key/value pairs where the key is a parameter name
        /// and the value is the parameter's value. These parameters will be used to construct
        /// the query string.</param>
        /// <returns>A PetfinderResponse containing a result of type T.</returns>
        public async Task<PetfinderResponse<T>> Get(string resource, Dictionary<string, string> parameters)
        {
            var queryString = new StringBuilder();
            queryString.Append($"key={_apiKey}");
            queryString.Append("&format=json");
            foreach (var param in parameters)
                queryString.Append($"&{param.Key}={WebUtility.UrlEncode(param.Value)}");

            var url = $"{BaseUrl}/{resource}?{queryString}";

            using (var request = new HttpClient())
            {
                var response = await request.GetAsync(url);
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<PetfinderResponse<T>>(json);
            }
        }
    }
}
