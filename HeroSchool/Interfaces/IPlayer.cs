using System;
using System.Collections.Generic;

namespace HeroSchool.Interfaces
{
    public interface IPlayer : IGame
    {
        IList<Card> CardCollection { get; set; }

        void AddCardtoCollection(Card p_card);

        ICard GetCard(string p_ID);

        IList<Hero> Heroes { get; set;  }
        void AddHero(Hero p_hero);
    }
}