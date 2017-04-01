using System.Collections.Generic;

namespace HeroSchool
{
    public interface IHero : IDefendable
    {
        new int Energy { get; }

        void AddCardtoDeck(ICard card);
        IList<ICard> CardDeck();
        IList<ICard> DrawCards(int NumberofCards);
        ICard GetCard(string cardName);
        ICard GetPlayableCard(string cardName);
        ICard GetPlayedCard(string cardName);
        Constants.AttackResult PerformAttack(IActionable opponentAttackCard);
        IList<ICard> PlayableCards();
        void PlayCardfromDeck(IActionable actionCard);
        IList<IActionable> PlayedCards();
        void RemoveCardFromPlayedDeck(IActionable p_card);
    }
}