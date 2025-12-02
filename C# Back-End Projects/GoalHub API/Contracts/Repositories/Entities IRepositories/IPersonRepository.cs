using Entities.Models;
using Shared.DataTransferObjects.City;
using Shared.DataTransferObjects.Person;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Repositories.Entities_IRepositories
{
    public interface IPersonRepository
    {

        Task CreatePersonAsync(Person Person);

        Task<Person?> GetPersonAsync(int PersonID, bool trackChanges);

        Task DeletePerson(Person Person);

    }
}
