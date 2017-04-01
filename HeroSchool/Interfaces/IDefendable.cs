namespace HeroSchool.Interfaces
{
    public interface IDefendable : IActionable
    {
        new int Value { get; }

        void ApplyAttack(IActionable attack);
        void RemoveAttacks();
    }
}