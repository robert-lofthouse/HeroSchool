using System.Linq;
using System.Collections.Generic;
using System;

namespace HeroSchool
{
    public abstract class ActionCard :  PlayableCard
    {

        private HeroCard playerCard;
        private List<ModifierCard> appliedModifierCards;

        public HeroCard HeroCard { get => playerCard; set => playerCard = value; }
        
        public ActionCard(string p_name, int p_value, Constants.CardType p_cardType) : base(p_name, p_value, p_cardType)
        {
            ModifierCards = new List<ModifierCard>();
        }

        public List<ModifierCard> ModifierCards { get => appliedModifierCards; set => appliedModifierCards = value; }

        public bool ApplyModifierCard(ModifierCard p_modifierCard)
        {
            try
            {
                if (p_modifierCard.ModifierType == Constants.ModifierType.Value)
                    Value = Value + p_modifierCard.Value;
                else
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
