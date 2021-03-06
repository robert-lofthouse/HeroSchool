﻿namespace HeroSchool
{
    public static class Global
    {
        public enum BattleType
        {
            AwaitingHero,
            Active
        }

        public enum HeroClass
        {
            Strength,
            Elemental,
            Technology,
            Telekenesis,
            Magic
        }
        public enum ModifierType
        {
            Value,
            Action
        }

        public enum ModifierScope
        {
            OneOff,
            Permanent
        }

        public enum ModifierIgnoreDefenseType
        {
            FirstDefenseCard,
            AllDefenseCards
        }
        public enum CardType
        {
            Attack = 1,
            Defense = 2,
            Modifier = 3,
            Hero = 4
        }

        public enum AttackResult
        {
            AttackSuccededDamagedNotKilled,
            AttackSuccededDamagedAndKilled,
            AttackSuccededNotDamaged,
            AttackFailed
        }

        public enum RepositoryType
        {
            Player,
            Card
        }


    }
}
