using Entities.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Exceptions.Country_Exceptions
{
    public class TeamNotFoundException : NotFoundException
    {

        public TeamNotFoundException(int TeamID)
            : base($"The Team with id: {TeamID} doesn't exist in the database.")
        {
        }

    }
}
