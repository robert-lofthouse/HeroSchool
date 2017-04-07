﻿using System.Linq;
using System.Collections.Generic;
using System;
using HeroSchool.Interfaces;
using System.Collections.ObjectModel;

namespace HeroSchool
{
    public class ActionCard : Card, IActionable
    {
        //private IHero _hero;
        private int _returnEnergy;
        private readonly List<IModifier> _modifierCards = new List<IModifier>();

        //public IHero HeroCard { get => _hero; set => _hero = value; }
        public int ReturnEnergy { get => _returnEnergy; }

        public IReadOnlyCollection<IModifier> ModifierCards { get ; }

        public bool MeetsEnergyRequirement(IHero p_hero)
        {
            return p_hero.Energy >= Energy;
        }

        public override int Value { get => base.Value + _modifierCards.Where(x=>x.ModifierType == Global.ModifierType.Value).Sum(x => x.Value); }
        public ActionCard () { }
        public ActionCard(string p_name, int p_value, int p_energy, Global.CardType p_cardType, string p_id = "") : base(p_name, p_value, p_energy, p_cardType,p_id)
        {
        }

        public ActionCard(string p_name, int p_value, int p_energy, Global.CardType p_cardType, int p_returnEnergy, string p_id = "") : base(p_name, p_value, p_energy, p_cardType,p_id)
        {
            ModifierCards = _modifierCards.AsReadOnly();
            _returnEnergy = p_returnEnergy;
        }

        public void RemoveModifiers()
        {
            _modifierCards.Clear();
        }

        public bool ApplyModifierCard(IModifier p_modifierCard)
        {
            if (p_modifierCard != null)
            {
                try
                {
                    _modifierCards.Add(p_modifierCard);

                    return true;
                }
                catch (System.Exception ex)
                {
                    return false;
                }
            }
            return false;
        }
    }
}
