using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroSchool
{

    class School : ISchool
    {
        private List<Player> players;
        private string schoolName;

        public List<Player> Players { get => players; }

        public string Name { get => schoolName;  }

        public School(string p_name)
        {
            schoolName = p_name;
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
