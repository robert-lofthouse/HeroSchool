namespace HeroSchool
{
    public class ModifierCard : Card
    {
        public ModifierCard(string p_name, int p_value, Constants.CardType p_cardType = Constants.CardType.Modifier) : base(p_name, p_value, Constants.CardType.Modifier)
        {
        }
    }

}
