using Entities.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Exceptions.Country_Exceptions
{
    public class CountryNotFoundException : NotFoundException
    {

        public CountryNotFoundException(short CountryID)
            : base($"The Country with id: {CountryID} doesn't exist in the database.")
        {
        }

    }
}
