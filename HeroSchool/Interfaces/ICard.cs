using System;

namespace HeroSchool.Interfaces
{
    public interface ICard : IHeroSchool
    {
        string ToString();
        int Energy { get; }
        int Value { get; }
        Global.CardType Type { get; }
    }
}
