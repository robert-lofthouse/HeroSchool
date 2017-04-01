
using System.Collections.Generic;

namespace HeroSchool.Interfaces
{
    public interface IHero : IDefendable
    {
        new int Energy { get; }
        IPlayer GetPlayer();

        void AddCardtoDeck(ICard card);
        IReadOnlyCollection<ICard> CardDeck { get; }
        IReadOnlyCollection<ICard> PlayableCards { get; }
        IReadOnlyCollection<IActionable> PlayedCards { get; }

        IList<ICard> DrawCards(int NumberofCards);
        ICard GetCard(string cardName);
        ICard GetPlayableCard(string cardName);
        ICard GetPlayedCard(string cardName);
        void PlayCardfromDeck(IActionable actionCard);
        void RemoveCardFromPlayedDeck(IActionable p_card);
        void SetPlayer(IPlayer value);
        Constants.AttackResult PerformAttack(IActionable opponentAttackCard);
    }
}