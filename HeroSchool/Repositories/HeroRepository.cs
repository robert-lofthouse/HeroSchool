using HeroSchool.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroSchool.Repositories
{
    public class HeroRepository : IRepository
    {
        public void Add(IHeroSchool p_new)
        {
            throw new NotImplementedException();
        }

        public void Delete(IHeroSchool p_del)
        {
            throw new NotImplementedException();
        }

        public IList<IHeroSchool> Get()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets all the heroes for the specified player
        /// </summary>
        /// <param name="p_player"></param>
        /// <returns></returns>
        public IList<IHeroSchool> Get(Player p_player)
        {
            
            throw new NotImplementedException();
        }

        public IHeroSchool Get(IHeroSchool p_get)
        {
            throw new NotImplementedException();
        }

        public void Update(IHeroSchool p_upd)
        {
            throw new NotImplementedException();
        }

        public void Update(IList<IHeroSchool> p_upds)
        {
            throw new NotImplementedException();
        }
    }
}
