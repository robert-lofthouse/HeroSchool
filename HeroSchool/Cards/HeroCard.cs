using HeroSchool.Interfaces;
using Newtonsoft.Json;
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
        private int _energyUsed = 0;
        private int _energyReturned = 0;

        private List<IActionable> _playedCards = new List<IActionable>();
        //private List<IActionable> _playedAttackCards = new List<IActionable>();
        //private List<IDefendable> _playedDefenseCards = new List<IDefendable>();


        private List<ICard> _playableCards = new List<ICard>();
        //private List<IModifier> _playableModifierCards = new List<IModifier>();
        //private List<IActionable> _playableAttackCards = new List<IActionable>();
        //private List<IDefendable> _playableDefenseCards = new List<IDefendable>();

        private List<ICard> _cardDeck = new List<ICard>();
        //private List<IModifier> _modifierCardsDeck = new List<IModifier>();
        //private List<IActionable> _attackCardsDeck = new List<IActionable>();
        //private List<IDefendable> _defenseCardsDeck = new List<IDefendable>();

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

        /// <summary>
        /// Energy is calculated from the base energy of the hero minus the accumulative energy of all the cards played so far
        /// </summary>
        public override int Energy { get => base.Energy - _energyUsed + _energyReturned; }

        public override string ToString()
        {
            return string.Format("{0} ({1})", Name, Value);
        }

        public IPlayer Player { get => _player; }
        
        //Constructor
        public HeroCard(string p_name, int p_value, int p_energy, IPlayer p_player, Constants.CardType p_cardType = Constants.CardType.Hero) : base(p_name, p_value, p_energy, p_cardType)
        {
            _player = p_player;
        }

        /// <summary>
        /// Adds an existing card to the players playing deck 
        /// </summary>
        /// <param name="card"></param>
        public void AddCardtoDeck(ICard card, bool p_shuffle = true)
        {
            if (card.Type == Constants.CardType.Attack || card.Type == Constants.CardType.Defense)
            {
                IActionable actCard = (IActionable)card;
                actCard.HeroCard = this;
            }

            //switch (card.Type)
            //{
            //    case Constants.CardType.Attack:
            //        _attackCardsDeck.Add((IActionable)card);
            //        break;
            //    case Constants.CardType.Defense:
            //        _defenseCardsDeck.Add((IDefendable)card);
            //        break;
            //    case Constants.CardType.Modifier:
            //        _modifierCardsDeck.Add((IModifier)card);
            //        break;
            //    default:
            //        break;
            //}
            _cardDeck.Add(card);

            if (p_shuffle) ShuffleDeck();

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
        /// Returns a number of cards from the top of the list based on the parameter sent in
        /// </summary>
        /// <param name="NumberofCards"></param>
        /// <returns></returns>
        public void DrawCards(int NumberofCards)
        {
            IList<ICard> cardsDrawn = _cardDeck.Take(NumberofCards).ToList();

            //foreach (ICard card in cardsDrawn)
            //{
            //    switch (card.Type)
            //    {
            //        case Constants.CardType.Attack:
            //            _playableAttackCards.Add(_attackCardsDeck.Find(x=>x.ID == card.ID));
            //            _attackCardsDeck.RemoveAll(x => x.ID == card.ID);
            //            break;
            //        case Constants.CardType.Defense:
            //            _playableDefenseCards.Add(_defenseCardsDeck.Find(x=>x.ID==card.ID));
            //            _defenseCardsDeck.RemoveAll(x => x.ID == card.ID);
            //            break;
            //        case Constants.CardType.Modifier:
            //            _playableModifierCards.Add(_modifierCardsDeck.Find(x=>x.ID==card.ID));
            //            _modifierCardsDeck.RemoveAll(x => x.ID == card.ID);
            //            break;
            //        default:
            //            break;
            //    }
            //}

            _playableCards.AddRange(cardsDrawn);

            var setToRemove = new HashSet<ICard>(cardsDrawn);
            _cardDeck.RemoveAll(x => setToRemove.Contains(x));
        }
        
        /// <summary>
        /// Takes a card from the drawn cards pile and adds it to the playing area
        /// </summary>
        /// <param name="actionCard"></param>
        public void PlayCard(IActionable actionCard)
        {
            //check if the card is in the playable deck
            if (_playableCards.Find(x => x == actionCard) != null)
            {
                // check if energy requirments are met
                if (actionCard.MeetsEnergyRequirement)
                {
                    //switch (actionCard.Type)
                    //{
                    //    case Constants.CardType.Attack:
                    //        _playedAttackCards.Add(actionCard);
                    //        _playableAttackCards.RemoveAll(x => x.ID == actionCard.ID);
                    //        break;
                    //    case Constants.CardType.Defense:
                    //        _playedDefenseCards.Add(_playableDefenseCards.Find(x=>x.ID == actionCard.ID));
                    //        _playableDefenseCards.RemoveAll(x => x.ID == actionCard.ID);
                    //        break;
                    //    default:
                    //        break;
                    //}

                    _playableCards.Remove(actionCard);
                    _playedCards.Add(actionCard);
                    _energyUsed += actionCard.Energy;
                }
                else
                {
                    throw new Exception("Energy requirement not met, unable to add to deck");
                }
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
                if (_playedCards.OfType<IDefendable>().ToList().Count != 0)
                {

                    IDefendable defCard = _playedCards.OfType<IDefendable>().ToList()[0];
                    //IDefendable defCard = (IDefendable)_playedCards.Where(x => x.Type == Constants.CardType.Defense).First();
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
            //_playedAttackCards.RemoveAll(x => x.ID == p_card.ID);
            //_playedDefenseCards.RemoveAll(x => x.ID == p_card.ID);
            _playedCards.Remove(p_card);

            p_card.RemoveModifiers();
            _energyReturned += p_card.Energy;

            if (p_card.Type == Constants.CardType.Defense)
            {
                ((IDefendable)p_card).RemoveAttacks();
            }
            else
            {
                AddCardtoDeck(p_card, false);
            }
        }

    }

}
