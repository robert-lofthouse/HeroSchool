using HeroSchool.Interfaces;

namespace HeroSchool
{
    public class ModifierCard : Card, IModifier
    {
        public Global.ModifierType ModifierType { get; set; }
        public Global.ModifierIgnoreDefenseType IgnoreDefense { get; set; }
        public Global.ModifierScope ModifierScope { get; set; }
        public int IgnoreDefenseValue { get; set; }
        public bool Immunity { get; set; }
        public bool FollowThroughAttack { get; set; }
        public ModifierCard() { }
        public ModifierCard(string p_name, int p_value, int p_energy, string p_id = "", Global.CardType p_cardType = Global.CardType.Modifier) : base(p_name, p_value,p_energy,p_cardType, p_id) { }
    }
}
