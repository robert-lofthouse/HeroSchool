﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroSchool
{
    public class Player : IPlayer
    {
        #region Private variables

        private string playerName;
        private List<AttackCard> attackCardCollection;
        private List<DefenseCard> defenseCardCollection;
        private List<ModifierCard> modifierCardCollection;
        private List<HeroCard> heroes;
        #endregion
        
        /// <summary>
        /// Collection of attack cards owned by the player
        /// </summary>
        public List<AttackCard> AttackCardCollection { get => attackCardCollection; set => attackCardCollection = value; }

        /// <summary>
        /// Collection of Defense cards owned by the player
        /// </summary>
        public List<DefenseCard> DefenseCardCollection { get => defenseCardCollection; set => defenseCardCollection = value; }

        /// <summary>
        /// Collection of Modifier cards owned by the player
        /// </summary>
        public List<ModifierCard> ModifierCardCollection { get => modifierCardCollection; set => modifierCardCollection = value; }

        /// <summary>
        /// Collection of Heroes that the player can battle with
        /// </summary>
        public List<HeroCard> Heroes { get => heroes; set => heroes = value; }

        //Player's Name
        public string PlayerName { get => playerName; set => playerName = value; }

        //Constructore
        public Player(string p_playerName)
        {
            AttackCardCollection = new List<AttackCard>();
            DefenseCardCollection = new List<DefenseCard>();
            ModifierCardCollection = new List<ModifierCard>();

            playerName = p_playerName;
        }

        /// <summary>
        /// Returns an Attack Card from the Attack Cards Collection owned by the player
        /// </summary>
        /// <param name="cardName"></param>
        /// <returns></returns>
        public AttackCard AttackCard(string cardName)
        {
            return attackCardCollection.Find(x => x.Name == cardName);
        }

        /// <summary>
        /// Returns a Defense Card from the Defense Card Collection matching the parameter name
        /// </summary>
        /// <param name="cardName"></param>
        /// <returns></returns>
        public DefenseCard DefenseCard(string cardName)
        {
            return defenseCardCollection.Find(x => x.Name == cardName);
        }

        /// <summary>
        /// Returns a Modifier Card from the Modifier Card Collection matching the parameter name
        /// </summary>
        /// <param name="cardName"></param>
        /// <returns></returns>
        public ModifierCard ModifierCard(string cardName)
        {
            return modifierCardCollection.Find(x => x.Name == cardName);
        }

        /// <summary>
        /// Adds an attack card to the attack card collection for the player
        /// </summary>
        /// <param name="atkCard"></param>
        public void AddCardtoAttackCollection(AttackCard atkCard)
        {
            attackCardCollection.Add(atkCard);

        }
        
        /// <summary>
        ///  Adds a defense card to the defense card collection for the player
        /// </summary>
        /// <param name="p_name"></param>
        /// <param name="p_value"></param>
        public void AddCardtoDefenseCollection(DefenseCard defCard)
        {
            defenseCardCollection.Add(defCard);

        }
    }
}