using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroSchool.Interfaces
{
    public interface IHeroArchetype
    {
        int HeroPoints { get; }
        Global.HeroClass HeroClass { get; }
    }
}
