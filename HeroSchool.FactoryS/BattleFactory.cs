using HeroSchool.Interface;

namespace HeroSchool.Factory
{
    public static class BattleFactory
    {
        public static IBattle CreateBattle(IHero p_hero1, IHero p_hero2)
        {
            IBattle battle = new Battle(p_hero1,p_hero2);

            return battle;
        }
    }
}
