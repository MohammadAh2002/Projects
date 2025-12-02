using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.Stadium
{
    
    public record StadiumDTO
    {

        public short ID { get; set; }
        public string? Name { get; set; }
        public int Capacity { get; set; }
        public short CityID { get; set; }

    }
}
