using System;
using System.Collections.Generic;
using System.Text;

namespace sat_contracts.models
{
    public interface IFullGameDetails
    {
        IPlayerGame PlayerGame { get; set; }
        IGameSchema Schema { get; set; }
    }
}
