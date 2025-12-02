using Shared.DataTransferObjects.Country;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.City
{
    
    public record CityWithoutCountryDTO
    {
        public short ID { get; init; }
        public string Name { get; init; } = string.Empty;

    }
}
