using HeroSchool.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HeroSchool.Model
{
    /// <summary>
    /// This is the main hero that will do battle against another hero
    /// </summary>
    public class Hero : DefenseCard, IHero
    {
//        private string _playerID;
        private Player _player;
        //private IRepository<ISchool> _schoolRepo;
        private int _energyUsed = 0;
        private int _energyReturned = 0;
        private int _xp = 0;

        private IList<ActionCard> _playedCards = new List<ActionCard>();

        private IList<Card> _playableCards = new List<Card>();

        private IList<Card> _cardDeck = new List<Card>();

        private HeroArchetype _heroArchetype;

        /// <summary>
        /// Cards loaded into the hero deck
        /// </summary>
        /// <returns></returns>
        public IList<Card> CardDeck()
        {
            return AttackCardDeck.Concat<Card>(DefenseCardDeck).ToList().Concat(ModifierCardDeck).ToList();
        }

        public IList<ActionCard> AttackCardDeck { get; set; }
        public IList<DefenseCard> DefenseCardDeck { get; set; }
        public IList<ModifierCard> ModifierCardDeck { get; set; }

        /// <summary>
        /// Cards that are currently in play
        /// </summary>
        /// <returns></returns>
        public IList<ActionCard> PlayedCards { get => _playedCards ;set => _playedCards = value; }

        /// <summary>
        /// Cards that have been drawn from the deck that can be played if energy is available
        /// </summary>
        /// <returns></returns>
        public IList<Card> PlayableCards { get => _playableCards; set => _playableCards = value; }

        /// <summary>
        /// Energy is calculated from the base energy of the hero minus the accumulative energy of all the cards played so far
        /// </summary>
        public override int Energy { get => base.Energy - _energyUsed + _energyReturned; set => base.Energy = value; }

        public HeroArchetype HeroArcheType { get => _heroArchetype; }

        public override string ToString()
        {
            return string.Format("{0} ({1})", Name, Value);
        }

        //Constructor
        public Hero(string p_name, int p_value, int p_energy, HeroArchetype p_heroArchetype,  Global.CardType p_cardType = Global.CardType.Hero, string p_id = "") : base(p_name, p_value, p_energy, p_cardType,p_id)
        {
            _heroArchetype = p_heroArchetype;
            AttackCardDeck = new List<ActionCard>();
            DefenseCardDeck = new List<DefenseCard>();
            ModifierCardDeck = new List<ModifierCard>();
    }

        /// <summary>
        /// Adds an existing card to the players playing deck 
        /// </summary>
        /// <param name="card"></param>
        /// <param name="p_shuffle"></param>
        public void AddCardtoDeck(ICard card,  bool p_shuffle = true)
        {
            //IList<ISchool> _schoolList = _schoolRepo.Get();
            //IPlayer _player = (from _school in _schoolList from player in _school.Players select player).FirstOrDefault(x => x._id == _playerID);

            //if (_player.GetCard(card._id) == null)
            //{
            //    throw new Exception("Can't add card to deck, player doesn't have card in collection");
            //}

            if (!CardDeck().Any(x => x._id == card._id))
            {
                switch (card.Type)
                {
                    case Global.CardType.Attack:
                        AttackCardDeck.Add((ActionCard)card);
                        _cardDeck.Add((ActionCard)card);
                        break;
                    case Global.CardType.Defense:
                        DefenseCardDeck.Add((DefenseCard)card);
                        _cardDeck.Add((DefenseCard)card);
                        break;
                    case Global.CardType.Modifier:
                        ModifierCardDeck.Add((ModifierCard)card);
                        _cardDeck.Add((ModifierCard)card);
                        break;
                }
            }

            if (p_shuffle)
                ShuffleDeck();
        }
        /// <summary>
        /// Reorders the card deck (shuffles the deck)
        /// </summary>
        public void ShuffleDeck()
        {
            Random rand = new Random();
            _cardDeck = CardDeck().OrderBy(c => rand.Next()).ToList();
        }

        /// <summary>
        /// Returns a number of cards from the top of the list based on the parameter sent in
        /// </summary>
        /// <param name="NumberofCards"></param>
        /// <returns></returns>
        public void DrawCards(int NumberofCards)
        {
            foreach (Card item in new HashSet<ICard>(_cardDeck.Take(NumberofCards)))
            {
                _playableCards.Add(item);
                switch (item.Type)
                {
                    case Global.CardType.Attack:
                        AttackCardDeck.Remove((ActionCard)item);
                        break;
                    case Global.CardType.Defense:
                        DefenseCardDeck.Remove((DefenseCard)item);
                        break;
                    case Global.CardType.Modifier:
                        ModifierCardDeck.Remove((ModifierCard)item);
                        break;
                }
                _cardDeck.Remove(item);
            }
        }

        /// <summary>
        /// Takes a card from the drawn cards pile and adds it to the playing area
        /// </summary>
        /// <param name="actionCard"></param>
        public void PlayCard(IActionable actionCard)
        {
            //check if the card is in the playable deck
            if (_playableCards.FirstOrDefault(x => x == actionCard) != null)
            {
                // check if energy requirments are met
                if (actionCard.MeetsEnergyRequirement(this))
                {
                    _playableCards.Remove((Card)actionCard);
                    _playedCards.Add((ActionCard)actionCard);
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
        /// <param name="opponent"></param>
        /// <param name="opponentAttackCard"></param>
        /// <returns></returns>
        public Global.AttackResult PerformAttack(IHero opponent, IActionable opponentAttackCard)
        {
            if (opponentAttackCard == null)
            {
                // if no attack card was played, then the attack failed
                return Global.AttackResult.AttackFailed;
            }
            else
            {
                if (_playedCards.OfType<IDefendable>().Count() != 0)
                {
                    IDefendable defCard = _playedCards.OfType<IDefendable>().First();
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
                opponent.RemoveCardFromPlayedDeck(opponentAttackCard);

                // return the attack result
                if (Value <= 0)
                {
                    return Global.AttackResult.AttackSuccededDamagedAndKilled;
                }
                else
                {
                    return Global.AttackResult.AttackSuccededDamagedNotKilled;
                }
            }
        }

        public void RemoveCardFromPlayedDeck(IActionable p_card)
        {
            _playedCards.Remove((ActionCard)p_card);

            p_card.RemoveModifiers();
            _energyReturned += p_card.Energy;

            if (p_card.Type == Global.CardType.Defense)
            {
                ((IDefendable)p_card).RemoveAttacks();
            }
            else
            {
                AddCardtoDeck((Card)p_card, false);
            }
        }

        public void  SetPlayer(Player p_player)
        {
            _player = p_player;
        }

        public void RemoveCardFromDeck(ICard p_card)
        {
            switch (p_card.Type)
            {
                case Global.CardType.Attack:
                    AttackCardDeck.Remove((ActionCard)p_card);
                    break;
                case Global.CardType.Defense:
                    DefenseCardDeck.Remove((DefenseCard)p_card);
                    break;
                case Global.CardType.Modifier:
                    ModifierCardDeck.Remove((ModifierCard)p_card);
                    break;
            }
        }
    }
}
