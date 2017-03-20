using System.Linq;
using System.Collections.Generic;
using System;

namespace HeroSchool
{
    public class ActionCard :  Card, IActionCard
    {

        private PlayerCard playerCard;
        private List<ModifierCard> appliedModifierCards;

        public PlayerCard PlayerCard { get => playerCard; set => playerCard = value; }
        
        public ActionCard(string p_name, int p_value, Constants.CardType p_cardType) : base(p_name, p_value, p_cardType)
        {
            ModifierCards = new List<ModifierCard>();
        }

        public List<ModifierCard> ModifierCards { get => appliedModifierCards; set => appliedModifierCards = value; }

        public int ModifiedValue()
        {
            return Value + ModifierCards.Sum(x => x.Value);
        }

        public bool ApplyModifierCard(ModifierCard p_modifierCard)
        {
            try
            {
                appliedModifierCards.Add(p_modifierCard);

                Value = Value + p_modifierCard.Value;

                return true;
            }
            catch (System.Exception ex)
            {
                return false;
            }
        }

        public Constants.AttackResult PerformAttack(AttackCard attackCard)
        {
            if (attackCard == null)
            {
                // if no attack card was played, then the attack failed
                return Constants.AttackResult.AttackFailed;
            }
            else
            {
                //set the new value of the defense card based on the result of the attack
                Value -= attackCard.Value;
                attackCard.PlayerCard.PlayedAttackCards.Remove(attackCard);

                // return the attack result
                if (Value <= 0)
                {
                    playerCard.PlayedDefenseCards.Remove(playerCard.PlayedDefenseCard(Name));
                    return Constants.AttackResult.AttackSuccededDamagedAndKilled;
                }
                else
                {
                    return Constants.AttackResult.AttackSuccededDamagedNotKilled;
                }
            }
        }
    }
}
