using HeroSchool;
using HeroSchool.Factories;
using HeroSchool.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroSchoolTest
{
    public class FakeSchoolRepository : IRepository<ISchool>
    {
        private IList<ISchool> SchoolList;

        public FakeSchoolRepository()
        {
            SchoolList = new List<ISchool>()
            {
                SchoolFactory.CreateSchool("Ogilvie"),
                SchoolFactory.CreateSchool("Buck"),
                SchoolFactory.CreateSchool("Lofthouse")
            };

            (SchoolList[0]).AddPlayer(PlayerFactory.CreatePlayer("Peter"));
            (SchoolList[1]).AddPlayer(PlayerFactory.CreatePlayer("Alan"));
            (SchoolList[2]).AddPlayer(PlayerFactory.CreatePlayer("Robert"));

        }

        public void Add(ISchool p_new)
        {
            SchoolList.Add(p_new);
        }

        public void Delete(ISchool p_del)
        {
            throw new NotImplementedException();
        }

        public IList<ISchool> Get()
        {
            return SchoolList;
        }

        public ISchool Get(ISchool p_get)
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
