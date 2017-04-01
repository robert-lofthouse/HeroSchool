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
    public class FakeHeroRepository : IRepository
    {
        private Player player;
        string[] HeroNames = { "The Grunter", "Pizzahead", "Hammernose", "Teddybear", "Walljumper", "Itchy_Scratchy", "Neuroticum", "The Blabbermouth", "Crusty", "Smelly" };
        
        public FakeHeroRepository(Player p_player)
        {
            Random rand = new Random();
            player = p_player;
            player.AddHero(HeroFactory.CreateHero(HeroNames[rand.Next(10)], rand.Next(8, 18), rand.Next(3, 6)));
        }

        public void Add(IHeroSchool p_new)
        {
            player.Heroes().Add((HeroCard)p_new);
        }

        public void Add(string p_name, int p_value, int p_energy)
        {
            player.Heroes().Add(HeroFactory.CreateHero(p_name, p_value, p_energy));
        }

        public void Delete(IHeroSchool p_del)
        {
            throw new NotImplementedException();
        }

        public IList<IHeroSchool> Get()
        {
            IList<IHeroSchool> heroes = player.Heroes() as IList<IHeroSchool>;
            return heroes;
        }

        public IHeroSchool Get(IHeroSchool p_get)
        {
            return player.Heroes().Where(x => x.Name == ((HeroCard)p_get).Name).First();
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
