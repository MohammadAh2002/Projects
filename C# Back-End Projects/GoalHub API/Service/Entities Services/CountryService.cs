using AutoMapper;
using Contracts.DataShaping;
using Contracts.ILogging;
using Contracts.IServices.Entities_IServices;
using Contracts.Repositories.IRepositories;
using Entities.Exceptions;
using Entities.Models;
using Entities.Responses;
using Entities.Responses.Entities_Responses.Country;
using Microsoft.EntityFrameworkCore;

using Shared.DataTransferObjects.Country;
using Shared.DataTransferObjects.Person;
using Shared.Exceptions.Country_Exceptions;
using Shared.RequestFeatures;
using Shared.RequestFeatures.City;
using Shared.RequestFeatures.Country;
using System.Dynamic;


namespace Service.Entities_Services
{
    public class CountryService : ICountryService
    {
        private readonly IRepositoryManager _Repository;
        private readonly ILoggerManager _Logger;
        private readonly IMapper _Mapper;
        private readonly IDataShaper<CountryDTO> _Shaper;

        public CountryService(IRepositoryManager Repository, ILoggerManager Logger,
                              IMapper Mapper, IDataShaper<CountryDTO> shaper)
        {
            _Repository = Repository;
            _Logger = Logger;
            _Mapper = Mapper;
            _Shaper = shaper; 

        }

        public async Task<CountryDTO> CreateCountryAsync(CountryCreationDTO Country)
        {

            Country CountryEntity = _Mapper.Map<Country>(Country);

            await _Repository.Country.CreateCountry(CountryEntity);
            
            await _Repository.SaveAsync();

            CountryDTO CountryToReturn = _Mapper.Map<CountryDTO>(CountryEntity);

            if (CountryToReturn == null)
                throw new CreationFailedException("Failed to Create Country");

            return CountryToReturn;
        }

        public async Task DeleteCountryAsync(short CountryID, bool trackChanges)
        {
            Country? Country = await CheckIfCountryExists(CountryID, trackChanges);

            if (Country == null)
                throw new CountryNotFoundException(Country.ID);

            try
            {

                await _Repository.Country.DeleteCountry(Country);

                await _Repository.SaveAsync();

                _Logger.LogWarn($"Country with id: {CountryID} has been deleted.");

            }

            catch (DbUpdateException ex)
            {
                throw new DeletionFailedException($"Failed to Delete Country with ID {CountryID}: {ex.Message}");
            }

        }

        public async Task<(IEnumerable<ExpandoObject> Countries, MetaData MetaData)> GetAllCountriesAsync(CountryParameters CountryParameters, bool trackChanges)
        {

            PagedList<Country> CountriesWithMetaData = await _Repository.Country.GetAllCountriesAsync(CountryParameters, trackChanges);

            if (CountriesWithMetaData is null)
                throw new EmptyCollectionException("No countries were found in the database.");

            IEnumerable<CountryDTO> CountriesToReturn = _Mapper.Map<IEnumerable<CountryDTO>>(CountriesWithMetaData);

            IEnumerable<ExpandoObject> ShapedData = _Shaper.ShapeData(CountriesToReturn, CountryParameters.Fields);

            return (Countries: ShapedData, MetaData: CountriesWithMetaData.MetaData);

        }

        public async Task<ApiBaseResponse> GetCountryAsync(short CountryID, bool trackChanges)
        {
            Country? Country = await CheckIfCountryExists(CountryID, trackChanges);

            if (Country is null)
                return new CountryNotFoundResponse(CountryID);

            CountryDTO CountryToReturn = _Mapper.Map<CountryDTO>(Country);

            return new ApiOkResponse<CountryDTO>(CountryToReturn);
        }

        private async Task<Country> CheckIfCountryExists(short ID, bool trackChanges)
        {
            Country? Country = await _Repository.Country.GetCountryAsync(ID, trackChanges);

            if (Country is null)
                throw new CountryNotFoundException(ID);

            return Country;
        }

        public async Task<CountryWithCitiesDTO> GetCountryAllCitiesAsync(short CountryID, bool trackChanges)
        {
            await CheckIfCountryExists(CountryID, trackChanges);

            Country? Country = await _Repository.Country.GetAllCitiesAsync(CountryID, trackChanges);

            if (Country is null)
                    throw new CountryNotFoundException(CountryID);

            if (Country.Cities is null)
                throw new EmptyCollectionException("No Cities were found in the database for this Country.");

            CountryWithCitiesDTO CountryWithCitiesToReturn = _Mapper.Map<CountryWithCitiesDTO>(Country);

            return CountryWithCitiesToReturn;

        }

    }
}
