using AutoMapper;
using Contracts;
using Contracts.DataShaping;
using Contracts.ILogging;
using Contracts.IServices.Entities_IServices;
using Contracts.Repositories.IRepositories;
using Entities.Exceptions;
using Entities.Models;
using Entities.Responses;
using Entities.Responses.Entities_Responses.Country;
using Entities.Responses.Entities_Responses.Team;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Shared.DataTransferObjects.City;
using Shared.DataTransferObjects.Country;
using Shared.DataTransferObjects.Player;
using Shared.DataTransferObjects.Team;
using Shared.Exceptions.Country_Exceptions;
using Shared.RequestFeatures;
using Shared.RequestFeatures.City;
using Shared.RequestFeatures.Player;
using System.Dynamic;
using static Contracts.IFileStorageService;

namespace Service.Entities_Services
{
    public class TeamService : ITeamService
    {
        private readonly IRepositoryManager _Repository;
        private readonly ILoggerManager _Logger;
        private readonly IMapper _Mapper;
        private readonly IFileStorageService _FileStorageService;
        private readonly IDataShaper<TeamDTO> _Shaper;

        public TeamService(IRepositoryManager Repository, ILoggerManager Logger,
                              IMapper Mapper, IFileStorageService FileStorageService, IDataShaper<TeamDTO> shaper)
        {
            _Repository = Repository;
            _Logger = Logger;
            _Mapper = Mapper;
            _FileStorageService = FileStorageService;
            _Shaper = shaper;
        }

        public async Task<ApiBaseResponse> CreateTeamAsync(TeamCreationDTO Team)
        {

            Team TeamEntity = _Mapper.Map<Team>(Team);
            TeamEntity.IsDeleted = false;

            await _Repository.Team.CreateTeam(TeamEntity);
            
            await _Repository.SaveAsync();

            TeamEntity = await CheckIfTeamExists(TeamEntity.ID, false);

            TeamDTO TeamToReturn = _Mapper.Map<TeamDTO>(TeamEntity);

            if (TeamToReturn == null)
                throw new CreationFailedException("Failed to Create Team");

            return new ApiOkResponse<TeamDTO>(TeamToReturn);
        }

        public async Task<ApiBaseResponse> DeleteTeamAsync(int TeamID, bool trackChanges)
        {
            Team? Team = await CheckIfTeamExists(TeamID, trackChanges);

            if (Team == null)
                return new TeamNotFoundResponse(TeamID);

            try
            {

                await _Repository.Team.DeleteTeam(Team);

                await _Repository.SaveAsync();

                _Logger.LogWarn($"Team with id: {TeamID} has been deleted.");

                return new TeamDeletedResponse(true);

            }
            catch (DbUpdateException ex)
            {
                throw new DeletionFailedException($"Failed to Delete Country with ID {TeamID}: {ex.Message}");
            }

        }

        public async Task<(IEnumerable<ExpandoObject> Teams, MetaData MetaData)> GetAllTeamsAsync(TeamParameters TeamParameters, bool trackChanges)
        {

            PagedList<Team> TeamsWithMetaData = await _Repository.Team.GetAllTeamsAsync(TeamParameters, trackChanges);

            if (TeamsWithMetaData is null)
                throw new EmptyCollectionException("No Teams were found in the database.");

            IEnumerable<TeamDTO> TeamsToReturn = _Mapper.Map<IEnumerable<TeamDTO>>(TeamsWithMetaData);

            IEnumerable<ExpandoObject> ShapedData = _Shaper.ShapeData(TeamsToReturn, TeamParameters.Fields);

            return (Teams: ShapedData, MetaData: TeamsWithMetaData.MetaData);
        }

        public async Task<ApiBaseResponse> GetTeamAsync(int TeamID, bool trackChanges)
        {
            Team? Team = await CheckIfTeamExists(TeamID, trackChanges);

            if (Team is null)
                return new TeamNotFoundResponse(TeamID);

            TeamDTO TeamToReturn = _Mapper.Map<TeamDTO>(Team);

            return new ApiOkResponse<TeamDTO>(TeamToReturn);
        }

        private async Task<Team> CheckIfTeamExists(int ID, bool trackChanges)
        {
            Team? Team = await _Repository.Team.GetTeamAsync(ID, trackChanges);

            if (Team is null)
                throw new TeamNotFoundException(ID);

            return Team;
        }

        public async Task<(TeamForUpdateDto TeamToPatch, Team TeamEntity)> GetTeamForPatchAsync(int TeamID, bool TrackChanges)
        {

            Team? TeamEntity = await CheckIfTeamExists(TeamID, TrackChanges);

            TeamForUpdateDto TeamToPatch = _Mapper.Map<TeamForUpdateDto>(TeamEntity);

            return (TeamToPatch, TeamEntity);

        }

        public async Task SaveChangesForPatchAsync(TeamForUpdateDto TeamToPatch, Team TeamEntity)
        {
            _Mapper.Map(TeamToPatch, TeamEntity);

            await _Repository.SaveAsync();
        }

        public async Task<ApiBaseResponse> UpdateTeamLogoAsync(int ID, IFormFile Logo)
        {
            if (Logo == null || Logo.Length == 0)
                throw new BadRequestException("Logo file is missing.");

            if (!_FileStorageService.ValidateExtension(Logo, enFileType.Image))
            {

                throw new InvalidOperationException($"Invalid file type.");

            }

            Team Team = await CheckIfTeamExists(ID, true);

            if (!string.IsNullOrEmpty(Team.Logo) && File.Exists(Team.Logo))
            {
                    File.Delete(Team.Logo);
            }

            string FileName = $"Team_{Team.ID}";

            string FilePath = await _FileStorageService.SaveFileAsync(Logo, FileName, enFileType.Image);

            if(string.IsNullOrEmpty(FilePath))
                return new ApiOkResponse<bool>(false);

            Team.Logo = FilePath;

            await _Repository.SaveAsync();

            return new ApiOkResponse<bool>(true);

        }

      
    }
}
