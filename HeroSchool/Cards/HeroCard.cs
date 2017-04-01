using HeroSchool.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HeroSchool
{
    /// <summary>
    /// 
    /// </summary>
    public class HeroCard : DefenseCard, IHero
    {
        private IPlayer _player;
        private int _baseEnergy;
        private int _energyUsed = 0;
        private int _energyReturned = 0;

        private List<IActionable> _playedCards = new List<IActionable>();
        private List<ICard> _playableCards = new List<ICard>();
        private List<ICard> _cardDeck = new List<ICard>();

        /// <summary>
        /// Cards loaded into the hero deck
        /// </summary>
        /// <returns></returns>
        public IReadOnlyCollection<ICard> CardDeck { get => _cardDeck; }

        /// <summary>
        /// Cards that are currently in play
        /// </summary>
        /// <returns></returns>
        public IReadOnlyCollection<IActionable> PlayedCards { get => _playedCards; }

        /// <summary>
        /// Cards that have been drawn from the deck that can be played if energy is available
        /// </summary>
        /// <returns></returns>
        public IReadOnlyCollection<ICard> PlayableCards { get => _playableCards; }
        
        //Constructor
        public HeroCard(string p_name, int p_value, int p_energy, Constants.CardType p_cardType = Constants.CardType.Hero) : base(p_name, p_value, p_energy, p_cardType)
        {

            _baseEnergy = p_energy;
        }

        /// <summary>
        /// Energy is calculated from the base energy of the hero minus the accumulative energy of all the cards played so far
        /// </summary>
        public override int Energy { get => _baseEnergy - _energyUsed + _energyReturned; }

        public IPlayer GetPlayer()
        {
            return _player;
        }

        public void SetPlayer(IPlayer value)
        {
            _player = value;
        }
        
        /// <summary>
        /// Returns an Attack Card from the Played Attack Cards List matching the parameter name
        /// </summary>
        /// <param name="cardName"></param>
        /// <returns></returns>
        public ICard GetPlayedCard(string cardName)
        {
            return _playedCards.Where(x => x.Name == cardName).First();
        }

        /// <summary>
        /// Returns a Card from the current playing deck matching the parameter name
        /// </summary>
        /// <param name="cardName"></param>
        /// <returns></returns>
        public ICard GetCard(string cardName)
        {
            return _cardDeck.Where(x => x.Name == cardName).First();
        }

        /// <summary>
        /// Returns a Card from the current playing deck matching the parameter name
        /// </summary>
        /// <param name="cardName"></param>
        /// <returns></returns>
        public ICard GetPlayableCard(string cardName)
        {
            return _playableCards.Where(x => x.Name == cardName).First();
        }

        /// <summary>
        /// Returns a number of cards from the top of the list based on the parameter sent in
        /// </summary>
        /// <param name="NumberofCards"></param>
        /// <returns></returns>
        public IList<ICard> DrawCards(int NumberofCards)
        {
            return _cardDeck.Take(NumberofCards).ToList();
        }

        /// <summary>
        /// Reorders the card deck (shuffles the deck)
        /// </summary>
        private void ShuffleDeck()
        {
            Random rand = new Random();
            _cardDeck = _cardDeck.OrderBy(c => rand.Next()).ToList();

        }

        /// <summary>
        /// Adds an existing card to the players playing deck 
        /// </summary>
        /// <param name="card"></param>
        public void AddCardtoDeck(ICard card)
        {
            if (card.Type == Constants.CardType.Attack || card.Type == Constants.CardType.Defense)
            {
                IActionable actCard = (IActionable)card;
                actCard.HeroCard = this;
            }
            _cardDeck.Add(card);

            ShuffleDeck();


        }

        /// <summary>
        /// Takes a card from the deck and adds it to the playing area
        /// </summary>
        /// <param name="actionCard"></param>
        public void PlayCardfromDeck(IActionable actionCard)
        {
            // check if energy requirments are met
            if (MeetsEnergyRequirement)
            {
                _cardDeck.Remove(actionCard);
                _playedCards.Add(actionCard);
                _energyUsed += actionCard.Energy;
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
        public Constants.AttackResult PerformAttack(IActionable opponentAttackCard)
        {
            if (opponentAttackCard == null)
            {
                // if no attack card was played, then the attack failed
                return Constants.AttackResult.AttackFailed;
            }
            else
            {
                if (_playedCards.Where(x => x.Type == Constants.CardType.Defense).ToList().Count != 0)
                {
                    DefenseCard defCard = (DefenseCard)_playedCards.Where(x => x.Type == Constants.CardType.Defense).ToList()[0];
                    //If there are any defense cards played, attack them first

                    //todo - figure out how the defense card value must be manipulated.
                    defCard.ApplyAttack(opponentAttackCard);

                    if (defCard.Value <= 0)
                    {
                        //Remove the attack card from the attacker's prepared cards list and add it back to the bottom of the deck
                        RemoveCardFromPlayedDeck(defCard);
                    }
                }
                else
                {
                    //If there are no defense cards played, 
                    //set the new value of the defense card based on the result of the attack
                    ApplyAttack(opponentAttackCard);
                }

                //Remove the attack card from the attacker's prepared cards list and add it back to the bottom of the deck
                opponentAttackCard.HeroCard.RemoveCardFromPlayedDeck(opponentAttackCard);

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

        public void RemoveCardFromPlayedDeck(IActionable p_card)
        {
            _playedCards.Remove(p_card);
            _cardDeck.Insert(_cardDeck.Count(), p_card);
            p_card.RemoveModifiers();

            if (p_card.Type == Constants.CardType.Defense) ((IDefendable)p_card).RemoveAttacks();
        }
    }

}
