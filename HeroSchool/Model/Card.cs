using HeroSchool.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HeroSchool.Model
{
    public class Card : ICard
    {
        public string Name { get; set; }
        public Global.CardType Type { get; set; }
        public virtual int Energy { get; set; }
        public virtual int Value { get; set; }
        public IHeroArchetype HeroArchetype { get; set; }
        public int Level { get; set; }

        public string _id { get; set; }


        protected Card ()
        {
        }

        protected Card(string p_name, int p_value, int p_energy, Global.CardType p_cardType, string p_id = "")
        {
            Name = p_name;
            Value = p_value;
            Energy = p_energy;
            Type = p_cardType;
            _id = p_id == "" ? Guid.NewGuid().ToString() : p_id;
        }

        public override string ToString()
        {
            return string.Format("{0} ({1})", Name, Value);
        }


    }
}
