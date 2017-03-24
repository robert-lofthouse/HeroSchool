namespace HeroSchool
{

    public class DefenseCard : ActionCard
    {
        public DefenseCard(string p_name, int p_value, int p_energy, Constants.CardType p_cardType = Constants.CardType.Defense) : base (p_name,p_value, p_energy, Constants.CardType.Defense)
        {
        }

    }

}
