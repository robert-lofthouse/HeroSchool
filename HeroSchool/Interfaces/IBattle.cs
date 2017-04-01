using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroSchool.Interfaces
{
    public interface IBattle : IHeroSchool
    {
        Constants.AttackResult DoAttack();
        HeroCard AttackingHero { get; }
        HeroCard DefendingHero { get; }
    }

}
