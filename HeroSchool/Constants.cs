namespace HeroSchool
{
    public static class Constants
    {
        public enum CardType
        {
            Attack = 1,
            Defense = 2,
            Modifier = 3,
            Player = 4
        }

        public enum AttackResult
        {
            AttackSuccededDamagedNotKilled = 1,
            AttackSuccededDamagedAndKilled = 2,
            AttackSuccededNotDamaged = 3,
            AttackFailed = 100
        }
    }
}
