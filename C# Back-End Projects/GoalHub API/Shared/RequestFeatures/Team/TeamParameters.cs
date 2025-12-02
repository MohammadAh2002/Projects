using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.RequestFeatures.Player
{
    public class TeamParameters : RequestParameters
    {

        public string? Stadium { get; set; }

        public string? Abbreviation { get; set; }

        public DateOnly? BeforeFoundedDate { get; set; }

        public DateOnly? AfterFoundedDate { get; set; }

    }
}
