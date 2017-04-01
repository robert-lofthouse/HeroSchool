using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroSchool.Interfaces
{
    public interface IRepository
    {
        void Add(IHeroSchool p_new);

        IList<IHeroSchool> Get();

        IHeroSchool Get(IHeroSchool p_get);

        void Update(IHeroSchool p_upd);

        void Update(IList<IHeroSchool> p_upds);

        void Delete(IHeroSchool p_del);
    }
}
