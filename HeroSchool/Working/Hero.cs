using System;
using System.Collections.Generic;
using System.Linq;

namespace HeroSchool
{
    /// <summary>
    /// 
    /// </summary>
    public class Hero : DefenseCard
    {

        //Cards currently in play        
        private IEnumerable<ActionCard> playedCards = new List<ActionCard>();

        //Cards drawn from the deck that can be playd
        private IEnumerable<Card> playableCards;

        //Cards in the deck, selected from the collection, can consist of Attack, Defense or Modifier Cards
        private IEnumerable<Card> cardDeck = new List<Card>();

        private int EnergyUsed = 0;
        private int EnergyReturned = 0;

        /// <summary>
        /// Deck of cards selected for the match
        /// </summary>
        public IEnumerable<Card> CardDeck { get => cardDeck; set => cardDeck = value; }

        /// <summary>
        /// Cards that have been played / are currently in play
        /// </summary>
        public IEnumerable<ActionCard> PlayedCards { get => playedCards; set => playedCards = value; }

        /// <summary>
        /// Cards drawn from the deck that can be played or held
        /// </summary>
        public IEnumerable<Card> PlayableCards { get => playableCards; set => playableCards = value; }

        //Constructor
        public Hero(string p_name, int p_value, int p_energy, Constants.CardType p_cardType = Constants.CardType.Hero) : base(p_name, p_value, p_energy, Constants.CardType.Hero) {  }

        /// <summary>
        /// Energy is calculated from the base energy of the hero minus the accumulative energy of all the cards played so far
        /// </summary>
        public override int Energy { get => Energy - EnergyUsed + EnergyReturned; }
           

        /// <summary>
        /// Returns an Attack Card from the Played Attack Cards List matching the parameter name
        /// </summary>
        /// <param name="cardName"></param>
        /// <returns></returns>
        public Card PlayedCard(string cardName)
        {
            return playedCards.ToList().Find(x => x.Name == cardName);
        }

        /// <summary>
        /// Returns a Card from the current playing deck matching the parameter name
        /// </summary>
        /// <param name="cardName"></param>
        /// <returns></returns>
        public Card Card(string cardName)
        {
            return cardDeck.ToList().Find(x => x.Name == cardName);
        }

        /// <summary>
        /// Returns a Card from the current playing deck matching the parameter name
        /// </summary>
        /// <param name="cardName"></param>
        /// <returns></returns>
        public Card PlayableCard(string cardName)
        {
            return playableCards.ToList().Find(x => x.Name == cardName);
        }

        /// <summary>
        /// Returns a number of cards from the top of the list based on the parameter sent in
        /// </summary>
        /// <param name="NumberofCards"></param>
        /// <returns></returns>
        public IEnumerable<Card> DrawCards(int NumberofCards)
        {
            return cardDeck.Take(NumberofCards).ToList();
        }

        /// <summary>
        /// Reorders the card deck (shuffles the deck)
        /// </summary>
        private void ShuffleDeck()
        {
            Random rand = new Random();
            cardDeck = cardDeck.OrderBy(c => rand.Next()).ToList();

        }

        /// <summary>
        /// Adds an existing card to the players playing deck 
        /// </summary>
        /// <param name="card"></param>
        public void AddCardtoDeck(Card card)
        {
            if (card.Type == Constants.CardType.Attack || card.Type == Constants.CardType.Defense)
            {
                ActionCard actCard = (ActionCard)card;
                actCard.HeroCard = this;
            }
            cardDeck.ToList().Add(card);

            ShuffleDeck();
        }

        /// <summary>
        /// Takes a card from the deck and adds it to the playing area
        /// </summary>
        /// <param name="actionCard"></param>
        public void PlayCardfromDeck(ActionCard actionCard)
        {
            // check if energy requirments are met
            if (MeetsEnergyRequirement)
            {
                cardDeck.ToList().Remove(actionCard);
                playedCards.ToList().Add(actionCard);
                EnergyUsed += actionCard.Energy;
            }
            else
            {
                throw new Exception("Energy requirement not met, unable to add to deck");
            }
        }

        /// <summary>
        /// This method is called to perform an attack on this playercard using the attack card passed in
        /// </summary>
        /// <param name="opponentAttackCard"></param>
        /// <returns></returns>
        public Constants.AttackResult PerformAttack(ActionCard opponentAttackCard)
        {
            if (opponentAttackCard == null)
            {
                // if no attack card was played, then the attack failed
                return Constants.AttackResult.AttackFailed;
            }
            else
            {
                if (playedCards.Where(x => x.Type == Constants.CardType.Defense).ToList().Count != 0)
                {
                    DefenseCard defCard = (DefenseCard)playedCards.Where(x => x.Type == Constants.CardType.Defense).ToList()[0];
                    //If there are any defense cards played, attack them first

                    //todo - figure out how the defense card value must be manipulated.
                    defCard.ApplyAttack(opponentAttackCard);

                    if (defCard.Value <= 0)
                    {
                        playedCards.ToList().Remove(defCard);
                    }
                }
                else
                {
                    //If there are no defense cards played, 
                    //set the new value of the defense card based on the result of the attack
                    ApplyAttack(opponentAttackCard);
                }

                //Remove the attack card from the attacker's prepared cards list
                opponentAttackCard.HeroCard.playedCards.ToList().Remove(opponentAttackCard);

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
