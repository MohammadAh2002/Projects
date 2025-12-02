using Contracts.Repositories.Entities_IRepositories;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Base;
using Repository.Context;
using Shared.DataTransferObjects.Person;
using System.Threading;

namespace Repository.Entities_Repositories
{
    public class PersonRepository<TContext> : IPersonRepository
        where TContext : DbContext
    {
        private readonly Lazy<CreateRepositoryBase<TContext, Person>> _Create;
        private readonly Lazy<ReadRepositoryBase<TContext, Person>> _Read;
        private readonly Lazy<DeleteRepositoryBase<TContext, Person>> _Delete;
        public PersonRepository(TContext repositoryContext)
        {
            _Create = new Lazy<CreateRepositoryBase<TContext, Person>>(() => new CreateRepositoryBase<TContext, Person>(repositoryContext));
            _Read = new Lazy<ReadRepositoryBase<TContext, Person>>(() => new ReadRepositoryBase<TContext, Person>(repositoryContext));
            _Delete = new Lazy<DeleteRepositoryBase<TContext, Person>>(() => new DeleteRepositoryBase<TContext, Person>(repositoryContext));
        }

        public async Task CreatePersonAsync(Person Person)
        {
            _Create.Value.Create(Person);
        }
         
        public async Task DeletePerson(Person Person)
        {
            _Delete.Value.Delete(Person);
        }

        public async Task<Person?> GetPersonAsync(int PersonID, bool trackChanges)
        {
            return await _Read.Value.FindByCondition(Person => Person.ID == PersonID, trackChanges)
                                          .Include(Person => Person.Country)
                                          .SingleOrDefaultAsync();

        }
    }
}
