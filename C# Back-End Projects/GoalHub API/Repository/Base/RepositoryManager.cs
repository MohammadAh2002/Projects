using Contracts.Repositories.Entities_IRepositories;
using Contracts.Repositories.IRepositories;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.Entities_Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Base
{
    public sealed class RepositoryManager<TContext> : IRepositoryManager
        where TContext : DbContext
    {
        private readonly TContext _context;

        private readonly GoalHubSQLContext _RepositoryContext;
        private readonly Lazy<ICountryRepository> _CountryRepository;
        private readonly Lazy<ICityRepository> _CityRepository;
        private readonly Lazy<IPersonRepository> _PersonRepository;
        private readonly Lazy<ITeamRepository> _TeamRepository;
        private readonly Lazy<ITeamRepositoryv2> _TeamRepositoryv2;
        private readonly Lazy<IPlayerRepository> _PlayerRepository;
        private readonly Lazy<IPlayerStatusRepository> _PlayerStatusRepository;
        private readonly Lazy<IMatchRepository> _MatchRepository;


        public RepositoryManager(TContext context)
        {

            _context = context;

            _CountryRepository = new Lazy<ICountryRepository>(() => new CountryRepository<TContext>(_context));
            _CityRepository = new Lazy<ICityRepository>(() => new CityRepository<TContext>(_context));
            _PersonRepository = new Lazy<IPersonRepository>(() => new PersonRepository<TContext>(_context));
            _TeamRepository = new Lazy<ITeamRepository>(() => new TeamRepository<TContext>(_context));
            _TeamRepositoryv2 = new Lazy<ITeamRepositoryv2>(() => new TeamRepositoryv2<TContext>(_context));
            _PlayerRepository = new Lazy<IPlayerRepository>(() => new PlayerRepository<TContext>(_context));
            _PlayerStatusRepository = new Lazy<IPlayerStatusRepository>(() => new PlayerStatusRepository<TContext>(_context));
            _MatchRepository = new Lazy<IMatchRepository>(() => new MatchRepository<TContext>(_context));

        }

        public ICountryRepository Country => _CountryRepository.Value;
        public ICityRepository City => _CityRepository.Value;
        public IPersonRepository Person => _PersonRepository.Value;

        public ITeamRepository Team => _TeamRepository.Value;
        public ITeamRepositoryv2 Teamv2 => _TeamRepositoryv2.Value;

        public IPlayerRepository Player => _PlayerRepository.Value;
        public IPlayerStatusRepository PlayerStatus => _PlayerStatusRepository.Value;

        public IMatchRepository Match => _MatchRepository.Value;

        public Task SaveAsync()
        {
            return _context.SaveChangesAsync();
        }

    }
}
