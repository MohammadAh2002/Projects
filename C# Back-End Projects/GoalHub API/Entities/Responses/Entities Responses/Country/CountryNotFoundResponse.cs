using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Responses.Entities_Responses.Country
{
    public sealed class CountryNotFoundResponse : ApiNotFoundResponse
    {
        public CountryNotFoundResponse(int id)
        : base($"Team with id: {id} is not found in db.")
        {
        }
    }

}
