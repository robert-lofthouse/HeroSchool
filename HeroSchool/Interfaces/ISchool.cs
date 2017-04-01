using System.Collections.Generic;

namespace HeroSchool.Interfaces
{
    public interface ISchool : IHeroSchool
    {
        List<IPlayer> Players();

        bool AddPlayer(IPlayer p_player);
        Player GetPlayer(string p_playerName);

    }
}