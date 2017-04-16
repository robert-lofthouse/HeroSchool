using HeroSchool.Interface;
using HeroSchool.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HeroSchool.Model
{
    public class Player : IPlayer
    {
        #region Private variables

        private List<Hero> _heroes = new List<Hero>();
        private IRepository<ICard> _cardRepository;

        #endregion
        public IList<Card> CardCollection()
        {
            return AttackCardCollection.Concat<Card>(DefenseCardCollection).ToList().Concat(ModifierCardCollection).ToList();
        }
        public string _id { get; set; }
        //Player's Name
        public string Name { get; set; }

        public IList<Hero> Heroes { get { return _heroes; } set { _heroes = (List<Hero>)value; } }

        public IList<ActionCard> AttackCardCollection { get; set; }
        public IList<DefenseCard> DefenseCardCollection { get; set; }
        public IList<ModifierCard> ModifierCardCollection { get; set; }

        public void AddHero(IHero p_hero) => _heroes.Add((Hero)p_hero);

        public void SetCardRepository(IRepository<ICard> p_cardrepo)
        {
            _cardRepository = p_cardrepo;
        }

        public override string ToString()
        {
            return Name;
        }

        //Constructore
        public Player(string p_playerName, string p_id = "")
        {
            _id = p_id == "" ? Guid.NewGuid().ToString() : p_id;
            Name = p_playerName;

            AttackCardCollection = new List<ActionCard>();
            DefenseCardCollection= new List<DefenseCard>();
            ModifierCardCollection = new List<ModifierCard>();
        }

        /// <summary>
        /// Returns a Card from the Cards Collection owned by the player
        /// </summary>
        /// <param name="cardName"></param>
        /// <param name="p_ID"></param>
        /// <returns></returns>
        public ICard GetCard(string p_ID)
        {
            return CardCollection().FirstOrDefault(x => x._id == p_ID);
        }

        /// <summary>
        /// Adds an attack, defense or Modifier card to the card collection for the player
        /// </summary>
        /// <param name="p_card"></param>
        public void AddCardtoCollection(ICard p_card)
        {
            if (_cardRepository.Get(new Tuple<string, string>("_id", p_card._id)) != null)
            {
                switch (p_card.Type)
                {
                    case Global.CardType.Attack:
                        AttackCardCollection.Insert(0,(ActionCard)p_card);
                        break;
                    case Global.CardType.Defense:
                        DefenseCardCollection.Insert(0, (DefenseCard)p_card);
                        break;
                    case Global.CardType.Modifier:
                        ModifierCardCollection.Insert(0, (ModifierCard)p_card);
                        break;
                }
            }
        }

        public void RemoveCardFromCollection(Card p_card)
        {
            switch (p_card.Type)
            {
                case Global.CardType.Attack:
                    AttackCardCollection.Remove((ActionCard)p_card);
                    break;
                case Global.CardType.Defense:
                    DefenseCardCollection.Remove((DefenseCard)p_card);
                    break;
                case Global.CardType.Modifier:
                    ModifierCardCollection.Remove((ModifierCard)p_card);
                    break;
            }
        }
    }
}
