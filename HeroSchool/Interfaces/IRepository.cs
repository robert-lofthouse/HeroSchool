using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroSchool.Interfaces
{

    public interface IRepository<T> where T : IHeroSchool
    {
        void Add(T p_new);

        IList<T> Get();

        T Get(T p_get);

        void Update(T p_upd);

        void Update(IList<T> p_upds);

        void Delete(T p_del);
    }

    public interface ICardPack<T> : IList<T> where T : ICard
    {
    }

}
