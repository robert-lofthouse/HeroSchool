using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HeroSchool
{
    public class DefenseCard : ActionCard
    {
        private List<ActionCard> attacks;
        public DefenseCard(string p_name, int p_value, int p_energy, Constants.CardType p_cardType = Constants.CardType.Defense) : base(p_name, p_value,p_energy, Constants.CardType.Modifier)
        {
            attacks = new List<ActionCard>();
        }

        public void ApplyAttack(ActionCard attack)
        {
            attacks.Add(attack);
        }

        public override int Value
        {
            get
            {
                return ModifiedValue() - attacks.Sum(x => x.ModifiedValue());
            }

        }

    }


}