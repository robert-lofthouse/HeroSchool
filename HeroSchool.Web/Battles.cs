using HeroSchool;
using HeroSchool.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroSchool.Core
{
    public class Battles
    {
        private static Battles instance = new Battles();
        private List<Battle> _battles = new List<Battle>();

        public event EventHandler<EventArgs> RefreshBattleEvent;
        public event EventHandler<EventArgs> AttackEvent;
        public event EventHandler<VictoryArgs> VictoryEvent;

        private Battles() { }

        public void RaiseBattleEvent()
        {
            RefreshBattleEvent?.Invoke(null, new EventArgs());
        }
        public void RaiseAttackEvent()
        {
            AttackEvent?.Invoke(null, new EventArgs());
        }
        public void RaiseVictoryEvent(Hero e)
        {
            VictoryEvent?.Invoke(null, new VictoryArgs(e));
        }

        public List<Battle> GetBattles()
        {
            return _battles;
        }

        public List<Battle> GetBattles(Global.BattleType p_battletype)
        {
            return _battles.Where(x => x.Type == p_battletype).ToList();
        }

        public Battle GetBattle(string p_id)
        {
            return _battles.FirstOrDefault(x => x._id == p_id);
        }

        public Battle AddBattle(Hero p_hero)
        {
            Battle newBattle = new Battle(p_hero);
            _battles.Add(newBattle);
            return newBattle;
        }

        public Battle AddBattle(Hero p_hero1, Hero p_hero2)
        {
            Battle newBattle = new Battle(p_hero1, p_hero2);
            _battles.Add(newBattle);
            return newBattle;
        }

        public Battle JoinBattle(string p_id, Hero p_hero)
        {
            Battle joinBattle = _battles.FirstOrDefault(x => x._id == p_id);
            joinBattle.JoinBattle(p_hero);
            return joinBattle;
        }

        public class VictoryArgs : EventArgs
        {
            #region Fields
            private Hero victor;
            #endregion Fields

            #region ConstructorsH
            public VictoryArgs(Hero p_Victor)
            {
                victor = p_Victor;
            }
            #endregion Constructors

            #region Properties
            public Hero Victor
            {
                get { return victor; }
                set { victor = value; }
            }
            #endregion Properties
        }

    }
}
