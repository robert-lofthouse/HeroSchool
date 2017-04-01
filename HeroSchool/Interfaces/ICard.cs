using HeroSchool.Interfaces;

namespace HeroSchool
{
    public interface ICard : IHeroSchool
    {
        string ToString();
        int Energy { get; }
        int Value { get; }
        Constants.CardType Type { get; }
    }

}
