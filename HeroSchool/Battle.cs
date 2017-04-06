using HeroSchool.Interfaces;
using System;
using System.Collections.Generic;

namespace HeroSchool
{
    public class Battle : IBattle
    {
        private IHero _hero1;
        private IHero _hero2;
        private IHero _defendingHero;
        private Guid _id;

        public string Name
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public IHero AttackingHero { get => _defendingHero != _hero1 ? _hero1 : _hero2; }
        public IHero DefendingHero { get => _defendingHero; }

        public Guid ID { get => _id; }

        public Battle(IHero p_hero1, IHero p_hero2)
        {
            _id = Guid.NewGuid();
            _hero1 = p_hero1;
            _hero2 = p_hero2;
            FlipCoin();
        }

        public Constants.AttackResult DoAttack()
        {
            Constants.AttackResult atkres;

            List<IActionable> attackerPlayedCards = (List<IActionable>)AttackingHero.PlayedCards;

            atkres = DefendingHero.PerformAttack(AttackingHero, attackerPlayedCards.Find(x => x.Type == Constants.CardType.Attack));

            _defendingHero = AttackingHero;

            return atkres;
        }

        private void FlipCoin()
        {
            Random rand = new Random();

            switch (rand.Next(1))
            {
                case 0:
                    _defendingHero = _hero1;
                    break;
                default:
                    _defendingHero = _hero2;
                    break;
            }
        }
    }
}
