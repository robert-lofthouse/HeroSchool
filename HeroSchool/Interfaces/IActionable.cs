using System.Collections.Generic;

namespace HeroSchool
{
    public interface IActionable : ICard
    {
        IHero HeroCard { get; set; }
        bool MeetsEnergyRequirement { get; }
        int ReturnEnergy { get; }
        new int Value { get; }

        bool ApplyModifierCard(IModifier p_modifierCard);
        IList<IModifier> ModifierCards();
        void RemoveModifiers();
    }
}