using HeroSchool.Interface;
using HeroSchool.Model;
using System;

namespace HeroSchool.Factory
{
    public static class CardFactory
    {
        /// <summary>
        /// Creates a new card and adds it to the master cards collection 
        /// </summary>
        /// <param name="p_name"></param>
        /// <param name="p_value"></param>
        /// <param name="p_energy"></param>
        /// <param name="p_cardType"></param>
        /// <param name="p_returnEnergy"></param>
        /// <returns></returns>
        static public Card CreateCard(string p_name, int p_value, int p_energy, Global.CardType p_cardType, HeroArchetype p_heroarchtype, int p_returnEnergy = 0)
        {
            try
            {
                switch (p_cardType)
                {
                    case Global.CardType.Modifier:
                        return new ModifierCard(p_name, p_value, p_energy);
                    case Global.CardType.Attack:
                        return new ActionCard(p_name, p_value, p_energy, p_cardType, p_returnEnergy);
                    case Global.CardType.Defense:
                        return new DefenseCard(p_name, p_value, p_energy,p_heroarchtype);
                    default:
                        return null;
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
