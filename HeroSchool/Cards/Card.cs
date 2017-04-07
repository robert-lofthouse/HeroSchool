using HeroSchool.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HeroSchool
{
    public abstract class Card : ICard
    {
        private int _energy;
        private int _value;
        private Global.CardType _type;

        public string Name { get; set; }
        public Global.CardType Type { get => _type; }
        public virtual int Energy { get => _energy; }
        public virtual int Value { get => _value; }

        public string _id { get; }

        protected Card ()
        {

        }
        protected Card(string p_name, int p_value, int p_energy, Global.CardType p_cardType, string p_id = "")
        {
            Name = p_name;
            _value = p_value;
            _energy = p_energy;
            _type = p_cardType;
            _id = p_id == "" ? Guid.NewGuid().ToString() : p_id;
        }

        public override string ToString()
        {
            return string.Format("{0} ({1})", Name, _value);
        }
    }
}
