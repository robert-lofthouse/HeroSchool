using System.Collections.Generic;

namespace HeroSchool
{
    public class PlayerCard : DefenseCard
    {

        private List<AttackCard> attackCardDeck;
        private List<DefenseCard> defenseCardDeck;
        private List<ModifierCard> modifierCardDeck;
        private List<AttackCard> playedAttackCards;
        private List<DefenseCard> playedDefenseCards;

        public List<AttackCard> AttackCardDeck { get => attackCardDeck; set => attackCardDeck = value; }
        public List<DefenseCard> DefenseCardDeck { get => defenseCardDeck; set => defenseCardDeck = value; }
        public List<ModifierCard> ModifierCardDeck { get => modifierCardDeck; set => modifierCardDeck = value; }
        public List<AttackCard> PlayedAttackCards { get => playedAttackCards; set => playedAttackCards = value; }
        public List<DefenseCard> PlayedDefenseCards { get => playedDefenseCards; set => playedDefenseCards = value; }


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

    }

}
