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
        private readonly string[] HeroNames = { "The Grunter", "Pizzahead", "Hammernose", "Teddybear", "Walljumper", "Itchy_Scratchy", "Neuroticum", "The Blabbermouth", "Crusty", "Smelly" };
        private IList<ISchool> SchoolList;
        private IRepository<ICard> _cardRepo;

        public FakeSchoolRepository(IRepository<ICard> p_cardRepo)
        {
            Random rand = new Random();
            _cardRepo = p_cardRepo;

            SchoolList = new List<ISchool>()
            {
                SchoolFactory.CreateSchool("Ogilvie"),
                SchoolFactory.CreateSchool("Buck"),
                SchoolFactory.CreateSchool("Lofthouse")
            };

            IPlayer player = PlayerFactory.CreatePlayer("Peter", _cardRepo);
            player.AddHero(HeroFactory.CreateHero("Peter " + HeroNames[rand.Next(10)], rand.Next(8, 18), rand.Next(3, 6), player.ID, new HeroArchetype(20, Constants.HeroClass.Strength),_cardRepo,this));
            (SchoolList[0]).AddPlayer(player);

            player = PlayerFactory.CreatePlayer("Alan", _cardRepo);
            player.AddHero(HeroFactory.CreateHero("Alan " + HeroNames[rand.Next(10)], rand.Next(8, 18), rand.Next(3, 6), player.ID, new HeroArchetype(20, Constants.HeroClass.Strength), _cardRepo, this));
            (SchoolList[1]).AddPlayer(player);

            player = PlayerFactory.CreatePlayer("Robert", _cardRepo);
            player.AddHero(HeroFactory.CreateHero("Robert " + HeroNames[rand.Next(10)], rand.Next(8, 18), rand.Next(3, 6), player.ID, new HeroArchetype(20, Constants.HeroClass.Strength), _cardRepo, this));
            (SchoolList[2]).AddPlayer(player);
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
