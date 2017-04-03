using System;

namespace HeroSchool.Interfaces
{
    public interface ICard : IHeroSchool
    {
        Guid ID { get; }
        string ToString();
        int Energy { get; }
        int Value { get; }
        Constants.CardType Type { get; }
    }

}
