using sat_contracts.models.ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sat_service_converter.DTOs
{
    public class AvailableGameStats : IAvailableGameStats
    {
        public IAchievement[] Achievements { get; set; }
        public IStat[] Stats { get; set; }

        public AvailableGameStats(SteamApiWrapper.Models.SchemaForGame.Availablegamestats a)
        {
            List<Stat> stats = new List<Stat>();
            if (a.stats != null)
            {
                foreach (var item in a.stats)
                {
                    stats.Add(new Stat(item));
                }
                this.Stats = stats.ToArray();
            }

            if (a.achievements != null)
            {
                List<Achievement> ach = new List<Achievement>();
                foreach (var item in a.achievements)
                {
                    ach.Add(new Achievement(item));
                }
                this.Achievements = ach.ToArray();
            }
        }
    }
}
