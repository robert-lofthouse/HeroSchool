using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HeroSchool
{
    public abstract class PlayableCard : Card
    {
        public PlayableCard(string p_name, int p_value, int p_energy, Constants.CardType p_cardType) : base(p_name, p_value, p_energy, p_cardType)
        {
        }


    }
}