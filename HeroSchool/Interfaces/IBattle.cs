using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroSchool.Interfaces
{
    public interface IBattle : IHSObject
    {
        bool Start();
        void AddFirstHero(HeroCard p_hero);
        void AddSecondHero(HeroCard p_hero);
        
    }

}
