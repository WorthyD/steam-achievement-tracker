using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sat_contracts.models
{
    public interface IGameSchema
    {
        long AppId { get; set; }
        string Name { get; set; }
        string ImgIconUrl { get; set; }
        string ImgLogoUrl { get; set; }
        bool HasCommunityVisibleStats { get; set; }
        DateTime LastSchemaUpdate { get; set; }
        int AvgUnlock { get; set; }
        bool HasAchievements { get; set; }
    }
}
