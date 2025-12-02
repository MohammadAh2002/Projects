using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.Player
{
    
    public record PlayerStatusDTO
    {

        public short? Goals { get; init; } 

        public short? Assists { get; init; }

        public byte? RedCards { get; init; }

        public byte? YellowCards { get; init; }

    }
}
