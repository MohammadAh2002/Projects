using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.Player
{
    
    public record PlayerDTO
    {

        public int ID { get; init; }

        public int PersonID { get; init; }

        public int CurrentTeamID { get; init; }
        
        public byte ShirtNumber { get; init; }

        public string? Position { get; init; }

        public PlayerStatusDTO? Status { get; init; } = null;
    }
}
