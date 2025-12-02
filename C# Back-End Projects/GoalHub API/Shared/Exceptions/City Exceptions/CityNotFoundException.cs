using Entities.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Exceptions.City_Exceptions
{
    public class CityNotFoundException : NotFoundException
    {

        public CityNotFoundException(short CityID)
            : base($"The City with id: {CityID} doesn't exist in the database.")
        {
        }

    }
}

