using HeroSchool.Interfaces;
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
        private IList<IActionable> _attackCardCollection = new List<IActionable>();
        private IList<IActionable> _defenseCardCollection = new List<IActionable>();
        private IList<IModifier> _modifierCardCollection = new List<IModifier>();
        private IList<IHero> _heroes = new List<IHero>();

        #endregion
        public IList<IActionable> AttackCardCollection()
        {
            return _attackCardCollection;
        }

        public IList<IActionable> DefenseCardCollection()
        {
            return _defenseCardCollection;
        }

        public IList<IModifier> ModifierCardCollection()
        {
            return _modifierCardCollection;
        }

        public IList<IHero> Heroes()
        {
            return _heroes;
        }

        public void AddHero(IHero p_hero)
        {
            p_hero.SetPlayer(this);
            _heroes.Add(p_hero);
        }

        //Player's Name
        public string Name { get => _name; set => throw new NotImplementedException(); }

        //Constructore
        public Player(string p_playerName)
        {

            _name = p_playerName;
        }

        /// <summary>
        /// Returns an Attack Card from the Attack Cards Collection owned by the player
        /// </summary>
        /// <param name="cardName"></param>
        /// <returns></returns>
        public IActionable GetAttackCard(string cardName)
        {
            return _attackCardCollection.ToList().Find(x => x.Name == cardName);
        }

        /// <summary>
        /// Returns a Defense Card from the Defense Card Collection matching the parameter name
        /// </summary>
        /// <param name="cardName"></param>
        /// <returns></returns>
        public IActionable GetDefenseCard(string cardName)
        {
            return _defenseCardCollection.ToList().Find(x => x.Name == cardName);
        }

        /// <summary>
        /// Returns a Modifier Card from the Modifier Card Collection matching the parameter name
        /// </summary>
        /// <param name="cardName"></param>
        /// <returns></returns>
        public IModifier GetModifierCard(string cardName)
        {
            return _modifierCardCollection.ToList().Find(x => x.Name == cardName);
        }

        /// <summary>
        /// Adds an attack, defense or Modifier card to the card collection for the player
        /// </summary>
        /// <param name="atkCard"></param>
        public void AddCardtoCollection(ICard p_card)
        {
            switch (p_card.Type)     
            {
                case Constants.CardType.Attack:
                    _attackCardCollection.Insert(0, (IActionable)p_card);
                    break;
                case Constants.CardType.Defense:
                    _defenseCardCollection.Insert(0, (IActionable)p_card);
                    break;
                case Constants.CardType.Modifier:
                    _modifierCardCollection.Insert(0, (IModifier)p_card);
                    break;
                default:
                    break;
            }
            

        }

    }
}
