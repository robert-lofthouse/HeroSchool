using HeroSchool.Model;
using System;
using System.Collections.Generic;

namespace HeroSchool.Interface
{
    public interface IPlayer : IGame
    {
        IList<Card> CardCollection();
        void RemoveCardFromCollection(Card p_card);
        IList<ActionCard> AttackCardCollection { get; set; }
        IList<DefenseCard> DefenseCardCollection { get; set; }
        IList<ModifierCard> ModifierCardCollection { get; set; }
        void AddCardtoCollection(ICard p_card);

        ICard GetCard(string p_ID);

        IList<Hero> Heroes { get; set;  }
        void AddHero(IHero p_hero);
    }
}