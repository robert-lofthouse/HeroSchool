using HeroSchool.Interfaces;

namespace HeroSchool
{
    public static class BattleFactory
    {
        static IBattle CreateBattle(HeroCard p_hero1, HeroCard p_hero2)
        {
            IBattle battle = new Battle(p_hero1,p_hero2);

            return battle;
        }
    }

}
