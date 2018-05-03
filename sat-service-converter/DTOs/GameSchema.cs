using sat_contracts.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sat_service_converter.DTOs
{
    public class GameSchema : IGameSchema
    {
        public long AppId { get; set; }
        public string ImgIconUrl { get; set; }
        public string ImgLogoUrl { get; set; }
        public bool HasCommunityVisibleStats { get; set; }
        public DateTime LastSchemaUpdate { get; set; }
        public int AvgUnlock { get; set; }
        public bool HasAchievements { get; set; }
        public IList<IGameAchievement> GameAchievements { get; set; }

        public GameSchema(SteamApiWrapper.Models.SchemaForGame.Game a)
        {
            //this.AppId = a.app
            //this.AppId = game.game.

        }
    }
}
