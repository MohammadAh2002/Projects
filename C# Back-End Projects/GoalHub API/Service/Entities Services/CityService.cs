using AutoMapper;
using Contracts.DataShaping;
using Contracts.ILogging;
using Contracts.IServices.Entities_IServices;
using Contracts.Repositories.IRepositories;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Shared.DataTransferObjects.City;
using Shared.DataTransferObjects.Country;
using Shared.Exceptions.City_Exceptions;
using Shared.Exceptions.Country_Exceptions;
using Shared.RequestFeatures;
using Shared.RequestFeatures.City;
using Shared.RequestFeatures.Country;
using System.ComponentModel.Design;
using System.Dynamic;

namespace Service.Entities_Services
{
    public class CityService : ICityService
    {
        private readonly IRepositoryManager _Repository;
        private readonly ILoggerManager _Logger;
        private readonly IMapper _Mapper;
        private readonly IDataShaper<CityDTO> _Shaper;
        public CityService(IRepositoryManager Repository, ILoggerManager Logger,
                              IMapper Mapper, IDataShaper<CityDTO> shaper)
        {
            _Repository = Repository;
            _Logger = Logger;
            _Mapper = Mapper;
            _Shaper = shaper;
        }

        public async Task<CityDTO> CreateCityAsync(short CountryID, CityCreationDTO CityForCreation, bool trackChanges)
        {

            await CheckIfCountryExists(CountryID, trackChanges);

            City CityEntity = _Mapper.Map<City>(CityForCreation);

            CityEntity.CountryID = CountryID;

            await _Repository.City.CreateCityAsync(CityEntity);

            await _Repository.SaveAsync();

            CityEntity.Country = await _Repository.Country.GetCountryAsync(CountryID, false);

            CityDTO CityToReturn = _Mapper.Map<CityDTO>(CityEntity);

            if (CityToReturn == null)
                throw new CreationFailedException("Failed to Create City");

            return CityToReturn;
        }

        public async Task DeleteCityAsync(short CityID, bool trackChanges)
        {
            City? City = await CheckIfCityExists(CityID, trackChanges);

            if (City == null)
                throw new CityNotFoundException(City.ID);

            try
            {

                await _Repository.City.DeleteCityAsync(City);

                await _Repository.SaveAsync();

                _Logger.LogWarn($"City with id: {CityID} has been deleted.");

            }

            catch (DbUpdateException ex)
            {
                throw new DeletionFailedException($"Failed to Delete City with ID {CityID}: {ex.Message}");
            }

        }

        public async Task<(IEnumerable<ExpandoObject> Cities, MetaData MetaData)> GetAllCitiesAsync(CityParameters CityParameters, bool trackChanges)
        {
            PagedList<City> CitiesWithMetaData = await _Repository.City.GetAllCitiesAsync(CityParameters, trackChanges);

            if (CitiesWithMetaData is null)
                throw new EmptyCollectionException("No Cities were found in the database.");

            IEnumerable<CityDTO> CitiesDTO = _Mapper.Map<IEnumerable<CityDTO>>(CitiesWithMetaData);

            IEnumerable<ExpandoObject> ShapedData = _Shaper.ShapeData(CitiesDTO, CityParameters.Fields);

            return (Cities: ShapedData, MetaData: CitiesWithMetaData.MetaData);

        }

        public async Task<(IEnumerable<ExpandoObject> Cities, MetaData MetaData)> GetAllCitiesAsync(short CountryID, CityParameters CityParameters, bool trackChanges)
        {
            await CheckIfCountryExists(CountryID, trackChanges);

            PagedList<City> CitiesWithMetaData = await _Repository.City.GetAllCitiesAsync(CountryID, CityParameters, trackChanges);

            if (CitiesWithMetaData is null)
                throw new EmptyCollectionException("No Cities were found in the database for this Country.");

            IEnumerable<CityDTO> CitiesDTO = _Mapper.Map<IEnumerable<CityDTO>>(CitiesWithMetaData);
            
            IEnumerable<ExpandoObject> ShapedData = _Shaper.ShapeData(CitiesDTO, CityParameters.Fields);

            return (Cities: ShapedData, MetaData: CitiesWithMetaData.MetaData);

        }
        
        public async Task<CityDTO?> GetCityAsync(short CityID, bool trackChanges)
        {
            City? City = await CheckIfCityExists(CityID, trackChanges);

            CityDTO CityToReturn = _Mapper.Map<CityDTO>(City);

            return CityToReturn;
        }

        private async Task<City> CheckIfCityExists(short ID, bool trackChanges)
        {
            City? City = await _Repository.City.GetCityAsync(ID, trackChanges);

            if (City is null)
                throw new CityNotFoundException(ID);

            return City;
        }
        private async Task<Country> CheckIfCountryExists(short ID, bool trackChanges)
        {
            Country? Country = await _Repository.Country.GetCountryAsync(ID, trackChanges);

            if (Country is null)
                throw new CountryNotFoundException(ID);

            return Country;
        }

        public async Task<(CityForUpdateDto CityToPatch, City CityEntity)> GetCityForPatchAsync(short CityID, bool CityTrackChanges)
        {

            City? CityEntity = await CheckIfCityExists(CityID, CityTrackChanges);

            CityForUpdateDto CityToPatch = _Mapper.Map<CityForUpdateDto>(CityEntity);

            return (CityToPatch, CityEntity);

        }

        public async Task SaveChangesForPatchAsync(CityForUpdateDto CityToPatch, City CityEntity)
        {
            _Mapper.Map(CityToPatch, CityEntity);

            await _Repository.SaveAsync();
        }


    }
}
