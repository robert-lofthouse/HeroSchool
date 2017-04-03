using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroSchool.Factories
{
    public static class CardFactory
    {
        /// <summary>
        /// Creates a new card and adds it to the master cards collection 
        /// </summary>
        /// <param name="p_name"></param>
        /// <param name="p_value"></param>
        /// <param name="p_cardType"></param>
        /// <returns></returns>
        static public Card CreateCard(string p_name, int p_value, int p_energy, Constants.CardType p_cardType, int p_returnEnergy = 0)
        {
            try
            {
                switch (p_cardType)
                {
                    case Constants.CardType.Modifier:
                        return new ModifierCard(p_name, p_value, p_energy);
                    case Constants.CardType.Attack:
                        return new ActionCard(p_name, p_value, p_energy, p_cardType, p_returnEnergy);
                    case Constants.CardType.Defense:
                        return new DefenseCard(p_name, p_value, p_energy, p_cardType);
                    default:
                        return null;
                        break;
                }
            }
            catch (Exception ex)
            {
                return null;
                throw;
            }
        }


    }
}
