using sat_contracts.models.ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sat_service_converter.DTOs
{
    public class AchievementPercentage : IAchievementPercentage
    {
        public string Name { get; set; }
        public float Percent { get; set; }
        public AchievementPercentage(SteamApiWrapper.Models.GlobalAchievementPercentages.Achievement a)
        {
            this.Name = a.name;
            this.Percent = a.percent;
        }
        //public static List<AchievementPercentage> Bulk(List<SteamApiWrapper.Models.GlobalAchievementPercentages.Achievement> achievements)
        //{
        //    List<AchievementPercentage> aps = new List<AchievementPercentage>();
        //    foreach(var a in achievements)
        //    {
        //        aps.Add(new AchievementPercentage(a));
        //    }
        //    return aps;
            
        //}
    }
}
