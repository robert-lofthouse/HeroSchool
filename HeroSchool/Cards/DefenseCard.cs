using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HeroSchool
{
    public class DefenseCard : ActionCard
    {
        private IEnumerable<ActionCard> attacks = new List<ActionCard>();
        public override int Value { get => Value - attacks.Sum(x => x.Value); }

        public DefenseCard(string p_name, int p_value, int p_energy, Constants.CardType p_cardType = Constants.CardType.Defense) : base(p_name, p_value,p_energy, Constants.CardType.Modifier) { }

        public void ApplyAttack(ActionCard attack)
        {
            attacks.ToList().Add(attack);
        }

        public void RemoveAttacks()
        {
            attacks.ToList().Clear();
        }

    }


}