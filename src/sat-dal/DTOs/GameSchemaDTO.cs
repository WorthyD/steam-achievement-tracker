using sat_contracts.models;
using System;
using System.Collections.Generic;
using System.Text;

namespace sat_dal.DTOs
{
    public class GameSchemaDTO : IGameSchema
    {
        public long AppId { get; set; }

        public string Name { get; set; }

        public DateTime LastSchemaUpdate { get; set; }


        public bool HasAchievements { get; set; }

        public string ImgIconUrl { get; set; }

        public string ImgLogoUrl { get; set; }

        public bool HasCommunityVisibleStats { get; set; }

        public int AvgUnlock { get; set; }

        public IList<IGameAchievement> GameAchievements { get; set; }
    }

}
