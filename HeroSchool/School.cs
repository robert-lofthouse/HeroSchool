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
        private string _schoolName;

        public IReadOnlyCollection<IPlayer> Players { get; }

        public string Name { get => _schoolName; set => _schoolName = value; }

        public School(string p_name)
        {
            _schoolName = p_name;
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

        public Player GetPlayer(string p_playerName)
        {
            return (Player)_players.Find(x => x.Name == p_playerName);
        }
    }
}
