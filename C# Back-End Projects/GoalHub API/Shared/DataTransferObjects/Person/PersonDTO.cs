using Entities.Models;
using Shared.DataTransferObjects.Country;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.Person
{
    
    public record PersonDTO
    {

        public int ID { get; init; }

        public string? Name { get; init; }

        public DateTime BirthDate { get; init; }

        public CountryDTO? CountryDetails { get; init; }

        public string? Photo { get; init; }

        public bool Gender { get; init; }

        public int Age
        {
            get
            {
                return DateTime.Today.Year - BirthDate.Year - (DateTime.Today.DayOfYear < BirthDate.DayOfYear ? 1 : 0);
            }

        }

    }
}
