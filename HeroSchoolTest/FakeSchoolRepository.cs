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
        private List<School> SchoolList;

        public FakeSchoolRepository()
        {
            SchoolList = new List<School>()
            {
                new School("Ogilvie"),
                new School("Buck"),
                new School("Lofthouse")
            };

            SchoolList[0].AddPlayer(new Player("Peter"));
            SchoolList[1].AddPlayer(new Player("Alan"));
            SchoolList[2].AddPlayer(new Player("Robert"));

        }

        public void Add(IHSObject p_new)
        {
            SchoolList.Add((School)p_new);
        }

        public void Delete(IHSObject p_del)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IHSObject> Get()
        {
            return SchoolList;
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
