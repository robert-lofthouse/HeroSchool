using HeroSchool;
using HeroSchool.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroSchoolTest
{
    public class FakeSchoolRepository : IRepository
    {
        private IList<IHeroSchool> SchoolList;

        public FakeSchoolRepository()
        {
            SchoolList = new List<IHeroSchool>()
            {
                new School("Ogilvie"),
                new School("Buck"),
                new School("Lofthouse")
            };

            ((ISchool)SchoolList[0]).AddPlayer(new Player("Peter"));
            ((ISchool)SchoolList[1]).AddPlayer(new Player("Alan"));
            ((ISchool)SchoolList[2]).AddPlayer(new Player("Robert"));

        }

        public void Add(IHeroSchool p_new)
        {
            SchoolList.Add((School)p_new);
        }

        public void Delete(IHeroSchool p_del)
        {
            throw new NotImplementedException();
        }

        public IList<IHeroSchool> Get()
        {
            return SchoolList;
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
