using Entities.Models;
using Shared.DataTransferObjects.City;
using Shared.DataTransferObjects.Country;
using Shared.RequestFeatures;
using Shared.RequestFeatures.City;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.IServices.Entities_IServices
{
    public interface ICityService
    {
        Task<(IEnumerable<ExpandoObject> Cities, MetaData MetaData)> GetAllCitiesAsync(short CountryID, CityParameters CityParameters, bool trackChanges);
        Task<(IEnumerable<ExpandoObject> Cities, MetaData MetaData)> GetAllCitiesAsync(CityParameters CityParameters, bool trackChanges);

        Task<CityDTO?> GetCityAsync(short CityID, bool trackChanges);

        Task<CityDTO> CreateCityAsync(short ID, CityCreationDTO City, bool trackChanges);

        Task DeleteCityAsync(short ID, bool trackChanges);

        Task<(CityForUpdateDto CityToPatch, City CityEntity)> GetCityForPatchAsync(
        short CityID, bool empTrackChanges);

        Task SaveChangesForPatchAsync(CityForUpdateDto CityToPatch, City CityEntity);

    }
}
