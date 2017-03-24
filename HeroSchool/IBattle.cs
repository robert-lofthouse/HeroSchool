using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroSchool
{
    public interface IBattle
    {
        bool Start();
        void AddFirstHero(HeroCard p_hero);
        void AddSecondHero(HeroCard p_hero);
        
    }

}
