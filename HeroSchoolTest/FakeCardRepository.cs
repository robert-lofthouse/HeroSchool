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
        private List<Card> cardList;

        public FakeCardRepository()
        {
            cardList = new List<Card>()
            {
                CardFactory.CreateCard("Fireball", 1, 1, Constants.CardType.Attack),
                CardFactory.CreateCard("Lightning Bolt", 2, 2, Constants.CardType.Attack, 1),
                CardFactory.CreateCard("Block", 2, 1, Constants.CardType.Defense, 1),
                CardFactory.CreateCard("Dodge", 3, 2, Constants.CardType.Defense, 1),
                CardFactory.CreateCard("Boost", 1, 1, Constants.CardType.Modifier)
            };
        }

        public void Add(IHSObject p_new)
        {
            cardList.Add((Card)p_new);
        }

        public void Delete(IHSObject p_del)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IHSObject> Get()
        {
            return cardList;
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
