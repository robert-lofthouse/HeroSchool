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

        private string name;
        private IList<IActionable> attackCardCollection = new List<IActionable>();
        private IList<IActionable> defenseCardCollection = new List<IActionable>();
        private IList<IModifier> modifierCardCollection = new List<IModifier>();
        private IList<IHeroSchool> heroes = new List<IHeroSchool>();

        #endregion
        public IList<IActionable> AttackCardCollection()
        {
            return attackCardCollection;
        }

        public IList<IActionable> DefenseCardCollection()
        {
            return defenseCardCollection;
        }

        public IList<IModifier> ModifierCardCollection()
        {
            return modifierCardCollection;
        }

        public IList<IHeroSchool> Heroes()
        {
            return heroes;
        }

        public void AddHero(HeroCard p_hero)
        {
            heroes.Add(p_hero);
        }

        //Player's Name
        public string Name { get => name; set => throw new NotImplementedException(); }

        //Constructore
        public Player(string p_playerName)
        {

            name = p_playerName;
        }

        /// <summary>
        /// Returns an Attack Card from the Attack Cards Collection owned by the player
        /// </summary>
        /// <param name="cardName"></param>
        /// <returns></returns>
        public IActionable GetAttackCard(string cardName)
        {
            return attackCardCollection.ToList().Find(x => x.Name == cardName);
        }

        /// <summary>
        /// Returns a Defense Card from the Defense Card Collection matching the parameter name
        /// </summary>
        /// <param name="cardName"></param>
        /// <returns></returns>
        public IActionable GetDefenseCard(string cardName)
        {
            return defenseCardCollection.ToList().Find(x => x.Name == cardName);
        }

        /// <summary>
        /// Returns a Modifier Card from the Modifier Card Collection matching the parameter name
        /// </summary>
        /// <param name="cardName"></param>
        /// <returns></returns>
        public IModifier GetModifierCard(string cardName)
        {
            return modifierCardCollection.ToList().Find(x => x.Name == cardName);
        }

        /// <summary>
        /// Adds an attack card to the attack card collection for the player
        /// </summary>
        /// <param name="atkCard"></param>
        public void AddCardtoCollection(ICard p_card)
        {
            switch (p_card.Type)     
            {
                case Constants.CardType.Attack:
                    attackCardCollection.Insert(0, (IActionable)p_card);
                    break;
                case Constants.CardType.Defense:
                    defenseCardCollection.Insert(0, (IActionable)p_card);
                    break;
                case Constants.CardType.Modifier:
                    modifierCardCollection.Insert(0, (IModifier)p_card);
                    break;
                default:
                    break;
            }
            

        }

    }
}
