using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sat_contracts.models;

namespace sat_dal.Models
{
    public class PlayerGameAchievement : IPlayerGameAchievement
    {


        public long SteamId { get; set; }

        public long AppID { get; set; }

        public string ApiName { get; set; }

        public bool Achieved { get; set; }

        public DateTime? UnlockTimestamp { get; set; }

        public virtual PlayerProfile PlayerProfile { get; set; }

        public virtual PlayerGame PlayerGame { get; set; }
    }
}
