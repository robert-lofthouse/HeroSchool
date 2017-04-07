using HeroSchool.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HeroSchool
{
    public class DefenseCard : ActionCard, IDefendable
    {
        private IList<IActionable> _attacks = new List<IActionable>();
        private int _baseValue;

        public override int Value { get => base.Value - _attacks.Sum(x => x.Value); }
        public DefenseCard () { }

        public DefenseCard(string p_name, int p_value, int p_energy, Global.CardType p_cardType = Global.CardType.Defense, string p_id = "") : base(p_name, p_value,p_energy, p_cardType,p_id)
        {
            _baseValue = p_value;
        }

        public void ApplyAttack(IActionable attack)
        {
            _attacks.Add(attack);
        }

        public void RemoveAttacks()
        {
            _attacks.Clear();
        }
    }
}