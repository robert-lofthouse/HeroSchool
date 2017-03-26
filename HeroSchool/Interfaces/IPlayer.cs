using System.Collections.Generic;

namespace HeroSchool.Interfaces
{
    public interface IPlayer : IHSObject
    {
        IEnumerable<ActionCard> AttackCardCollection { get; set; }
        IEnumerable<ActionCard> DefenseCardCollection { get; set; }
        IEnumerable<Hero> Heroes { get; set; }
        IEnumerable<ModifierCard> ModifierCardCollection { get; set; }

        void AddCardtoAttackCollection(ActionCard atkCard);
        void AddCardtoDefenseCollection(ActionCard defCard);
        ActionCard GetAttackCard(string cardName);
        ActionCard GetDefenseCard(string cardName);
        ModifierCard GetModifierCard(string cardName);
    }
}