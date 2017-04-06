using HeroSchool.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroSchool.Factories
{
    public static class PlayerFactory
    {
        /// <summary>
        /// Create a new player object and add it to the players collection
        /// </summary>
        /// <param name="p_Playername"></param>
        /// <param name="p_cardRepo"></param>
        /// <param name="p_playerList"></param>
        /// <returns></returns>
        public static IPlayer CreatePlayer(string p_Playername, IRepository<ICard> p_cardRepo)
        {
            try
            {
                return new Player(p_Playername, p_cardRepo);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
