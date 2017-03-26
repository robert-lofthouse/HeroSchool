using System.Linq;
using System.Collections.Generic;
using System;

namespace HeroSchool
{
    public class ActionCard : Card
    {

        private Hero playerCard;
        private List<ModifierCard> appliedModifierCards;

        public Hero HeroCard { get => playerCard; set => playerCard = value; }
        
        public ActionCard(string p_name, int p_value, int p_energy, Constants.CardType p_cardType) : base(p_name, p_value, p_energy, p_cardType)
        {
            appliedModifierCards = new List<ModifierCard>();
        }

        public List<ModifierCard> ModifierCards { get => appliedModifierCards; }

        public int ModifiedValue()
        {
            return Value + appliedModifierCards.Where(x=>x.ModifierType == Constants.ModifierType.Value).Sum(x => x.Value);
        }

        public bool ApplyModifierCard(ModifierCard p_modifierCard)
        {
            try
            {
                appliedModifierCards.Add(p_modifierCard);
                
                return true;
            }
            catch (System.Exception ex)
            {
                return false;
            }
        }
    }
}
