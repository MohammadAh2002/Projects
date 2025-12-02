using AutoMapper;
using Contracts.DataShaping;
using Contracts.ILogging;
using Contracts.IServices.Entities_IServices;
using Contracts.Repositories.IRepositories;
using Entities.Exceptions;
using Entities.Models;
using Entities.Responses;
using Microsoft.EntityFrameworkCore;
using Shared.DataTransferObjects.City;
using Shared.DataTransferObjects.Country;
using Shared.DataTransferObjects.Person;
using Shared.DataTransferObjects.Player;
using Shared.Exceptions.Player_Exeptions;
using Shared.RequestFeatures;
using Shared.RequestFeatures.City;
using Shared.RequestFeatures.Player;
using System.Dynamic;

namespace Service.Entities_Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IRepositoryManager _Repository;
        private readonly ILoggerManager _Logger;
        private readonly IMapper _Mapper;
        private readonly IDataShaper<PlayerDTO> _Shaper;
        public PlayerService(IRepositoryManager Repository, ILoggerManager Logger,
                              IMapper Mapper, IDataShaper<PlayerDTO> shaper)
        {
            _Repository = Repository;
            _Logger = Logger;
            _Mapper = Mapper;
            _Shaper = shaper;
        }

        public async Task<ApiBaseResponse> CreatePlayerAsync(PlayerCreationDTO Player, bool trackChanges)
        {

            Player PlayerEntity = _Mapper.Map<Player>(Player);

            await _Repository.Player.CreatePlayerAsync(PlayerEntity);

            await _Repository.SaveAsync();

            PlayerStatus playerStatus = new PlayerStatus
            {
                PlayerID = PlayerEntity.ID,
                Goals = 0,
                Assists = 0,
                YellowCards = 0,
                RedCards = 0
            };

            await _Repository.PlayerStatus.CreatePlayerStatusAsync(playerStatus);
            await _Repository.SaveAsync();


            PlayerDTO PlayerToReturn = _Mapper.Map<PlayerDTO>(PlayerEntity);

            if (PlayerToReturn == null)
                throw new CreationFailedException("Failed to Create Player");

            return new ApiOkResponse<PlayerDTO>(PlayerToReturn);
        }

        public async Task DeletePlayerAsync(int PlayerID, bool trackChanges)
        {
            Player? Player = await CheckIfPlayerExists(PlayerID, trackChanges);

            if (Player == null)
                throw new PlayerNotFoundException(Player.ID);

            try
            {

                await _Repository.Player.DeletePlayerAsync(Player);

                await _Repository.SaveAsync();

                _Logger.LogWarn($"Player with id: {PlayerID} has been deleted.");

            }
            catch (DbUpdateException ex)
            {
                throw new DeletionFailedException($"Failed to Delete Player with ID {PlayerID}: {ex.Message}");
            }

        }

        public async Task<(IEnumerable<ExpandoObject> Players, MetaData MetaData)> GetAllPlayersAsync(PlayerParameters PlayerParameters, bool trackChanges)
        {

            PagedList<Player> PlayersWithMetaData = await _Repository.Player.GetAllPlayersAsync(PlayerParameters, trackChanges);

            if (PlayersWithMetaData is null)
                throw new EmptyCollectionException("No Players were found in the database");

            IEnumerable<PlayerDTO> PlayerToReturn = _Mapper.Map<IEnumerable<PlayerDTO>>(PlayersWithMetaData);

            IEnumerable<ExpandoObject> ShapedData = _Shaper.ShapeData(PlayerToReturn, PlayerParameters.Fields);

            return (Players: ShapedData, MetaData: PlayersWithMetaData.MetaData);
        }

        public async Task<ApiBaseResponse> GetPlayerAsync(int PlayerID, bool trackChanges)
        {
            Player? Player = await CheckIfPlayerExists(PlayerID, trackChanges);

            PlayerDTO PlayerToReturn = _Mapper.Map<PlayerDTO>(Player);

            return new ApiOkResponse<PlayerDTO>(PlayerToReturn);
        }

        public async Task<(PlayerForUpdateDTO PlayerToPatch, Player PlayerEntity)> GetPlayerForPatchAsync(int PlayerID, bool PlayerTrackChanges)
        {
            Player? PlayerEntity = await CheckIfPlayerExists(PlayerID, PlayerTrackChanges);

            PlayerForUpdateDTO PlayerToPatch = _Mapper.Map<PlayerForUpdateDTO>(PlayerEntity);

            return (PlayerToPatch, PlayerEntity);
        }

        public async Task SaveChangesForPatchAsync(PlayerForUpdateDTO PlayerToPatch, Player PlayerEntity)
        {
            _Mapper.Map(PlayerToPatch, PlayerEntity);
             
            await _Repository.SaveAsync();
        }

        public async Task UpdatePlayerAsync(int PlayerID, PlayerForUpdateDTO Player, bool trackChanges)
        {
            Player? PlayerEntity = await CheckIfPlayerExists(PlayerID, trackChanges);

            if (PlayerEntity == null)
                throw new PlayerNotFoundException(PlayerID);

            _Mapper.Map(Player, PlayerEntity);

            await _Repository.Player.UpdatePlayer(PlayerEntity);

            await _Repository.SaveAsync();
        }

        public async Task UpdatePlayerStatusAsync(int PlayerID, PlayerStatusDTO PlayerStatus, bool trackChanges)
        {
            Player? PlayerEntity = await CheckIfPlayerExists(PlayerID, trackChanges);

            if (PlayerEntity == null)
                throw new PlayerNotFoundException(PlayerID);

            PlayerEntity.Status = _Mapper.Map<PlayerStatus>(PlayerStatus);

            await _Repository.PlayerStatus.UpdatePlayerStatusAsync(PlayerEntity.Status);
            await _Repository.SaveAsync();

        }

        private async Task<Player> CheckIfPlayerExists(int ID, bool trackChanges)
        {
            Player? Player = await _Repository.Player.GetPlayerAsync(ID, trackChanges);

            if (Player is null)
                throw new PlayerNotFoundException(ID);

            return Player;
        }

    }
}
