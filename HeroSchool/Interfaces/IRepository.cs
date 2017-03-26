using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroSchool.Interfaces
{
    public interface IRepository
    {
        void Add(IHSObject p_new);

        IEnumerable<IHSObject> Get();

        IHSObject Get(IHSObject p_get);

        void Update(IHSObject p_upd);

        void Update(IEnumerable<IHSObject> p_upds);

        void Delete(IHSObject p_del);
    }
}
