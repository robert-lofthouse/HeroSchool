using System.Collections.Generic;

namespace HeroSchool
{
    public class PlayerCard : PlayableCard
    {

        private List<AttackCard> attackCardDeck;
        private List<DefenseCard> defenseCardDeck;
        private List<ModifierCard> modifierCardDeck;
        private List<AttackCard> playedAttackCards;
        private List<DefenseCard> playedDefenseCards;
        private List<Card> cardDeck;
        private List<Card> playedCards;

        public List<AttackCard> AttackCardDeck { get => attackCardDeck; set => attackCardDeck = value; }
        public List<DefenseCard> DefenseCardDeck { get => defenseCardDeck; set => defenseCardDeck = value; }
        public List<ModifierCard> ModifierCardDeck { get => modifierCardDeck; set => modifierCardDeck = value; }
        public List<AttackCard> PlayedAttackCards { get => playedAttackCards; set => playedAttackCards = value; }
        public List<DefenseCard> PlayedDefenseCards { get => playedDefenseCards; set => playedDefenseCards = value; }
        public List<Card> CardDeck { get => cardDeck; set => cardDeck = value; }
        public List<Card> PlayedCards { get => playedCards; set => playedCards = value; }

        public AttackCard PlayedAttackCard(string cardName)
        {
            return playedAttackCards.Find(x => x.Name == cardName);
        }
        public DefenseCard PlayedDefenseCard(string cardName)
        {
            return playedDefenseCards.Find(x => x.Name == cardName);
        }

        public AttackCard AttackCard(string cardName)
        {
            return attackCardDeck.Find(x => x.Name == cardName);
        }
        public DefenseCard DefenseCard(string cardName)
        {
            return defenseCardDeck.Find(x => x.Name == cardName);
        }

        public PlayerCard(string p_name, int p_value, Constants.CardType p_cardType = Constants.CardType.Player) : base(p_name,p_value, Constants.CardType.Player)
        {
            AttackCardDeck = new List<AttackCard>();
            DefenseCardDeck = new List<DefenseCard>();
            ModifierCardDeck = new List<ModifierCard>();
            CardDeck = new List<Card>();
            PlayedCards = new List<Card>();

            PlayedAttackCards = new List<AttackCard>();
            PlayedDefenseCards = new List<DefenseCard>();
        }

        public void PlayCard(Card actionCard)
        {
            if (actionCard.Type == Constants.CardType.Defense)
            {
                defenseCardDeck.Remove(actionCard as DefenseCard);
                playedDefenseCards.Add(actionCard as DefenseCard);

            }
            else if (actionCard.Type == Constants.CardType.Attack)
            {
                attackCardDeck.Remove(actionCard as AttackCard);
                playedAttackCards.Add(actionCard as AttackCard);
            }
        }

        public void AddAttackCard(string p_name, int p_value)
        {
            AttackCard atkCard = new AttackCard(p_name, p_value);
            atkCard.PlayerCard = this;
            attackCardDeck.Add(atkCard);

        }

        public void AddDefenseCard(string p_name, int p_value)
        {
            DefenseCard defCard = new DefenseCard(p_name, p_value);
            defCard.PlayerCard = this;
            defenseCardDeck.Add(defCard);

        }

        public Constants.AttackResult PerformAttack(AttackCard opponentAttackCard)
        {
            /// This method is called to perform an attack on this playercard using the attack card passed in
            /// 
            if (opponentAttackCard == null)
            {
                // if no attack card was played, then the attack failed
                return Constants.AttackResult.AttackFailed;
            }
            else
            {
                if (playedDefenseCards.Count != 0)
                {
                    //If there are any defense cards played, attack them first
                    playedDefenseCards[0].Value -= opponentAttackCard.Value;

                    if (playedDefenseCards[0].Value <= 0)
                    {
                        playedDefenseCards.RemoveAt(0);
                    }
                }
                else
                {
                    //If there are no defense cards played, 
                    //set the new value of the defense card based on the result of the attack
                    Value -= opponentAttackCard.Value;
                    
                }

                //Remove the attack card from the attacker's prepared cards list
                opponentAttackCard.PlayerCard.PlayedAttackCards.Remove(opponentAttackCard);
                
                // return the attack result
                if (Value <= 0)
                {
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
