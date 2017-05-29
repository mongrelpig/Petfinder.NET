using PetfinderNet.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetfinderNet.Http;

namespace PetfinderNet
{
    /// <summary>
    /// This class is used to make requests to the Petfinder API.
    /// </summary>
    public class PetfinderClient
    {
        /// <summary>
        /// The API key used to authenticate requests.
        /// </summary>
        private readonly string _apiKey;

        /// <summary>
        /// Creates a new PetfinderClient.
        /// </summary>
        /// <param name="apiKey">The API key used to authenticate requests.</param>
        public PetfinderClient(string apiKey)
        {
            _apiKey = apiKey;
        }

        /// <summary>
        /// Returns a random pet matching the specified criteria.
        /// </summary>
        /// <param name="animal">The type of animal the pet is.</param>
        /// <param name="breed">The breed of the pet.</param>
        /// <param name="size">The size of the pet.</param>
        /// <param name="sex">The sex of the pet.</param>
        /// <param name="location">The location of the pet.</param>
        /// <param name="shelterId">The ID of the shelter the pet belongs to.</param>
        /// <returns>A random pet matching the specified criteria.</returns>
        public async Task<PetfinderResponse<Pet>> GetRandomPet(string animal = null,
            string breed = null, string size = null, Sex? sex = null, string location = null,
            string shelterId = null)
        {
            var request = new PetfinderWebRequest<Pet>(_apiKey);
            var parameters = new Dictionary<string, string> {{"output", "full"}};
            if (animal != null)
                parameters.Add("animal", animal);
            if (breed != null)
                parameters.Add("breed", breed);
            if (size != null)
                parameters.Add("size", size);
            if (location != null)
                parameters.Add("location", location);
            if (shelterId != null)
                parameters.Add("shelterid", shelterId);
            if (sex != null)
                parameters.Add("sex", sex == Sex.Male ? "M" : "F");
            return await request.Get("pet.getRandom", parameters);
        }

        /// <summary>
        /// Returns a list of breeds for the specified species.
        /// </summary>
        /// <param name="species">The species to get a list of breeds for.</param>
        /// <returns>A list of breeds for the specified species.</returns>
        public async Task<PetfinderResponse<BreedList>> GetBreedsAsync(string species)
        {
            var request = new PetfinderWebRequest<BreedList>(_apiKey);
            return await request.Get("breed.list", new Dictionary<string, string>
            {
                {"animal", species }
            });
        }

        /// <summary>
        /// Returns a list of shelters that have a pet with the specified breed.
        /// </summary>
        /// <param name="animal">The type of animal to search for.</param>
        /// <param name="breed">The breed to search for.</param>
        /// <param name="offset">The offset to begin searching from.</param>
        /// <param name="count">The number of results to retrieve.</param>
        /// <returns>A list of shelters that have a pet with the specified breed.</returns>
        public async Task<PetfinderResponse<ShelterList>> GetSheltersWithBreed(string animal,
            string breed, int? offset = null, int? count = null)
        {
            var request = new PetfinderWebRequest<ShelterList>(_apiKey);
            var parameters = new Dictionary<string, string> {{"animal", animal}, {"breed", breed}};
            if (offset.HasValue) parameters.Add("offset", offset.ToString());
            if (count.HasValue) parameters.Add("count", count.ToString());
            return await request.Get("shelter.listByBreed", parameters);
        }

        /// <summary>
        /// Returns a list of pets belonging to the specified shelter.
        /// </summary>
        /// <param name="id">The ID of the shelter to get pets from.</param>
        /// <param name="status">The status of the pets to retrieve.</param>
        /// <param name="offset">The offset to being searching from.</param>
        /// <param name="count">The number of results to retrieve.</param>
        /// <returns>A list of pets belonging to the specified shelter.</returns>
        public async Task<PetfinderResponse<PetList>> GetPetsInShelter(string id,
            PetStatus? status = null, int? offset = null, int? count = null)
        {
            var request = new PetfinderWebRequest<PetList>(_apiKey);
            var parameters = new Dictionary<string, string> {{"id", id}, {"output", "full"}};
            if (status.HasValue) parameters.Add("status", StatusToString(status.Value));
            if (offset.HasValue) parameters.Add("offset", offset.ToString());
            if (count.HasValue) parameters.Add("count", count.ToString());
            return await request.Get("shelter.getPets", parameters);
        }

        /// <summary>
        /// Returns the shelter with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the shelter to retrieve.</param>
        /// <returns>The shelter with the specified ID.</returns>
        public async Task<PetfinderResponse<Shelter>> GetShelter(string id)
        {
            var request = new PetfinderWebRequest<Shelter>(_apiKey);
            return await request.Get("shelter.get", new Dictionary<string, string>
            {
                {"id", id }
            });
        }

        /// <summary>
        /// Returns a list of pets matching the specified criteria.
        /// </summary>
        /// <param name="location">The location of the pet.</param>
        /// <param name="animal">The type of animal the pet is.</param>
        /// <param name="breed">The type of breed the pet is.</param>
        /// <param name="size">The size of the pet.</param>
        /// <param name="sex">The sex of the pet.</param>
        /// <param name="age">The age of the pet.</param>
        /// <param name="offset">The offset to begin searching from.</param>
        /// <param name="count">The number of results to retrieve.</param>
        /// <returns>A list of pets matching the specified criteria.</returns>
        public async Task<PetfinderResponse<PetList>> FindPets(string location,
            string animal = null, string breed = null, string size = null,
            Sex? sex = null, string age = null, string offset = null,
            int? count = null)
        {
            var request = new PetfinderWebRequest<PetList>(_apiKey);
            var parameters = new Dictionary<string, string> {{"location", location}, {"output", "full"}};
            if (animal != null) parameters.Add("animal", animal);
            if (breed != null) parameters.Add("breed", breed);
            if (size != null) parameters.Add("size", size);
            if (sex != null) parameters.Add("sex", sex == Sex.Male ? "M" : "F");
            if (age != null) parameters.Add("age", age);
            if (offset != null) parameters.Add("offset", offset);
            if (count != null) parameters.Add("count", count.ToString());
            return await request.Get("pet.find", parameters);
        }

        /// <summary>
        /// Returns a list of shelters matching the specified criteria.
        /// </summary>
        /// <param name="location">The location of the shelter.</param>
        /// <param name="name">The name of the shelter.</param>
        /// <param name="offset">The offset to being searching from.</param>
        /// <param name="count">The number of results to retrieve.</param>
        /// <returns></returns>
        public async Task<PetfinderResponse<ShelterList>> FindShelters(string location,
            string name = null, int? offset = null, int? count = null)
        {
            var request = new PetfinderWebRequest<ShelterList>(_apiKey);
            var parameters = new Dictionary<string, string> {{"location", location}};
            if (name != null)
                parameters.Add("name", name);
            if (offset != null)
                parameters.Add("offset", offset.ToString());
            if (count != null)
                parameters.Add("count", count.ToString());
            return await request.Get("shelter.find", parameters);
        }

        /// <summary>
        /// Returns the pet with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the pet to retrieve.</param>
        /// <returns>The pet with the specified ID.</returns>
        public async Task<PetfinderResponse<Pet>> GetPet(long id)
        {
            var request = new PetfinderWebRequest<Pet>(_apiKey);
            return await request.Get("pet.get", new Dictionary<string, string>
            {
                {"id", id.ToString() }
            });
        }

        /// <summary>
        /// Converts a PetStatus enum to its corresponding string.
        /// </summary>
        /// <param name="status">The status to convert.</param>
        /// <returns>A Petfinder API string representation of the status.</returns>
        private string StatusToString(PetStatus status)
        {
            switch (status)
            {
                case PetStatus.Adoptable:
                    return "A";
                case PetStatus.Hold:
                    return "H";
                case PetStatus.Pending:
                    return "P";
                default:
                    return "X";
            }
        }
    }
}
