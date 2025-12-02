using Entities.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Exceptions.City_Exceptions
{
    public class PersonNotFoundException : NotFoundException
    {

        public PersonNotFoundException(int PersonID)
            : base($"The Person with id: {PersonID} doesn't exist in the database.")
        {
        }

    }
}

