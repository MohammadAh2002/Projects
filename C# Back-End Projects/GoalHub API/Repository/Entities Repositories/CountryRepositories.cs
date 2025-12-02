using Contracts.Repositories.Entities_IRepositories;
using Contracts.Repositories.IRepositories;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Base;
using Repository.Context;
using Shared.DataTransferObjects.Country;
using Shared.RequestFeatures;
using Shared.RequestFeatures.Country;
using System.Diagnostics.Metrics;

namespace Repository.Entities_Repositories
{
    public class CountryRepository<TContext> : ICountryRepository
        where TContext : DbContext
    {
        private readonly Lazy<CreateRepositoryBase<TContext, Country>> _Create;
        private readonly Lazy<DeleteRepositoryBase<TContext, Country>> _Delete;
        private readonly Lazy<ReadRepositoryBase<TContext, Country>> _Read;

        public CountryRepository(TContext context)
        {
            _Create = new Lazy<CreateRepositoryBase<TContext, Country>>(() => new CreateRepositoryBase<TContext, Country>(context));
            _Delete = new Lazy<DeleteRepositoryBase<TContext, Country>>(() => new DeleteRepositoryBase<TContext, Country>(context));
            _Read = new Lazy<ReadRepositoryBase<TContext, Country>>(() => new ReadRepositoryBase<TContext, Country>(context));
        }


        public async Task CreateCountry(Country Country)
        {
            _Create.Value.Create(Country);
        }

        public async Task DeleteCountry(Country Country)
        {
            _Delete.Value.Delete(Country);
        }

        public async Task<PagedList<Country>> GetAllCountriesAsync(CountryParameters CountryParameters, bool trackChanges)
        {
          
            List<Country> Countries = await _Read.Value.FindAll(trackChanges).ToListAsync();

            return PagedList<Country>
                  .ToPagedList(Countries, CountryParameters.PageNumber, CountryParameters.PageSize);
        }

        public async Task<Country?> GetCountryAsync(short CountryID, bool trackChanges)
        {
            return await _Read.Value.FindByCondition(c => c.ID.Equals(CountryID), trackChanges).SingleOrDefaultAsync();
        }

        public async Task<Country?> GetAllCitiesAsync(short CountryID, bool trackChanges)
        {
            return await _Read.Value.FindByCondition(Country => Country.ID == CountryID, trackChanges)
                                           .Include(Country => Country.Cities)
                                           .SingleOrDefaultAsync();

        }

    }
}
