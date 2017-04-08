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
    public class FakeCardRepository : IRepository<Card>
    {
        private IList<Card> cardList;

        public FakeCardRepository()
        {
            cardList = new List<Card>()
            {
                CardFactory.CreateCard("Fireball", 2, 1, Global.CardType.Attack),
                CardFactory.CreateCard("Lightning Bolt", 3, 2, Global.CardType.Attack, 1),
                CardFactory.CreateCard("Block", 1, 1, Global.CardType.Defense, 1),
                CardFactory.CreateCard("Dodge", 2, 2, Global.CardType.Defense, 1),
                CardFactory.CreateCard("Boost", 1, 1, Global.CardType.Modifier)
            };
        }

        public void Add(Card p_new)
        {
            cardList.Add(p_new);
        }

        public void Delete(Card p_del)
        {
            throw new NotImplementedException();
        }

        public IList<Card> Get()
        {
            return cardList;
        }

        public Card Get(KeyValuePair<string,string> p_get)
        {
            return cardList.FirstOrDefault(x => x._id == p_get.Value);
        }

        public void Update(Card p_upd)
        {
            throw new NotImplementedException();
        }

        public void Update(IList<Card> p_upds)
        {
            throw new NotImplementedException();
        }
    }
}
