using HeroSchool.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroSchool.Repositories
{
    public class PlayersMaster : List<IPlayer>
    {
        public void CreatePlayer(string v)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// returns all cards matching the name and type passed in 
        /// </summary>
        /// <param name="CardName"></param>
        /// <param name="p_cardType"></param>
        /// <returns></returns>
        public IPlayer GetPlayer(string p_playerName)
        {
            return Find(x => x.PlayerName == p_playerName);
        }

    }
}
