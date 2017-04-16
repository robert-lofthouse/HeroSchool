namespace HeroSchool.Interface
{
    public interface IModifier : ICard
    {
        bool FollowThroughAttack { get; set; }
        Global.ModifierIgnoreDefenseType IgnoreDefense { get; set; }
        int IgnoreDefenseValue { get; set; }
        bool Immunity { get; set; }
        Global.ModifierScope ModifierScope { get; set; }
        Global.ModifierType ModifierType { get; set; }
    }
}