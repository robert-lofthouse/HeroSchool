
using System.Collections.Generic;

namespace HeroSchool.Interfaces
{
    public interface IHero : IDefendable
    {

        void AddCardtoDeck(ICard card, bool p_shuffle = true);
        IReadOnlyCollection<ICard> CardDeck { get; }
        IReadOnlyCollection<ICard> PlayableCards { get; }
        IReadOnlyCollection<IActionable> PlayedCards { get; }


        void DrawCards(int NumberofCards);

        void PlayCard(IActionable actionCard);

        void RemoveCardFromPlayedDeck(IActionable p_card);

        Constants.AttackResult PerformAttack(IActionable opponentAttackCard);
    }
}