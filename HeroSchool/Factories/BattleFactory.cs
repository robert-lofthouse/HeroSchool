using HeroSchool.Interfaces;

namespace HeroSchool
{
    public static class BattleFactory
    {
        static IBattle CreateBattle(HeroCard p_hero1, HeroCard p_hero2)
        {
            IBattle battle = new Battle();

            battle.AddFirstHero(p_hero1);
            battle.AddSecondHero(p_hero2);

            return battle;
        }
    }

}
