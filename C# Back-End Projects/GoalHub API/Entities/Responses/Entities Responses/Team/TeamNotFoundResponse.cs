using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Responses.Entities_Responses.Team
{
    public sealed class TeamNotFoundResponse : ApiNotFoundResponse
    {
        public TeamNotFoundResponse(int id)
        : base($"Country with id: {id} is not found in db.")
        {
        }
    }

}
