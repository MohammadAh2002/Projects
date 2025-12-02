using Entities.Models;
using Shared.DataTransferObjects.Country;
using Shared.DataTransferObjects.Stadium;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.Team
{
    
    public record TeamDTO
    {

        public int ID { get; init; }
        public string Name { get; init; } = string.Empty;
        public string Abbreviation { get; init; } = string.Empty;
        public short CityID { get; init; }
        public DateOnly FoundedDate { get; init; }

        public StadiumDTO? Stadium { get; init; }

    }
}
