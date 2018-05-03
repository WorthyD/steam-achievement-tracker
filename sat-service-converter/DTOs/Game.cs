using sat_contracts.models.ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sat_service_converter.DTOs
{
    public class Game : IGame
    {
        public string GameName { get ; set ; }
        public string GameVersion { get ; set ; }
        public IAvailableGameStats AvailableGameStats { get ; set ; }

        public Game(SteamApiWrapper.Models.SchemaForGame.Game game) {
            this.GameName = game.gameName;
            this.GameVersion = game.gameVersion;
            this.AvailableGameStats =  new AvailableGameStats(game.availableGameStats);
        }
    }
}
