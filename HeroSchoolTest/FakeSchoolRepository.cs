using HeroSchool;
using HeroSchool.Factory;
using HeroSchool.Interface;
using HeroSchool.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroSchoolTest
{
    public class FakeSchoolRepository : IRepository<ISchool>
    {
        private readonly string[] HeroNames = { "the Grunter", "the Pizzahead", "the Hammernose", "the Teddybear", "the Walljumper", "the Itchy_Scratcher", "the Neurotic", "the Blabbermouth", "the Crusty", "the Smelly", "the Nosepicker", "the Kind", "the Flower-sniffer" };
        private IList<ISchool> SchoolList;
        private IRepository<ICard> _cardRepo;

        public FakeSchoolRepository(IRepository<ICard> p_cardRepo)
        {
            Random rand = new Random();
            _cardRepo = p_cardRepo;

            SchoolList = new List<ISchool>()
            {
                new School("Ogilvie"),
                new School("Buck"),
                new School("Lofthouse")
            };

            Player player = new Player("Peter");
            player.SetCardRepository(_cardRepo);
            player.AddHero(new Hero("Peter " + HeroNames[rand.Next(10)], rand.Next(10, 15), rand.Next(2, 5), new HeroArchetype(20, Global.HeroClass.Strength)));
            (SchoolList[0]).AddPlayer(player);

            player = new Player("Simon");
            player.SetCardRepository(_cardRepo);
            player.AddHero(new Hero("Simon " + HeroNames[rand.Next(10)], rand.Next(10, 15), rand.Next(2, 5), new HeroArchetype(20, Global.HeroClass.Strength)));
            (SchoolList[0]).AddPlayer(player);

            player = new Player("Alan");
            player.SetCardRepository(_cardRepo);
            player.AddHero(new Hero("Alan " + HeroNames[rand.Next(10)], rand.Next(10, 15), rand.Next(2, 5), new HeroArchetype(20, Global.HeroClass.Strength)));
            (SchoolList[1]).AddPlayer(player);

            player = new Player("Aidan");
            player.SetCardRepository(_cardRepo);
            player.AddHero(new Hero("Aidan " + HeroNames[rand.Next(10)], rand.Next(10, 15), rand.Next(2, 5), new HeroArchetype(20, Global.HeroClass.Strength)));
            (SchoolList[1]).AddPlayer(player);

            player = new Player("Robert");
            player.SetCardRepository(_cardRepo);
            player.AddHero(new Hero("Robert " + HeroNames[rand.Next(10)], rand.Next(10, 15), rand.Next(2, 5), new HeroArchetype(20, Global.HeroClass.Strength)));
            (SchoolList[2]).AddPlayer(player);

            player = new Player("David");
            player.SetCardRepository(_cardRepo);
            player.AddHero(new Hero("David " + HeroNames[rand.Next(10)], rand.Next(10, 15), rand.Next(2, 5), new HeroArchetype(20, Global.HeroClass.Strength)));
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
