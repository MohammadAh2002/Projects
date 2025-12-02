using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Responses.Entities_Responses.Team
{
    public class TeamDeletedResponse : ApiDeletedResponse
    {
        public TeamDeletedResponse(bool success) : base(success)
        {
        }
    }
}
