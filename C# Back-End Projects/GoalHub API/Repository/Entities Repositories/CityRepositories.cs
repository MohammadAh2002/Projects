using Contracts.Repositories.Entities_IRepositories;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Base;
using Shared.RequestFeatures;
using Shared.RequestFeatures.City;

namespace Repository.Entities_Repositories
{

    public class CityRepository<TContext>
                : RepositoryBase<TContext, City>, ICityRepository
                where TContext : DbContext
    {
        public CityRepository(TContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task CreateCityAsync(City City)
        {
            Create(City);
        }
        public async Task DeleteCityAsync(City City) => Delete(City);

        public async Task<PagedList<City>> GetAllCitiesAsync(CityParameters CityParameters, bool trackChanges)
        {

            List<City> Cities = await FindAll(trackChanges).Include(city => city.Country)
                                      .ToListAsync();

            return PagedList<City>
                  .ToPagedList(Cities, CityParameters.PageNumber, CityParameters.PageSize);
        }

        public async Task<PagedList<City>> GetAllCitiesAsync(short CountryID, CityParameters CityParameters, bool trackChanges)
        {

            List<City> Cities = await FindByCondition(city => city.CountryID == CountryID, trackChanges)
                                      .ToListAsync();

            return PagedList<City>
                   .ToPagedList(Cities, CityParameters.PageNumber, CityParameters.PageSize);
        }

        public async Task<City?> GetCityAsync(short ID, bool trackChanges)
        {
            return await FindByCondition(City => City.ID.Equals(ID), trackChanges)
                .Include(city => city.Country)
                .SingleOrDefaultAsync();

        }

    }
}
