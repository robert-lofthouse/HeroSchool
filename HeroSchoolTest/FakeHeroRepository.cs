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
        private List<HeroCard> heroList;
        private Player player;
        string[] HeroNames = { "The Grunter", "Pizzahead", "Hammernose", "Teddybear", "Walljumper", "Itchy_Scratchy", "Neuroticum", "The Blabbermouth", "Crusty", "Smelly" };
        
        public FakeHeroRepository(Player p_player)
        {
            Random rand = new Random();
            player = p_player;
            player.Heroes = new List<HeroCard>()
            {
                HeroFactory.CreateHero(HeroNames[rand.Next(10)],rand.Next(8,18),rand.Next(3,6))
            };
        }

        public void Add(IHSObject p_new)
        {
            ((List<HeroCard>)player.Heroes).Add((HeroCard)p_new);
        }

        public void Add(string p_name, int p_value, int p_energy)
        {
            ((List<HeroCard>)player.Heroes).Add(HeroFactory.CreateHero(p_name, p_value, p_energy));
        }

        public void Delete(IHSObject p_del)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IHSObject> Get()
        {
            return (List<HeroCard>)player.Heroes;
        }

        public IHSObject Get(IHSObject p_get)
        {
            return ((List<HeroCard>)player.Heroes).Find(x => x.Name == ((HeroCard)p_get).Name);
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
