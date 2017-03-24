using System;

namespace HeroSchool
{
    public class Battle : IBattle
    {
        private HeroCard Hero1;
        private HeroCard Hero2;

        public Battle()
        {

        }

        public void AddFirstHero(HeroCard p_hero)
        {
            Hero1 = p_hero;
        }

        public void AddSecondHero(HeroCard p_hero)
        {
            Hero2 = p_hero;
        }

        public bool Start()
        {
            throw new NotImplementedException();
        }
    }
}
