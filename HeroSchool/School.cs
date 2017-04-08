using HeroSchool.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroSchool
{
    public class School : ISchool
    {
        private List<IPlayer> _players;

        public IReadOnlyCollection<IPlayer> Players { get; }

        public string Name { get; set; }
        public string _id { get; }

        public string CollectionName { get => "School"; }

        public School(string p_name)
        {
            Name = p_name;
            _id = Guid.NewGuid().ToString();
            _players = new List<IPlayer>();
            Players = _players.AsReadOnly();
        }

        public bool AddPlayer(IPlayer p_player)
        {
            try
            {
                _players.Add(p_player);

                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw;
            }
        }

        public IPlayer GetPlayer(string p_playerName)
        {
            return _players.Find(x => x.Name == p_playerName);
        }
    }
}
