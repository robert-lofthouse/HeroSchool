
using HeroSchool.Model;
using System.Collections.Generic;

namespace HeroSchool.Interface
{
    public interface IHero : IDefendable
    {
        void AddCardtoDeck(ICard card, bool p_shuffle = true);

        IList<Card> CardDeck();

        IList<ActionCard> AttackCardDeck { get; set; }
        IList<DefenseCard> DefenseCardDeck { get; set; }
        IList<ModifierCard> ModifierCardDeck { get; set; }

        IList<Card> PlayableCards { get; }
        IList<ActionCard> PlayedCards { get; }

        void DrawCards(int NumberofCards);
        void ShuffleDeck();

        void PlayCard(IActionable actionCard);

        void RemoveCardFromPlayedDeck(IActionable p_card);
        void RemoveCardFromDeck(ICard p_card);

        Global.AttackResult PerformAttack(IHero opponent, IActionable opponentAttackCard);
    }
}