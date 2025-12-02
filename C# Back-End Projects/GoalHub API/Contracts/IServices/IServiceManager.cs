using Contracts.IServices.Entities_IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.IServices
{
    public interface IServiceManager
    {
        ICountryService CountryService { get;  }

        ICityService CityService { get; }

        IPersonService PersonService { get; }

        ITeamService TeamService { get; }
        ITeamServicev2 TeamServicev2 { get; }

        IPlayerService PlayerService { get; }

        IMatchService MatchService { get; }

        IAuthenticationService AuthenticationService { get; }
    }
}
