using Entities.Enums;
using Entities.Models;
using Shared.DataTransferObjects.Stadium;
using Shared.DataTransferObjects.Team;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.Match
{
    
    public record MatchDTO
    {

        public long ID { get; init; }

        public TeamDTO? AwayTeam { get; init; }
        public TeamDTO? HomeTeam { get; init; }

        public DateTime KickoffTime { get; init; }

        public StadiumDTO? Stadium { get; init; }

        public byte HomeTeamScore { get; init; }
        public byte AwayTeamScore { get; init; }

        public string? Round { get; init; }

        public MatchStatusDTO? MatchStatus { get; init; }

    }
}
