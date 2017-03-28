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
        public void Add(IHSObject p_new)
        {
            throw new NotImplementedException();
        }

        public void Delete(IHSObject p_del)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IHSObject> Get()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets all the heroes for the specified player
        /// </summary>
        /// <param name="p_player"></param>
        /// <returns></returns>
        public IEnumerable<IHSObject> Get(Player p_player)
        {
            
            throw new NotImplementedException();
        }

        public IHSObject Get(IHSObject p_get)
        {
            throw new NotImplementedException();
        }

        public void Update(IHSObject p_upd)
        {
            throw new NotImplementedException();
        }

        public void Update(IEnumerable<IHSObject> p_upds)
        {
            throw new NotImplementedException();
        }
    }
}
