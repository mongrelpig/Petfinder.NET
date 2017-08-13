using System;
using System.IO;
using Newtonsoft.Json;
using PetfinderNet.Models;
using Xunit;

namespace PetfinderNet.Tests
{
    public class ConverterTests
    {
        [Fact]
        public void ShouldParseBreedList()
        {
            var breedList = ReadJsonSample("breed-list");
            JsonConvert.DeserializeObject<BreedList>(breedList);
        }

        [Fact]
        public void ShouldParseContact()
        {
            var contact = ReadJsonSample("contact");
            JsonConvert.DeserializeObject<Contact>(contact);
        }

        [Fact]
        public void ShouldParseHeader()
        {
            var header = ReadJsonSample("header");
            JsonConvert.DeserializeObject<PetfinderHeader>(header);
        }

        [Fact]
        public void ShouldParsePetPhoto()
        {
            var photo = ReadJsonSample("pet-photo");
            JsonConvert.DeserializeObject<PetPhoto>(photo);
        }

        [Fact]
        public void ShouldParsePet()
        {
            var pet = ReadJsonSample("pet");
            JsonConvert.DeserializeObject<Pet>(pet);
        }

        [Fact]
        public void ShouldParseShelter()
        {
            var shelter = ReadJsonSample("shelter");
            JsonConvert.DeserializeObject<Shelter>(shelter);
        }

        [Fact]
        public void ShouldParseStatus()
        {
            var status = ReadJsonSample("status");
            JsonConvert.DeserializeObject<PetfinderStatus>(status);
        }

        private static string ReadJsonSample(string name)
        {
            string json;
            var projectDirectory = AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.IndexOf("bin", StringComparison.Ordinal));
            var samplePath = Path.Combine(projectDirectory, "JsonSamples", $"{name}.json");
            using (var reader = new StreamReader(new FileStream(samplePath, FileMode.Open, FileAccess.Read)))
            {
                json = reader.ReadToEnd();
            }
            return json;
        }
    }
}