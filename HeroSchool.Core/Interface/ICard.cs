using System;

namespace HeroSchool.Interface
{
    public interface ICard : IGame
    {
        string ToString();
        int Energy { get; }
        int Value { get; }
        Global.CardType Type { get; }
        HeroArchetype HeroArchetype { get; set; }
    }
}
