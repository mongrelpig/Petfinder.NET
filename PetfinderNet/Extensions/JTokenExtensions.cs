using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace PetfinderNet.Extensions
{
    /// <summary>
    /// This class contains extensions for the JToken class that make searching for
    /// values in nested objects simpler.
    /// </summary>
    internal static class JTokenExtensions
    {
        /// <summary>
        /// Retrieves the value at the specified path in the JToken's hierarchy.
        /// </summary>
        /// <typeparam name="T">The type of the value.</typeparam>
        /// <param name="token">The token being searched.</param>
        /// <param name="path">A list of properties, in order, that point to the value.</param>
        /// <returns>The value of type T or the default of type T if no value was found.</returns>
        internal static T FindValue<T>(this JToken token, params string[] path)
        {
            var value = token.FindToken(path);
            return value == null ? default(T) : value.Value<T>();
        }

        /// <summary>
        /// Retrieves the object at the specified path in the JToken's hierarchy.
        /// </summary>
        /// <param name="token">The token being searched.</param>
        /// <param name="path">A list of properties, in order, that point to the object.</param>
        /// <returns>The object at the path or null if no object was found.</returns>
        internal static JObject FindObject(this JToken token, params string[] path)
        {
            var value = token.FindToken(path);
            if (value is JObject)
                return (JObject)value;
            return null;
        }

        /// <summary>
        /// Retrieves the list at the specified path in the JToken's hierarchy.
        /// </summary>
        /// <param name="token">The token being searched.</param>
        /// <param name="path">A list of properties, in order, that point to the list.</param>
        /// <returns>The list at the path or null if no list was found.</returns>
        internal static IList<JToken> FindList(this JToken token, params string[] path)
        {
            IList<JToken> results = new List<JToken>();

            var value = token.FindToken(path);
            if (value is JArray)
            {
                foreach (var item in value)
                    results.Add(item);
            }
            else if (value is JObject)
            {
                results.Add(value);
            }

            return results;
        }

        /// <summary>
        /// Retrieves the array at the specified path in the JToken's hierarchy.
        /// </summary>
        /// <param name="token">The token being searched.</param>
        /// <param name="path">A list of properties, in order, that point to the arry.</param>
        /// <returns>The array at the path or null if no array was found.</returns>
        internal static JArray FindArray(this JToken token, params string[] path)
        {
            var value = token.FindToken(path);
            if (value is JArray)
                return (JArray)value;
            return null;
        }

        /// <summary>
        /// Retrieves the token at the specified path in the JToken's hierarchy.
        /// </summary>
        /// <param name="token">The token being searched.</param>
        /// <param name="path">A list of properties, in order, that point to the token.</param>
        /// <returns>The token at the path or null if no token was found.</returns>
        internal static JToken FindToken(this JToken token, params string[] path)
        {
            if (path.Length == 0)
                throw new ArgumentException("No path was specified");

            var currentToken = token[path[0]];
            for (var i = 1; i < path.Length; i++)
            {
                if (currentToken == null) return null;
                currentToken = currentToken[path[i]];
            }

            return currentToken;
        }
    }
}
