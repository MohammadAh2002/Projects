using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.Match
{
    
    public record MatchStatusDTO
    {

        public short ID { get; init; }

        public string? Name { get; init; }

        public string? Description { get; init; }

    }
}
