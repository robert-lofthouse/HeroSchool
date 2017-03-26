using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroSchool.Repositories
{
    public class CardsMaster : List<Card>
    {
        /// <summary>
        /// returns all cards matching the name and type passed in 
        /// </summary>
        /// <param name="CardName"></param>
        /// <param name="p_cardType"></param>
        /// <returns></returns>
        public List<Card> GetCard(string CardName, Constants.CardType p_cardType)
        {
            return this.FindAll(x => x.Name == CardName && x.Type == p_cardType);
        }

        /// <summary>
        /// returns all cards matching the name
        /// </summary>
        /// <param name="CardName"></param>
        /// <returns></returns>
        public List<Card> GetCard(string CardName)
        {
            return this.FindAll(x => x.Name == CardName);
        }
    }

}
