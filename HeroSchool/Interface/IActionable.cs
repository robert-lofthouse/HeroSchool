using System.Collections.Generic;

namespace HeroSchool.Interface
{
    public interface IActionable : ICard
    {
        //        IHero HeroCard { get; set; }
        bool MeetsEnergyRequirement(IHero p_hero);
        int ReturnEnergy { get; }
        new int Value { get; set;  }

        bool ApplyModifierCard(IModifier p_modifierCard);
        IReadOnlyCollection<IModifier> ModifierCards { get; }
        void RemoveModifiers();
    }
}