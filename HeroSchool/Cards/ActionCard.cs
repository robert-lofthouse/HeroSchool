﻿using System.Linq;
using System.Collections.Generic;
using System;

namespace HeroSchool
{
    public class ActionCard : Card
    {
        private HeroCard hero;
        private IEnumerable<ModifierCard> appliedModifierCards = new List<ModifierCard>();
        private int returnEnergy;

        public HeroCard HeroCard { get => hero; set => hero = value; }
        public int ReturnEnergy { get => returnEnergy; }

        public IEnumerable<ModifierCard> ModifierCards { get => appliedModifierCards; }
        public bool MeetsEnergyRequirement { get => hero.Energy >= this.Energy; }
        public override int Value { get => Value + appliedModifierCards.Where(x=>x.ModifierType == Constants.ModifierType.Value).Sum(x => x.Value); }
        
        public ActionCard(string p_name, int p_value, int p_energy, Constants.CardType p_cardType) : base(p_name, p_value, p_energy, p_cardType) { }
        public ActionCard(string p_name, int p_value, int p_energy, Constants.CardType p_cardType, int p_returnEnergy) : base(p_name, p_value, p_energy, p_cardType, p_returnEnergy)
        {
            returnEnergy = p_returnEnergy;
        }

        public bool ApplyModifierCard(ModifierCard p_modifierCard)
        {
            try
            {
                appliedModifierCards.ToList().Add(p_modifierCard);
                
                return true;
            }
            catch (System.Exception ex)
            {
                return false;
            }
        }
    }
}