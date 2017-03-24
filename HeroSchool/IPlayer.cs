using System.Collections.Generic;

namespace HeroSchool
{
    public interface IPlayer
    {
        List<AttackCard> AttackCardCollection { get; set; }
        List<DefenseCard> DefenseCardCollection { get; set; }
        List<Hero> Heroes { get; set; }
        List<ModifierCard> ModifierCardCollection { get; set; }
        string PlayerName { get; set; }

        void AddCardtoAttackCollection(AttackCard atkCard);
        void AddCardtoDefenseCollection(DefenseCard defCard);
        AttackCard AttackCard(string cardName);
        DefenseCard DefenseCard(string cardName);
        ModifierCard ModifierCard(string cardName);
    }
}