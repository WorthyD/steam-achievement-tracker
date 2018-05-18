using AutoMapper;
using sat_dal.DTOs;
using sat_dal.Models;

namespace sat_dal
{
    public class DalMappingProfile : Profile
    {
        public DalMappingProfile()
        {
            CreateMap<GameAchievement, GameAchievementDTO>().ReverseMap();

            CreateMap<GameSchema, GameSchemaDTO>().ReverseMap();

            CreateMap<PlayerGame, PlayerGameDTO>().ReverseMap();

            CreateMap<PlayerGameAchievement, PlayerGameAchievementDTO>().ReverseMap();

            CreateMap<PlayerProfile, PlayerProfileDTO>().ReverseMap();

            CreateMap<ProfileRecentGame, ProfileRecentGameDTO>().ReverseMap();
        }

    }
}
