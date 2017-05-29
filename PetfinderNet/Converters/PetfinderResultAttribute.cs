using System;

namespace PetfinderNet.Converters
{
    /// <summary>
    /// This attribute denotes which property in a Petfinder response
    /// contains the result.
    /// </summary>
    internal class PetfinderResultAttribute : Attribute
    {
        /// <summary>
        /// The name of the property on the Petfinder JSON response
        /// that contains the result of the request.
        /// </summary>
        public string PropertyName { get; set; }

        /// <summary>
        /// Creates a new PetfinderResultAttribute.
        /// </summary>
        /// <param name="propertyName">The name of the property on the Petfinder
        /// JSON response that contains the result of the request.</param>
        public PetfinderResultAttribute(string propertyName)
        {
            PropertyName = propertyName;
        }
    }
}
