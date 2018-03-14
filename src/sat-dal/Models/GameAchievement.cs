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
    //Todo add game table for better updating
    public class GameAchievement : IGameAchievement
    {
        public long AppId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }


        public string DisplayName { get; set; }

        public bool Hidden { get; set; }

        public string Icon { get; set; }

        public string IconGray { get; set; }

        public double Percent { get; set; }

        public virtual GameSchema GameSchema { get; set; }


    }
}
