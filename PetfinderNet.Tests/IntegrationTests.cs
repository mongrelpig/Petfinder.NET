using System;
using PetfinderNet.Models;
using Xunit;

namespace PetfinderNet.Tests
{
    public class IntegrationTests
    {
        private readonly PetfinderClient _client;

        public IntegrationTests()
        {
            _client = new PetfinderClient(Environment.GetEnvironmentVariable("PETFINDER_API_KEY"));
        }

        [Fact]
        public async void ShouldGetBreeds()
        {
            var breeds = await _client.GetBreedsAsync(Species.Dog);
            Assert.Equal(PetfinderStatusCodes.PFAPI_OK, breeds.Header.Status.Code);
        }

        [Fact]
        public async void ShouldFindShelters()
        {
            var shelters = await _client.FindShelters("NC");
            Assert.Equal(PetfinderStatusCodes.PFAPI_OK, shelters.Header.Status.Code);
        }

        [Fact]
        public async void ShouldGetShelter()
        {
            var gcspca = await _client.GetShelter("NC691");
            Assert.Equal(PetfinderStatusCodes.PFAPI_OK, gcspca.Header.Status.Code);
        }

        [Fact]
        public async void ShouldGetPetsInShelter()
        {
            var gcspcaPets = await _client.GetPetsInShelter("NC691");
            Assert.Equal(PetfinderStatusCodes.PFAPI_OK, gcspcaPets.Header.Status.Code);
        }

        [Fact]
        public async void ShouldGetARandomPet()
        {
            var pet = await _client.GetRandomPet();
            Assert.Equal(PetfinderStatusCodes.PFAPI_OK, pet.Header.Status.Code);
        }

        [Fact]
        public async void ShouldGetSheltersWithBreed()
        {
            var shelters = await _client.GetSheltersWithBreed(Species.Dog, Breeds.Dogs.GoldenRetriever);
            Assert.Equal(PetfinderStatusCodes.PFAPI_OK, shelters.Header.Status.Code);
        }

        [Fact]
        public async void ShouldFindPets()
        {
            var pets = await _client.FindPets("NC",
                animal: Species.Dog,
                size: Sizes.Large,
                sex: Sex.Male,
                age: Ages.Adult);
            Assert.Equal(PetfinderStatusCodes.PFAPI_OK, pets.Header.Status.Code);
        }

        [Fact]
        public async void ShouldGetPet()
        {
            var pet = await _client.GetPet(38677284);
            Assert.Equal(PetfinderStatusCodes.PFAPI_OK, pet.Header.Status.Code);
        }
    }
}