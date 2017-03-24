using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroSchool
{
    public class School : ISchool
    {
        private List<Player> players;

        public List<Player> Players { get => players; }

        public School()
        {
            players = new List<Player>();
        }
                
        public bool AddPlayer(Player p_player)
        {
            try
            {
                players.Add(p_player);
                return true;

            }
            catch (Exception ex)
            {
                return false;
                throw;
            }
        }

        public Player GetPlayer(string p_playerName)
        {
            return players.Find(x => x.PlayerName == p_playerName);
        }
    }
}
