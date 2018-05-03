using sat_contracts.models.ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sat_service_converter.DTOs
{
    public class Stat : IStat
    {
        public string Name { get ; set ; }
        public long Defaultvalue { get ; set ; }
        public string DisplayName { get ; set ; }
        public Stat(SteamApiWrapper.Models.SchemaForGame.Stat s)
        {
            this.Name = s.name;
            this.Defaultvalue = s.defaultvalue;
            this.DisplayName = s.displayName;
        }
    }
}
