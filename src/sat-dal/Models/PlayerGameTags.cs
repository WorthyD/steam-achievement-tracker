using sat_contracts.models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sat_dal.Models {
    public class PlayerGameTag : IPlayerGameTag{



        //[ForeignKey("PlayerProfiles")]
        public long PlayerID64 { get; set; }

        //[ForeignKey("PlayerGames")]
        public int AppID { get; set; }

        public string Tag { get; set; }



    }
}
