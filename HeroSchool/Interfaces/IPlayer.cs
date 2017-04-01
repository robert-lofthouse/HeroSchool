using System.Collections.Generic;

namespace HeroSchool.Interfaces
{
    public interface IPlayer : IHeroSchool
    {
        IList<IActionable> AttackCardCollection();

        IList<IActionable> DefenseCardCollection();
        IList<IHero> Heroes();
        IList<IModifier> ModifierCardCollection();

        void AddCardtoCollection(ICard p_card);

        IActionable GetAttackCard(string cardName);
        IActionable GetDefenseCard(string cardName);
        IModifier GetModifierCard(string cardName);

        void AddHero(IHero p_hero);
    }
}