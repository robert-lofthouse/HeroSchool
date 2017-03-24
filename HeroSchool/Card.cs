﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace HeroSchool
{
    
    public abstract class Card 
    {
        private int energy;
        private string name;
        private int value;
        private Constants.CardType type;

        public string Name { get => name; }
        public int Value { get => value; }
        public Constants.CardType Type { get => type;  }
        public int Energy { get => energy; }

        public Card(string p_name, int p_value, int p_energy, Constants.CardType p_cardType)
        {
            name = p_name;
            value = p_value;
            energy = p_energy;
            type = p_cardType;
        }

        public override string ToString()
        {
            return string.Format("{0} ({1})", Name,Value);
        }

    }

}
