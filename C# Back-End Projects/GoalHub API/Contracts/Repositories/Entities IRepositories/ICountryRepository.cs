using Entities.Models;
using Shared.DataTransferObjects.Country;
using Shared.RequestFeatures;
using Shared.RequestFeatures.Country;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Repositories.Entities_IRepositories
{
    public interface ICountryRepository
    {

        Task<Country?> GetAllCitiesAsync(short CountryID, bool trackChanges);

        Task<PagedList<Country>> GetAllCountriesAsync(CountryParameters CountryParameters, bool trackChanges);

        Task<Country?> GetCountryAsync(short CountryID, bool trackChanges);

        Task CreateCountry(Country Country);

        Task DeleteCountry(Country Country);

    }
}
