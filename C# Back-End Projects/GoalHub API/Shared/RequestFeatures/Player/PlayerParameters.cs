using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.RequestFeatures.Player
{
    public class PlayerParameters : RequestParameters
    {
        public string? Position { get; set; }

        public string? CurrentTeam { get; set; }

        public bool? Gender { get; set; } = null;

    }
}
