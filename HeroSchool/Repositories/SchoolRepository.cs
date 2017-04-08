using HeroSchool.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroSchool.Repositories
{
    class SchoolRepository : IRepository<ISchool>
    {
        public void Add(ISchool p_new)
        {
            throw new NotImplementedException();
        }

        public void Delete(ISchool p_del)
        {
            throw new NotImplementedException();
        }

        public IList<ISchool> Get()
        {
            throw new NotImplementedException();
        }

        public ISchool Get(KeyValuePair<string, string> p_get)
        {
            throw new NotImplementedException();
        }

        public void Update(ISchool p_upd)
        {
            throw new NotImplementedException();
        }

        public void Update(IList<ISchool> p_upds)
        {
            throw new NotImplementedException();
        }
    }
}
