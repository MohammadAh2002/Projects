using AutoMapper;
using Contracts.DataShaping;
using Contracts.ILogging;
using Contracts.IServices.Entities_IServices;
using Contracts.Repositories.IRepositories;
using Entities.Exceptions;
using Entities.Models;
using Entities.Responses;
using Entities.Responses.Entities_Responses.Team;
using Repository;
using Shared.DataTransferObjects.Team;
using Shared.Exceptions.Country_Exceptions;
using Shared.RequestFeatures;
using Shared.RequestFeatures.Player;
using System.Dynamic;

namespace Service.Entities_Services
{
    public class TeamServicev2 : ITeamServicev2
    {
        private readonly IRepositoryManager _Repository;
        private readonly IMapper _Mapper;
        private readonly IDataShaper<TeamDTOv2> _Shaper;

        public TeamServicev2(IRepositoryManager Repository, IMapper Mapper, IDataShaper<TeamDTOv2> shaper)
        {
            _Repository = Repository;
            _Mapper = Mapper;
            _Shaper = shaper;
        }
        public async Task<(IEnumerable<ExpandoObject> Teams, MetaData MetaData)> GetAllTeamsAsync(TeamParameters TeamParameters, bool trackChanges)
        {

            PagedList<Team> TeamsWithMetaData = await _Repository.Teamv2.GetAllTeamsAsync(TeamParameters, trackChanges);

            if (TeamsWithMetaData is null)
                throw new EmptyCollectionException("No Teams were found in the database.");

            IEnumerable<TeamDTOv2> TeamsToReturn = _Mapper.Map<IEnumerable<TeamDTOv2>>(TeamsWithMetaData);

            IEnumerable<ExpandoObject> ShapedData = _Shaper.ShapeData(TeamsToReturn, TeamParameters.Fields);

            return (Teams: ShapedData, MetaData: TeamsWithMetaData.MetaData);


        }

        public async Task<ApiBaseResponse> GetTeamAsync(int TeamID, bool trackChanges)
        {
            Team? Team = await CheckIfTeamExists(TeamID, trackChanges);

            if (Team is null)
                return new TeamNotFoundResponse(TeamID);

            TeamDTOv2 TeamToReturn = _Mapper.Map<TeamDTOv2>(Team);

            return new ApiOkResponse<TeamDTOv2>(TeamToReturn);
        }

        private async Task<Team> CheckIfTeamExists(int ID, bool trackChanges)
        {
            Team? Team = await _Repository.Teamv2.GetTeamAsync(ID, trackChanges);

            if (Team is null)
                throw new TeamNotFoundException(ID);

            return Team;
        }

    }
}
