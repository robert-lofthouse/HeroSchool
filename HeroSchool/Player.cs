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
        private IEnumerable<ActionCard> attackCardCollection = new List<ActionCard>();
        private IEnumerable<ActionCard> defenseCardCollection = new List<ActionCard>();
        private IEnumerable<ModifierCard> modifierCardCollection = new List<ModifierCard>();
        private IEnumerable<HeroCard> heroes = new List<HeroCard>();
        #endregion
        
        /// <summary>
        /// Collection of attack cards owned by the player
        /// </summary>
        public IEnumerable<ActionCard> AttackCardCollection { get => attackCardCollection; set => attackCardCollection = value; }

        /// <summary>
        /// Collection of Defense cards owned by the player
        /// </summary>
        public IEnumerable<ActionCard> DefenseCardCollection { get => defenseCardCollection; set => defenseCardCollection = value; }

        /// <summary>
        /// Collection of Modifier cards owned by the player
        /// </summary>
        public IEnumerable<ModifierCard> ModifierCardCollection { get => modifierCardCollection; set => modifierCardCollection = value; }

        /// <summary>
        /// Collection of Heroes that the player can battle with
        /// </summary>
        public IEnumerable<HeroCard> Heroes { get => heroes; set => heroes = value; }

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
        public ActionCard GetAttackCard(string cardName)
        {
            return attackCardCollection.ToList().Find(x => x.Name == cardName);
        }

        /// <summary>
        /// Returns a Defense Card from the Defense Card Collection matching the parameter name
        /// </summary>
        /// <param name="cardName"></param>
        /// <returns></returns>
        public ActionCard GetDefenseCard(string cardName)
        {
            return defenseCardCollection.ToList().Find(x => x.Name == cardName);
        }

        /// <summary>
        /// Returns a Modifier Card from the Modifier Card Collection matching the parameter name
        /// </summary>
        /// <param name="cardName"></param>
        /// <returns></returns>
        public ModifierCard GetModifierCard(string cardName)
        {
            return modifierCardCollection.ToList().Find(x => x.Name == cardName);
        }

        /// <summary>
        /// Adds an attack card to the attack card collection for the player
        /// </summary>
        /// <param name="atkCard"></param>
        public void AddCardtoAttackCollection(ActionCard atkCard)
        {
            attackCardCollection.ToList().Add(atkCard);

        }
        
        /// <summary>
        ///  Adds a defense card to the defense card collection for the player
        /// </summary>
        /// <param name="p_name"></param>
        /// <param name="p_value"></param>
        public void AddCardtoDefenseCollection(ActionCard defCard)
        {
            defenseCardCollection.ToList().Add(defCard);

        }
    }
}
