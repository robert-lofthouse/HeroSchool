using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroSchool.Interface
{
    public interface IBattle : IGame
    {
        Global.AttackResult DoAttack();
        IHero AttackingHero { get; }
        IHero DefendingHero { get; }
      //  Battle.SaveableBattle GetSaveableVersion();
    }
}
