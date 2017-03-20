namespace HeroSchool
{

    public class DefenseCard : ActionCard
    {
        public DefenseCard(string p_name, int p_value, Constants.CardType p_cardType = Constants.CardType.Defense) : base (p_name,p_value, Constants.CardType.Defense)
        {
        }

    }

}
