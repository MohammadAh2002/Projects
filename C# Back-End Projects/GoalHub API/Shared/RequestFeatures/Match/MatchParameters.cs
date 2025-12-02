using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.RequestFeatures.Match
{
    public class MatchParameters : RequestParameters
    {

        const int maxPageSize = 100;

        public string? AwayTeam { get; set; }

        public string? HomeTeam { get; set; }

        public string? Stadium { get; set; }

        public DateTime? KickoffTime { get; set; } = null;

        public short? Status { get; set; } = null;

        public string? Round { get; set; }

    }
}
