using System.Collections.Generic;

namespace HeroSchool.Interfaces
{
    public interface ISchool
    {
        string Name { get; }
        List<IPlayer> Players { get; }

        bool AddPlayer(IPlayer p_player);
        IPlayer GetPlayer(string p_playerName);

    }
}