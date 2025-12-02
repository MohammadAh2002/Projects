using Contracts.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using Repository.Context;


namespace Repository.Base
{
    public class CreateRepositoryBase<TContext, T> : ICreateRepository<T>
    where TContext : DbContext
    where T : class
    {
        protected readonly TContext _context;

        public CreateRepositoryBase(TContext context)
        {
            _context = context;
        }

        public void Create(T entity) => _context.Set<T>().Add(entity);

    }
}
