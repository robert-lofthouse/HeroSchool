using HeroSchool.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HeroSchool
{

    public abstract class Card : ICard
    {
        private Guid _id;
        private int _energy;
        private string _name;
        private int _value;
        private Constants.CardType _type;

        public string Name { get => _name; set => _name = value; }
        public Constants.CardType Type { get => _type; }
        public virtual int Energy { get => _energy; }
        public virtual int Value { get => _value; }

        public Guid ID { get => _id; }

        public Card(string p_name, int p_value, int p_energy, Constants.CardType p_cardType, Guid p_id = new Guid())
        {
            _name = p_name;
            _value = p_value;
            _energy = p_energy;
            _type = p_cardType;
            _id = p_id;

        }

        public override string ToString()
        {
            return string.Format("{0} ({1})", Name, _value);
        }

    }

}
