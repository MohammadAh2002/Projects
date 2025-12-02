using AutoMapper;
using Contracts.DataShaping;
using Contracts.IServices.Entities_IServices;
using Contracts.Repositories.IRepositories;
using Entities.Exceptions;
using Entities.Models;
using Entities.Responses;
using Shared.DataTransferObjects.City;
using Shared.DataTransferObjects.Country;
using Shared.DataTransferObjects.Match;
using Shared.DataTransferObjects.Player;
using Shared.RequestFeatures;
using Shared.RequestFeatures.City;
using Shared.RequestFeatures.Match;
using System.Dynamic;


namespace Service.Entities_Services
{
    public class MatchService : IMatchService
    {
        private readonly IRepositoryManager _Repository;
        private readonly IMapper _Mapper;
        private readonly IDataShaper<MatchDTO> _Shaper;

        public MatchService(IRepositoryManager Repository, IMapper Mapper, IDataShaper<MatchDTO> shaper)
        {
            _Repository = Repository;
            _Mapper = Mapper;
            _Shaper = shaper;
        }

        public async Task<ApiBaseResponse> CreateMatchAsync(MatchCreationDTO Match, bool trackChanges)
        {
            Match MatchEntity = _Mapper.Map<Match>(Match);

            await _Repository.Match.CreateMatchAsync(MatchEntity);

            await _Repository.SaveAsync();

            MatchEntity = await CheckIfMatchExists(MatchEntity.ID, trackChanges);

            MatchDTO MatchToReturn = _Mapper.Map<MatchDTO>(MatchEntity);

            if (MatchToReturn == null)
                throw new CreationFailedException("Failed to Create Match");

            return new ApiOkResponse<MatchDTO>(MatchToReturn);
        }   

        public async Task<(IEnumerable<ExpandoObject> Matchs, MetaData MetaData)> GetAllMatchsAsync(MatchParameters MatchsParameters, bool trackChanges)
        {
            PagedList<Match> MatchsWithMetaData = await _Repository.Match.GetAllMatchAsync(MatchsParameters, trackChanges);

            if (MatchsWithMetaData is null)
                throw new EmptyCollectionException("No Matchs were found in the database");

            IEnumerable<MatchDTO> MatchsToReturn = _Mapper.Map<IEnumerable<MatchDTO>>(MatchsWithMetaData);

            IEnumerable<ExpandoObject> ShapedData = _Shaper.ShapeData(MatchsToReturn, MatchsParameters.Fields);

            return (Matchs: ShapedData, MetaData: MatchsWithMetaData.MetaData);
        }

        public async Task<ApiBaseResponse> GetMatchAsync(long MatchID, bool trackChanges)
        {
            Match? Match = await CheckIfMatchExists(MatchID, trackChanges);

            MatchDTO MatchToReturn = _Mapper.Map<MatchDTO>(Match);

            return new ApiOkResponse<MatchDTO>(MatchToReturn);
        }

        public async Task<(MatchForPatchDTO MatchToPatch, Match MatchEntity)> GetMatchForPatchAsync(long MtachID, bool TrackChanges)
        {
            Match? MatchEntity = await CheckIfMatchExists(MtachID, TrackChanges);

            MatchForPatchDTO MatchToPatch = _Mapper.Map<MatchForPatchDTO>(MatchEntity);

            return (MatchToPatch, MatchEntity);
        }

        public async Task SaveChangesForPatchAsync(MatchForPatchDTO MatchToPatch, Match MatchEntity)
        {
            _Mapper.Map(MatchToPatch, MatchEntity);

            await _Repository.SaveAsync();
        }

        private async Task<Match> CheckIfMatchExists(long ID, bool trackChanges)
        {
            Match? Match = await _Repository.Match.GetMatchAsync(ID, trackChanges);

            if (Match is null)
                throw new NotFoundException($"Mtach with id: {ID} not Found in Database");

            return Match;
        }

    }
}
