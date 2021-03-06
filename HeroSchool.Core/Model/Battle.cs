﻿using HeroSchool.Interface;
using System;
using System.Collections.Generic;

namespace HeroSchool.Model
{
    public class Battle : IBattle
    {


        private IHero _hero1;
        private IHero _hero2;
        private IHero _winninghero;
        private IHero _defendingHero;
        private Global.BattleType _type;

        private string _hero1schoolid, _hero1playerid, _hero1id, _hero2schoolid, _hero2playerid, _hero2id, _winningheroid;

        public string Name
        {
            get => string.Format("{0}{1}",_hero1.ToString(),_hero2 != null ? " vs " + _hero2.ToString() : "") ;
            set => throw new NotImplementedException();
        }

        public override string ToString()
        {
            return Name;
        }

        public IHero AttackingHero { get => _defendingHero != _hero1 ? _hero1 : _hero2; }
        public IHero DefendingHero { get => _defendingHero; }
        public Global.BattleType Type { get => _type; }

        public string _id { get; }

        public Battle() { }
        public Battle(IHero p_hero1, IHero p_hero2)
        {
            _id = Guid.NewGuid().ToString();
            _hero1 = p_hero1;
            _hero2 = p_hero2;
            _type = Global.BattleType.Active;
            FlipCoin();
        }
        public Battle(IHero p_hero)
        {
            _id = Guid.NewGuid().ToString();
            _hero1 = p_hero;
            _type = Global.BattleType.AwaitingHero;
        }
        public Battle(string p_id, string p_hero1schoolid, string p_hero1playerid, string p_hero1id, string p_hero2schoolid, string p_hero2playerid, string p_hero2id, string p_winningheroid)
        {
            _id = p_id;

            _hero1schoolid = p_hero1schoolid;
            _hero1playerid = p_hero1playerid;
            _hero1id = p_hero1id;
            _hero2schoolid = p_hero2schoolid;
            _hero2playerid = p_hero2playerid;
            _hero2id = p_hero2id;
            _winningheroid = p_winningheroid;
        }

        public void JoinBattle(Hero p_hero)
        {
            if (_type == Global.BattleType.AwaitingHero)
            {
                _hero2 = p_hero;
                _type = Global.BattleType.Active;
                FlipCoin();
            }
        }

        public Global.AttackResult DoAttack()
        {
            Global.AttackResult atkres;

            List<ActionCard> attackerPlayedCards = (List<ActionCard>)AttackingHero.PlayedCards;

            atkres = DefendingHero.PerformAttack(AttackingHero, attackerPlayedCards.Find(x => x.Type == Global.CardType.Attack));

            _defendingHero = AttackingHero;

            return atkres;
        }

        private void FlipCoin()
        {
            _hero1.ShuffleDeck();
            _hero2.ShuffleDeck();
            switch (new Random().Next(1))
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
