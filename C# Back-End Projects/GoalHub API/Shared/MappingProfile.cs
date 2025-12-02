using AutoMapper;
using Entities.Models;
using Shared.DataTransferObjects.City;
using Shared.DataTransferObjects.Country;
using Shared.DataTransferObjects.Match;
using Shared.DataTransferObjects.Person;
using Shared.DataTransferObjects.Player;
using Shared.DataTransferObjects.Stadium;
using Shared.DataTransferObjects.Team;
using Shared.DataTransferObjects.User;

namespace Shared
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {

            CreateMap<Country, CountryDTO>();
            CreateMap<CountryCreationDTO, Country>();
            CreateMap<Country, CountryWithCitiesDTO>();

            CreateMap<City, CityDTO>();
            CreateMap<City, CityWithoutCountryDTO>();
            CreateMap<CityCreationDTO, City>();
            CreateMap<City, CityForUpdateDto>().ReverseMap();

            CreateMap<Person, PersonDTO>();
            CreateMap<PersonCreationDTO, Person>();
            CreateMap<Person, PlayerForUpdateDTO>().ReverseMap();

            CreateMap<Team, TeamDTO>();
            CreateMap<TeamCreationDTO, Team>();
            CreateMap<Team, TeamForUpdateDto>().ReverseMap();
            CreateMap<Team, TeamDTOv2>();

            CreateMap<Stadium, StadiumDTO>();

            CreateMap<Player, PlayerDTO>();
            CreateMap<PlayerStatus, PlayerStatusDTO>().ReverseMap();
            CreateMap<PlayerCreationDTO, Player>();
            CreateMap<Player, PlayerForUpdateDTO>().ReverseMap();

            CreateMap<Match, MatchDTO>();
            CreateMap<MatchCreationDTO, Match>();
            CreateMap<Match, MatchForPatchDTO>().ReverseMap();
            CreateMap<MatchStatus, MatchStatusDTO>().ReverseMap();

            CreateMap<UserForRegistrationDto, User>();

        }


    }
}
