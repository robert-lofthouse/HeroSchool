namespace HeroSchool
{
    public class AttackCard : ActionCard
    {

        public AttackCard(string p_name, int p_value, int p_energy, Constants.CardType p_cardType = Constants.CardType.Attack) : base (p_name,p_value, p_energy, Constants.CardType.Attack)
        {
            
        }


    }

}
