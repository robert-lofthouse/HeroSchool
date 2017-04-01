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
    public class FakeCardRepository : IRepository
    {
        private IList<IHeroSchool> cardList;

        public FakeCardRepository()
        {
            cardList = new List<IHeroSchool>()
            {
                CardFactory.CreateCard("Fireball", 1, 1, Constants.CardType.Attack),
                CardFactory.CreateCard("Lightning Bolt", 2, 2, Constants.CardType.Attack, 1),
                CardFactory.CreateCard("Block", 2, 1, Constants.CardType.Defense, 1),
                CardFactory.CreateCard("Dodge", 3, 2, Constants.CardType.Defense, 1),
                CardFactory.CreateCard("Boost", 1, 1, Constants.CardType.Modifier)
            };
        }

        public void Add(IHeroSchool p_new)
        {
            cardList.Add((Card)p_new);
        }

        public void Delete(IHeroSchool p_del)
        {
            throw new NotImplementedException();
        }

        public IList<IHeroSchool> Get()
        {
            return cardList;
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
