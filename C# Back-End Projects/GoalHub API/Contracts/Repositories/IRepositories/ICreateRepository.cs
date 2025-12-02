using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Repositories.IRepositories
{
    public interface ICreateRepository<T>
    {
        void Create(T entity);
    }
}
