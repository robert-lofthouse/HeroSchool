using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroSchool
{
    public class PlayersMaster : List<Player>
    {
        /// <summary>
        /// Create a new player object and add it to the players collection
        /// </summary>
        /// <param name="p_Playername"></param>
        /// <returns></returns>
        public Player CreatePlayer(string p_Playername)
        {
            try
            {
                Player newPlayer = null;
                if (this.Exists(c => c.PlayerName == p_Playername))
                {
                    throw new Exception(string.Format("{0} already exists in the player list", p_Playername));
                }
                else
                {
                    newPlayer = new Player(p_Playername);
                    this.Add(newPlayer);
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
