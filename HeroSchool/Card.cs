using System;
using System.Collections.Generic;
using System.Linq;

namespace HeroSchool
{
    public abstract class Card
    {
        public string Name { get; set; }
        public int Value { get; set; }
        public Constants.CardType Type { get; set; }

        public Card(string p_name, int p_value, Constants.CardType p_cardType)
        {
            Name = p_name;
            Value = p_value;
            Type = p_cardType;
        }

        public override string ToString()
        {
            return string.Format("{0} ({1})", Name,Value);
        }

    }

}
