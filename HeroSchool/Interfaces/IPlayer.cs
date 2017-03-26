using System.Collections.Generic;

namespace HeroSchool.Interfaces
{
    public interface IPlayer
    {
        List<ActionCard> AttackCardCollection { get; set; }
        List<ActionCard> DefenseCardCollection { get; set; }
        List<Hero> Heroes { get; set; }
        List<ModifierCard> ModifierCardCollection { get; set; }
        string PlayerName { get; set; }

        void AddCardtoAttackCollection(ActionCard atkCard);
        void AddCardtoDefenseCollection(ActionCard defCard);
        ActionCard GetAttackCard(string cardName);
        ActionCard GetDefenseCard(string cardName);
        ModifierCard GetModifierCard(string cardName);
    }
}