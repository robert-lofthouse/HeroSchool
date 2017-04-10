using HeroSchool.Interfaces;
using HeroSchool.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroSchool
{
    public class Player : IPlayer
    {
        #region Private variables

        private List<Hero> _heroes = new List<Hero>();
        private IRepository<Card> _cardRepository;

        #endregion
        public IList<Card> CardCollection { get; set; }

        public IList<Hero> Heroes { get { return _heroes; } set { _heroes = (List<Hero>)value; } }

        public void AddHero(Hero p_hero) => _heroes.Add(p_hero);

        //Player's Name
        public string Name { get; set; }
        
        public string _id { get; }

        //Constructore
        public Player(string p_playerName, IRepository<Card> p_cardRepository, string p_id = "")
        {
            _id = p_id == "" ? Guid.NewGuid().ToString() : p_id;
            Name = p_playerName;
            _cardRepository = p_cardRepository;

            CardCollection = new List<Card>();
        }

        /// <summary>
        /// Returns a Card from the Cards Collection owned by the player
        /// </summary>
        /// <param name="cardName"></param>
        /// <param name="p_ID"></param>
        /// <returns></returns>
        public ICard GetCard(string p_ID)
        {
            return CardCollection.FirstOrDefault(x => x._id == p_ID);
        }

        /// <summary>
        /// Adds an attack, defense or Modifier card to the card collection for the player
        /// </summary>
        /// <param name="p_card"></param>
        public void AddCardtoCollection(Card p_card)
        {
            if (_cardRepository.Get(new KeyValuePair<string, string>("_id", p_card._id)) != null)
                CardCollection.Insert(0, p_card);
        }
    }
}
