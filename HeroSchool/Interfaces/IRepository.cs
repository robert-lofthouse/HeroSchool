using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroSchool.Interfaces
{
    public interface IRepository<T> where T : IGame
    {
        void Add(T p_new);

        IList<T> Get();

        T Get(KeyValuePair<string, string> p_get);

        void Update(T p_upd);

        void Update(IList<T> p_upds);

        void Delete(T p_del);
    }
}
