using HeroSchool.Interfaces;
using System;
using System.Collections.Generic;

namespace HeroSchool
{
    public class Battle : IBattle
    {
        private HeroCard _hero1;
        private HeroCard _hero2;
        private HeroCard _defendingHero;

        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public HeroCard AttackingHero { get => _defendingHero == _hero1 ? _hero1 : _hero2; }
        public HeroCard DefendingHero { get => _defendingHero; }

        public Battle(HeroCard p_hero1, HeroCard p_hero2)
        {
            _hero1 = p_hero1;
            _hero2 = p_hero2;
            FlipCoin();
        }

        public Constants.AttackResult DoAttack()
        {
            Constants.AttackResult atkres;

            List<ActionCard> attackerPlayedCards = (List<ActionCard>)AttackingHero.PlayedCards;
            
            atkres = DefendingHero.PerformAttack(attackerPlayedCards.Find(x => x.Type == Constants.CardType.Attack));

            _defendingHero = AttackingHero;

            return atkres;
        }

        private void FlipCoin()
        {
            Random rand = new Random();
            
            switch (rand.Next(2))
            {
                case 1:
                    _defendingHero = _hero1;
                    break;
                case 2:
                    _defendingHero = _hero2;
                    break;
                default:
                    break;
            }

        }
    }
}
