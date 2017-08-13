# Petfinder.NET
[![CircleCI](https://circleci.com/gh/pricejc/Petfinder.NET.svg?style=svg)](https://circleci.com/gh/pricejc/Petfinder.NET)

## Introduction
Petfinder.NET is a wrapper around the Petfinder API that can be used to search for shelters and pets. Petfinder.NET is a .NET standard library so it can be used in .NET Core, .NET Framework, or Mono applications. Usage is limited by the restrictions listed in the official [Petfinder API Documentation](https://www.petfinder.com/developers/api-docs).

## Getting API Keys
In order to make requests to the Petfinder API you will need a set of API keys. You can obtain these keys by creating a Petfinder account [here](https://www.petfinder.com/developers/api-key). Please note the key value. Petfinder.NET does not make use of the secret. You should protect your key and secret.

## Installing
You can install Petfinder.NET by entering the following command in the Package Manager Console.  
```Install-Package PetfinderNet -Version 1.0.0```   
Alternatively, you can install Petfinder.NET using the .NET CLI.  
```dotnet add package PetfinderNet --version 1.0.0```   

## Getting Started
Petfinder.NET provides a simple interface for making requests to the Petfinder API. The following code snippet will search for Large Adult Female Golden Retrievers in North Carolina.

```
var client = new PetfinderClient("YOUR_API_KEY");

var response = await client.FindPets("NC",
    animal: Species.Dog,
    breed: Breeds.Dogs.GoldenRetriever,
    size: Sizes.Large,
    sex: Sex.Female,
    age: Ages.Adult);

if (response.Header.Status.Code == PetfinderStatusCodes.PFAPI_OK)
{
    foreach (var pet in response.Result)
    {
        Console.WriteLine(pet.Name);
    }
}
```

## Documentation
Coming soon...

## Legal
Petfinder.NET is an unofficial library and is not endorsed or maintained by [Petfinder](https://www.petfinder.com).

## Licensing
Petfinder .NET is licensed under the MIT License. See [License](https://github.com/pricejc/Petfinder.NET/blob/master/LICENSE) for full details.
