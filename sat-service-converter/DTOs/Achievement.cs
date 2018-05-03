using sat_contracts.models.ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sat_service_converter.DTOs
{
    public class Achievement : IAchievement
    {
        public string Name { get; set; }
        public long DefaultValue { get; set; }
        public string DisplayName { get; set; }
        public int Hidden { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public string Icongray { get; set; }

        public Achievement(SteamApiWrapper.Models.SchemaForGame.Achievement a)
        {
            this.Name = a.name;
            this.DefaultValue = a.defaultvalue;
            this.DisplayName = a.displayName;
            this.Hidden = a.hidden;
            this.Description = a.description;
            this.Icon = a.icon;
            this.Icongray = a.icongray;
        }
    }
}
