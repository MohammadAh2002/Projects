using AutoMapper;
using Contracts;
using Contracts.DataShaping;
using Contracts.ILogging;
using Contracts.IServices;
using Contracts.IServices.Entities_IServices;
using Contracts.Repositories.IRepositories;
using Entities.ConfigurationModels;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Service.Entities_Services;
using Shared.DataTransferObjects.City;
using Shared.DataTransferObjects.Country;
using Shared.DataTransferObjects.Match;
using Shared.DataTransferObjects.Person;
using Shared.DataTransferObjects.Player;
using Shared.DataTransferObjects.Team;

namespace Service
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<ICountryService> _CountryService;
        private readonly Lazy<ICityService> _CityService;
        private readonly Lazy<IPersonService> _PersonService;
        private readonly Lazy<ITeamService> _TeamService;
        private readonly Lazy<ITeamServicev2> _TeamServicev2;
        private readonly Lazy<IPlayerService> _PlayerService;
        private readonly Lazy<IMatchService> _MatchService;
        private readonly Lazy<IAuthenticationService> _AuthenticationService;

        public ServiceManager(IRepositoryManager RepositoryManager, IMapper Mapper,
                              ILoggerManager Logger, IFileStorageService FileStorageService,
                              StaticFilePaths FileStorageSettings, IDataShaperFactory DataShaperFactory, 
                              UserManager<User> UserManager, IConfiguration Configuration)
        {

            _CountryService = new Lazy<ICountryService>(() => new CountryService(RepositoryManager, Logger, Mapper, DataShaperFactory.Create<CountryDTO>()));
            _CityService = new Lazy<ICityService>(() => new CityService(RepositoryManager, Logger, Mapper, DataShaperFactory.Create<CityDTO>()));
            _PersonService = new Lazy<IPersonService>(() => new PersonService(RepositoryManager, Mapper, FileStorageService, FileStorageSettings));
            _TeamService = new Lazy<ITeamService>(() => new TeamService(RepositoryManager, Logger, Mapper, FileStorageService, DataShaperFactory.Create<TeamDTO>()));
            _TeamServicev2 = new Lazy<ITeamServicev2>(() => new TeamServicev2(RepositoryManager, Mapper, DataShaperFactory.Create<TeamDTOv2>()));
            _PlayerService = new Lazy<IPlayerService>(() => new PlayerService(RepositoryManager, Logger, Mapper, DataShaperFactory.Create<PlayerDTO>()));
            _MatchService = new Lazy<IMatchService>(() => new MatchService(RepositoryManager, Mapper, DataShaperFactory.Create<MatchDTO>()));

            _AuthenticationService = new Lazy<IAuthenticationService>(() => new AuthenticationService(Logger, Mapper, UserManager, Configuration));

        }

        public ICountryService CountryService => _CountryService.Value;
        public ICityService CityService => _CityService.Value;
        public IPersonService PersonService => _PersonService.Value;
        public ITeamService TeamService => _TeamService.Value;
        public ITeamServicev2 TeamServicev2 => _TeamServicev2.Value;
        public IPlayerService PlayerService => _PlayerService.Value;
        public IMatchService MatchService => _MatchService.Value;

        public IAuthenticationService AuthenticationService => _AuthenticationService.Value;
    }
}
