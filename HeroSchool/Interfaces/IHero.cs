
using System.Collections.Generic;

namespace HeroSchool.Interfaces
{
    public interface IHero : IDefendable
    {
        void AddCardtoDeck(Card card, bool p_shuffle = true);
        IList<Card> CardDeck { get; }
        IList<Card> PlayableCards { get; }
        IList<ActionCard> PlayedCards { get; }

        HeroArchetype HeroArcheType { get; }

        void DrawCards(int NumberofCards);

        void PlayCard(IActionable actionCard);

        void RemoveCardFromPlayedDeck(IActionable p_card);

        Global.AttackResult PerformAttack(IHero opponent, IActionable opponentAttackCard);
    }
}