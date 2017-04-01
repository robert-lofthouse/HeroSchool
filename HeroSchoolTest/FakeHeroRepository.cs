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
    public class FakeHeroRepository : IRepository<IHero>
    {
        private IPlayer player;
        string[] HeroNames = { "The Grunter", "Pizzahead", "Hammernose", "Teddybear", "Walljumper", "Itchy_Scratchy", "Neuroticum", "The Blabbermouth", "Crusty", "Smelly" };
        
        public FakeHeroRepository(IPlayer p_player)
        {
            Random rand = new Random();
            player = p_player;
            player.AddHero(HeroFactory.CreateHero(HeroNames[rand.Next(10)], rand.Next(8, 18), rand.Next(3, 6)));
        }

        public void Add(IHero p_new)
        {
            player.AddHero(p_new);
        }

        public void Add(string p_name, int p_value, int p_energy)
        {
            player.AddHero(HeroFactory.CreateHero(p_name, p_value, p_energy));
        }

        public void Delete(IHero p_del)
        {
            throw new NotImplementedException();
        }

        public IList<IHero> Get()
        {
            IList<IHero> heroes = player.Heroes();
            return heroes;
        }

        public IHero Get(IHero p_get)
        {
            return player.Heroes().Where(x => x.Name == p_get.Name).First();
        }

        public void Update(IHero p_upd)
        {
            throw new NotImplementedException();
        }

        public void Update(IList<IHero> p_upds)
        {
            throw new NotImplementedException();
        }
    }
}
