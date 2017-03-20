namespace HeroSchool
{
    public static class Constants
    {
        public enum ModifierType
        {
            Value = 1,
            Action = 2
        }

        public enum ModifierScope
        {
            OneOff = 1,
            Permanent = 2
        }

        public enum ModifierIgnoreDefenseType
        {
            FirstDefenseCard = 1,
            AllDefenseCards = 2
        }
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
