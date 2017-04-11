using HeroSchool.Model;
using System;
using System.Collections.Generic;

namespace HeroSchool.Interface
{
    public interface IPlayer : IGame
    {
        IList<Card> CardCollection { get; set; }

        void AddCardtoCollection(ICard p_card);

        ICard GetCard(string p_ID);

        IList<Hero> Heroes { get; set;  }
        void AddHero(IHero p_hero);
    }
}