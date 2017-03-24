using System.Collections.Generic;

namespace HeroSchool
{
    public interface ISchool
    {
        string Name { get; }
        List<Player> Players { get; }

        bool AddPlayer(Player p_player);
        Player GetPlayer(string p_playerName);

    }
}