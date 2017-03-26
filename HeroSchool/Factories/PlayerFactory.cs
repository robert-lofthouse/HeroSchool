using HeroSchool.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroSchool.Factories
{
    static class PlayerFactory
    {
        /// <summary>
        /// Create a new player object and add it to the players collection
        /// </summary>
        /// <param name="p_Playername"></param>
        /// <param name="p_playerList"></param>
        /// <returns></returns>
        static public IPlayer CreatePlayer(string p_Playername, List<IPlayer> p_playerList)
        {
            try
            {
                IPlayer newPlayer = null;
                if (p_playerList.Exists(c => c.PlayerName == p_Playername))
                {
                    throw new Exception(string.Format("{0} already exists in the player list", p_Playername));
                }
                else
                {
                    newPlayer = new Player(p_Playername);
                    p_playerList.Add(newPlayer);
                }
                return newPlayer;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
