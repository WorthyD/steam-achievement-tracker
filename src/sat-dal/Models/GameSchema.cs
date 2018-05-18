using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sat_contracts.models;

namespace sat_dal.Models
{
    public class GameSchema
    {
        public long AppId { get; set; }

        public string Name { get; set; }

        public DateTime LastSchemaUpdate { get; set; }

        public bool HasAchievements { get; set; }

        //public string ImgIconUrl { get; set; }

        //public string ImgLogoUrl { get; set; }


        public virtual List<GameAchievement> GameAchievements { get; set; }

        public virtual List<PlayerGame> PlayerGames { get; set; }

        public bool HasCommunityVisibleStats
        {
            get; set;
        }

        public int AvgUnlock { get; set; }

    }
}
