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

        private string _name;
        private IList<ICard> _cardCollection = new List<ICard>();
        private List<IHero> _heroes = new List<IHero>();
        private IRepository<ICard> _cardRepository;

        #endregion
        public IList<ICard> CardCollection()
        {
            return _cardCollection;
        }

        public IReadOnlyCollection<IHero> Heroes { get => _heroes; }

        public void AddHero(IHero p_hero) => _heroes.Add(p_hero);

        //Player's Name
        public string Name
        {
            get => _name;
            set => throw new NotImplementedException();
        }

        public string _id { get; }

        //Constructore
        public Player(string p_playerName, IRepository<ICard> p_cardRepository)
        {
            _id = Guid.NewGuid().ToString();
            _name = p_playerName;
            _cardRepository = p_cardRepository;
        }

        /// <summary>
        /// Returns a Card from the Cards Collection owned by the player
        /// </summary>
        /// <param name="cardName"></param>
        /// <param name="p_ID"></param>
        /// <returns></returns>
        public ICard GetCard(string p_ID)
        {
            return _cardCollection.FirstOrDefault(x => x._id == p_ID);
        }

        /// <summary>
        /// Adds an attack, defense or Modifier card to the card collection for the player
        /// </summary>
        /// <param name="p_card"></param>
        public void AddCardtoCollection(ICard p_card)
        {
            if (_cardRepository.Get(p_card) != null)
                _cardCollection.Insert(0, p_card);
        }
    }
}
