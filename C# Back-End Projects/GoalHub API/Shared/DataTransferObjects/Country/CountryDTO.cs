using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.Country
{
    
    public record CountryDTO
    {
        public short ID { get; init; }
        public string? Name { get; init; }
        public string? Nationality { get; init; }
    }
}
