using Contracts.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Base
{
    public class UpdateRepositoryBase<TContext, T> : IUpdateRepository<T>
    where TContext : DbContext
    where T : class
    {
        protected readonly TContext _context;

        public UpdateRepositoryBase(TContext context)
        {
            _context = context;
        }

        public void Update(T entity) => _context.Set<T>().Update(entity);

    }
}
