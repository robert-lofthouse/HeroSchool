using HeroSchool.Interfaces;

namespace HeroSchool
{
    public class ModifierCard : Card, IModifier
    {
        public Constants.ModifierType ModifierType { get; set; }
        public Constants.ModifierIgnoreDefenseType IgnoreDefense { get; set; }
        public Constants.ModifierScope ModifierScope { get; set; }
        public int IgnoreDefenseValue { get; set; }
        public bool Immunity { get; set; }
        public bool FollowThroughAttack { get; set; }

        public ModifierCard(string p_name, int p_value, int p_energy, Constants.CardType p_cardType = Constants.CardType.Modifier) : base(p_name, p_value,p_energy,p_cardType) { }
    }
}
