using Entities.Models;
using Shared.DataTransferObjects.City;
using Shared.RequestFeatures;
using Shared.RequestFeatures.City;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Repositories.Entities_IRepositories
{
    public interface ICityRepository
    {

        Task CreateCityAsync(City CouCityntry);
        Task<City?> GetCityAsync(short ID, bool trackChanges);

        Task DeleteCityAsync(City City);

        Task<PagedList<City>> GetAllCitiesAsync(CityParameters CityParameters, bool trackChanges);
        Task<PagedList<City>> GetAllCitiesAsync(short CountryID, CityParameters CityParameters, bool trackChanges);
    }
}
