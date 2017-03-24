using System;

namespace HeroSchool
{
    public class Battle : IBattle
    {
        private Hero Hero1;
        private Hero Hero2;

        public Battle()
        {

        }

        public void AddFirstHero(Hero p_hero)
        {
            Hero1 = p_hero;
        }

        public void AddSecondHero(Hero p_hero)
        {
            Hero2 = p_hero;
        }

        public bool Start()
        {
            throw new NotImplementedException();
        }
    }
}
