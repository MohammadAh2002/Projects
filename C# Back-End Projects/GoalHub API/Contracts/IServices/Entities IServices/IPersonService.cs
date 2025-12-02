using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Shared.DataTransferObjects.Person;

namespace Contracts.IServices.Entities_IServices
{
    public interface IPersonService
    {       

        Task<PersonDTO> CreatePersonAsync(PersonCreationDTO Person, bool trackChanges);
        Task<bool> PatchPersonAsync(int ID, JsonPatchDocument<PlayerForUpdateDTO>? patchDoc);

        Task UpdatePersonPhotoAsync(int ID, IFormFile newPhoto);
    }
}
