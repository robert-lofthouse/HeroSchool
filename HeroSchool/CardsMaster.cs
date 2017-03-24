using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroSchool
{
    public class CardsMaster : List<Card>
    {
        /// <summary>
        /// Creates a new card and adds it to the master cards collection 
        /// </summary>
        /// <param name="p_name"></param>
        /// <param name="p_value"></param>
        /// <param name="p_cardType"></param>
        /// <returns></returns>
        public bool CreateCard(string p_name, int p_value, int p_energy, Constants.CardType p_cardType)
        {
            try
            {
                switch (p_cardType)
                {
                    case Constants.CardType.Attack:
                        Add(new AttackCard(p_name, p_value,p_energy));
                        break;
                    case Constants.CardType.Defense:
                        Add(new DefenseCard(p_name, p_value, p_energy));
                        break;
                    case Constants.CardType.Modifier:
                        Add(new ModifierCard(p_name, p_value, p_energy));
                        break;
                    default:
                        return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw;
            }
        }

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
