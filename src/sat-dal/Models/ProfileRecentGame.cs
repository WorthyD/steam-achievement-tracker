using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sat_contracts.models;

namespace sat_dal.Models {
    public class ProfileRecentGame
    {

        public long SteamId { get; set; }

        public long AppId { get; set; }

        public virtual PlayerProfile PlayerProfile { get; set; }
        public virtual GameSchema GameSchema { get; set; }
    }
}
