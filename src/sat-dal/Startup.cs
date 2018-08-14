using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using sat_dal.DTOs;
using sat_dal.Models;

namespace sat_dal
{
    public static class Startup
    {
        public static void RegisterMaps()
        {
           // Mapper.Reset();
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<GameAchievement, GameAchievementDTO>();
                cfg.CreateMap<GameAchievementDTO, GameAchievement>();

                cfg.CreateMap<GameSchema, GameSchemaDTO>();
                cfg.CreateMap<GameSchemaDTO, GameSchema>();

                cfg.CreateMap<PlayerGame, PlayerGameDTO>();
                cfg.CreateMap<PlayerGameDTO, PlayerGame>();

                cfg.CreateMap<PlayerGameAchievement, PlayerGameAchievementDTO>();
                cfg.CreateMap<PlayerGameAchievementDTO, PlayerGameAchievement>();


                cfg.CreateMap<PlayerProfile, PlayerProfileDTO>();
                cfg.CreateMap<PlayerProfileDTO, PlayerProfile>();

                cfg.CreateMap<ProfileRecentGame, ProfileRecentGameDTO>();
                cfg.CreateMap<ProfileRecentGameDTO, ProfileRecentGame>();

            });
        }

        public static void ResetMaps()
        {
            Mapper.Reset();
        }
    }
}
