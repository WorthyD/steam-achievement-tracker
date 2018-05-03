using sat_contracts.models.ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sat_service_converter.DTOs
{
    public class AchievementPercentages : IAchievementPercentages
    {
       public  List<IAchievementPercentage> ListAchievementPercentages { get; set; }

        public AchievementPercentages(List<SteamApiWrapper.Models.GlobalAchievementPercentages.Achievement> achievements)
        {
            this.ListAchievementPercentages = new List<IAchievementPercentage>();
            foreach (var a in achievements)
            {
                this.ListAchievementPercentages.Add(new AchievementPercentage(a));
            }


        }
    }
}
