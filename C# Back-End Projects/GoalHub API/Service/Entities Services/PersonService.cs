using AutoMapper;
using Contracts;
using Contracts.IServices.Entities_IServices;
using Contracts.Repositories.IRepositories;
using Entities.ConfigurationModels;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Shared.DataTransferObjects.Person;
using Shared.Exceptions.City_Exceptions;
using System.ComponentModel.DataAnnotations;
using static Contracts.IFileStorageService;

namespace Service.Entities_Services
{
    public class PersonService : IPersonService
    {
        private readonly IRepositoryManager _Repository;
        private readonly IMapper _Mapper;
        private readonly IFileStorageService _FileStorageService;
        private readonly StaticFilePaths _FileStorageSettings;

        public PersonService(IRepositoryManager Repository, IMapper Mapper,
                             IFileStorageService FileStorageService, StaticFilePaths FileStorageSettings)
        {
            _Repository = Repository;
            _Mapper = Mapper;
            _FileStorageService = FileStorageService;
            _FileStorageSettings = FileStorageSettings;
        }

        public async Task<PersonDTO> CreatePersonAsync(PersonCreationDTO Person, bool trackChanges)
        {

            Person? PersonEntity = _Mapper.Map<Person>(Person);
            PersonEntity.ImageFileName = "None";

            await _Repository.Person.CreatePersonAsync(PersonEntity);
            await _Repository.SaveAsync();

            if (!_FileStorageService.ValidateExtension(Person.Photo, enFileType.Image))
            {
                await _Repository.Person.DeletePerson(PersonEntity);
                await _Repository.SaveAsync();
                throw new InvalidOperationException($"Invalid file type.");
            }

            string fileName = $"person_{PersonEntity.ID}";

            string FilePath = await _FileStorageService.SaveFileAsync(Person.Photo, fileName, enFileType.Image);

            PersonEntity.ImageFileName = FilePath;

            await _Repository.SaveAsync();

            PersonDTO PersonToReturn = _Mapper.Map<PersonDTO>(PersonEntity);

            if (PersonToReturn == null)
                throw new CreationFailedException("Failed to Create Person");

            return PersonToReturn;

        }


        public async Task<bool> PatchPersonAsync(int ID,
                                               JsonPatchDocument<PlayerForUpdateDTO>? patchDoc)
        {
            if (patchDoc is null)
                throw new BadRequestException("Patch Object is nulll.");

            (PlayerForUpdateDTO PersonToPatch, Person PersonEntity) Result = await GetPersonForPatchAsync(ID, true);

            patchDoc.ApplyTo(Result.PersonToPatch);

            ValidationContext validationContext = new ValidationContext(Result.PersonToPatch);
            List<ValidationResult> validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(
                Result.PersonToPatch,
                validationContext,
                validationResults,
                validateAllProperties: true
            );

            if (!isValid)
            {
                throw new ValidationException(
                    $"Invalid model: {string.Join(", ", validationResults.Select(r => r.ErrorMessage))}"
                );
            }

            _Mapper.Map(Result.PersonToPatch, Result.PersonEntity);

            await _Repository.SaveAsync();

            return true;
        }

        public async Task UpdatePersonPhotoAsync(int ID, IFormFile newPhoto)
        {

            if (newPhoto == null || newPhoto.Length == 0)
               throw new BadRequestException("Photo file is missing.");

            if (!_FileStorageService.ValidateExtension(newPhoto, enFileType.Image))
            {

                throw new InvalidOperationException($"Invalid file type.");

            }

            Person Person = await CheckIfPersonExists(ID, false);

            if (!string.IsNullOrEmpty(Person.ImageFileName) && File.Exists(Person.ImageFileName)) {

                        File.Delete(Person.ImageFileName);
            }

            string fileName = $"person_{Person.ID}";

            await _FileStorageService.SaveFileAsync(newPhoto, fileName, enFileType.Image);

        }

        private async Task<Person> CheckIfPersonExists(int ID, bool trackChanges)
        {
            Person? Person = await _Repository.Person.GetPersonAsync(ID, trackChanges);

            if (Person is null)
                throw new PersonNotFoundException(ID);

            return Person;
        }
        private async Task<(PlayerForUpdateDTO PersonToPatch, Person PersonEntity)> GetPersonForPatchAsync(int PersonID, bool CityTrackChanges)
        {

            Person? PersonEntity = await CheckIfPersonExists(PersonID, CityTrackChanges);

            PlayerForUpdateDTO PersonToPatch = _Mapper.Map<PlayerForUpdateDTO>(PersonEntity);

            return (PersonToPatch, PersonEntity);

        }

    }
}
