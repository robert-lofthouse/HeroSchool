namespace HeroSchool
{
    public static class BattleFactory
    {
        static IBattle CreateBattle(Hero p_hero1, Hero p_hero2)
        {
            IBattle battle = new Battle();

            battle.AddFirstHero(p_hero1);
            battle.AddSecondHero(p_hero2);

            return battle;
        }
    }

}
