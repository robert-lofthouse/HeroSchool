using HeroSchool;
using HeroSchool.Factory;
using HeroSchool.Interface;
using HeroSchool.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HeroSchoolTest
{
    public class FakeCardRepository : IRepository<ICard>
    {
        private IList<ICard> cardList;

        public FakeCardRepository()
        {
            cardList = new List<ICard>()
            {
                CardFactory.CreateCard("Fireball", 2, 1, Global.CardType.Attack),
                CardFactory.CreateCard("Lightning Bolt", 3, 2, Global.CardType.Attack, 1),
                CardFactory.CreateCard("Block", 1, 1, Global.CardType.Defense, 1),
                CardFactory.CreateCard("Dodge", 2, 2, Global.CardType.Defense, 1),
                CardFactory.CreateCard("Boost", 1, 1, Global.CardType.Modifier)
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

        public ICard Get(KeyValuePair<string,string> p_get)
        {
            return cardList.FirstOrDefault(x => x._id == p_get.Value);
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
