using System.Collections.Generic;

namespace HeroSchool.Interfaces
{
    public interface IActionable : ICard
    {
        IHero HeroCard { get; set; }
        bool MeetsEnergyRequirement { get; }
        int ReturnEnergy { get; }
        new int Value { get; }

        bool ApplyModifierCard(IModifier p_modifierCard);
        IReadOnlyCollection<IModifier> ModifierCards { get; }
        void RemoveModifiers();
    }
}