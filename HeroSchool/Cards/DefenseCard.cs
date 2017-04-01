using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HeroSchool
{
    public class DefenseCard : ActionCard, IDefendable
    {
        private IList<IActionable> attacks = new List<IActionable>();
        private int baseValue;

        public override int Value { get => baseValue - attacks.Sum(x => x.Value); }

        public DefenseCard(string p_name, int p_value, int p_energy, Constants.CardType p_cardType = Constants.CardType.Defense) : base(p_name, p_value,p_energy, p_cardType)
        {
            baseValue = p_value;
        }

        public void ApplyAttack(IActionable attack)
        {
            attacks.Add(attack);
        }

        public void RemoveAttacks()
        {
            attacks.Clear();
        }

    }


}