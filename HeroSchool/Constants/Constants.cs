using System.Collections.Generic;

namespace HeroSchool
{
    public static class Constants
    {
        public enum HeroType
        {
            Strength,
            Elemental,
            Technology,
            Telekenesis,
            Magic
        }
        public enum ModifierType
        {
            Value = 'V',
            Action = 'A'
        }

        public enum ModifierScope
        {
            OneOff = 'O',
            Permanent = 'P'
        }

        public enum ModifierIgnoreDefenseType
        {
            FirstDefenseCard = 'F',
            AllDefenseCards = 'A'
        }
        public enum CardType
        {
            Attack = 'A',
            Defense = 'D',
            Modifier = 'M',
            Hero = 'H'
        }

        public enum AttackResult
        {
            AttackSuccededDamagedNotKilled = 'S',
            AttackSuccededDamagedAndKilled = 'K',
            AttackSuccededNotDamaged = 'M',
            AttackFailed = 'F'
        }

        public enum RepositoryType
        {
            Player = 'P',
            Card = 'C'
        }
    }
}
