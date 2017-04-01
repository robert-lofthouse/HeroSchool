namespace HeroSchool.Interfaces
{
    public interface IModifier : ICard
    {
        bool FollowThroughAttack { get; set; }
        Constants.ModifierIgnoreDefenseType IgnoreDefense { get; set; }
        int IgnoreDefenseValue { get; set; }
        bool Immunity { get; set; }
        Constants.ModifierScope ModifierScope { get; set; }
        Constants.ModifierType ModifierType { get; set; }
    }
}