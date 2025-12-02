using Entities.Models;
using Entities.Responses;
using Shared.DataTransferObjects.City;
using Shared.DataTransferObjects.Country;
using Shared.RequestFeatures;
using Shared.RequestFeatures.Country;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.IServices.Entities_IServices
{
    public interface ICountryService
    {
        Task<CountryWithCitiesDTO> GetCountryAllCitiesAsync(short CountryID, bool trackChanges);

        Task<(IEnumerable<ExpandoObject> Countries, MetaData MetaData)> GetAllCountriesAsync(CountryParameters CountryParameters, bool trackChanges);

        Task<ApiBaseResponse> GetCountryAsync(short CountryID, bool trackChanges);

        Task<CountryDTO> CreateCountryAsync(CountryCreationDTO Country);

        Task DeleteCountryAsync(short CountryID, bool trackChanges);

    }
}
