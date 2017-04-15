using System;

namespace HeroSchool.Interface
{
    public interface ICard : IGame
    {
        string ToString();
        int Energy { get; }
        int Value { get; }
        Global.CardType Type { get; }
        IHeroArchetype HeroArchetype { get; set; }
    }
}
