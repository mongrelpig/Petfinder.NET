// ReSharper disable InconsistentNaming

namespace PetfinderNet.Models
{
    /// <summary>
    /// This enum contains the possible status codes
    /// in the Petfinder API.
    /// </summary>
    public enum PetfinderStatusCodes
    {
        PFAPI_OK = 100,
        PFAPI_ERR_INVALID = 200,
        PFAPI_ERR_NOENT = 201,
        PFAPI_ERR_LIMIT = 202,
        PFAPI_ERR_LOCATION = 203,
        PFAPI_ERR_UNAUTHORIZED = 300,
        PFAPI_ERR_AUTHFAIL = 301,
        PFAPI_ERR_INTERNAL = 999
    }
}
