using Entities.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Exceptions.Player_Exeptions
{
    public class PlayerNotFoundException : NotFoundException
    {
        public PlayerNotFoundException(int PlayerID)
    : base($"The Player with id: {PlayerID} doesn't exist in the database.")
        {
        }
    }
}
