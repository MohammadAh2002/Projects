using Shared.DataTransferObjects.City;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.Country
{
    
    public record CountryWithCitiesDTO : CountryDTO
    {
        public ICollection<CityWithoutCountryDTO>? Cities { get; set; }

    }
}
