using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroSchool.Interfaces
{
    public interface IBattle
    {
        bool Start();
        void AddFirstHero(Hero p_hero);
        void AddSecondHero(Hero p_hero);
        
    }

}
