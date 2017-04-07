using System;
using System.Collections.Generic;

namespace HeroSchool.Interfaces
{
    public interface IPlayer : IHeroSchool
    {
        IList<ICard> CardCollection();

        void AddCardtoCollection(ICard p_card);

        ICard GetCard(string p_ID);

        IReadOnlyCollection<IHero> Heroes { get; }
        void AddHero(IHero p_hero);
    }
}