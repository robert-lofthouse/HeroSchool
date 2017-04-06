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
    public class FakeCardRepository : IRepository<ICard>
    {
        private IList<ICard> cardList;

        public FakeCardRepository()
        {
            cardList = new List<ICard>()
            {
                CardFactory.CreateCard("Fireball", 2, 1, Constants.CardType.Attack),
                CardFactory.CreateCard("Lightning Bolt", 3, 2, Constants.CardType.Attack, 1),
                CardFactory.CreateCard("Block", 1, 1, Constants.CardType.Defense, 1),
                CardFactory.CreateCard("Dodge", 2, 2, Constants.CardType.Defense, 1),
                CardFactory.CreateCard("Boost", 1, 1, Constants.CardType.Modifier)
            };
        }

        public void Add(ICard p_new)
        {
            cardList.Add(p_new);
        }

        public void Delete(ICard p_del)
        {
            throw new NotImplementedException();
        }

        public IList<ICard> Get()
        {
            return cardList;
        }

        public ICard Get(ICard p_get)
        {
            return cardList.FirstOrDefault(x => x.ID == p_get.ID);
        }

        public void Update(ICard p_upd)
        {
            throw new NotImplementedException();
        }

        public void Update(IList<ICard> p_upds)
        {
            throw new NotImplementedException();
        }
    }
}
