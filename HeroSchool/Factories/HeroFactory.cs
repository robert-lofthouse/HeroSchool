using HeroSchool.Interfaces;
using System;

namespace HeroSchool.Factories
{
    public static class HeroFactory
    {
        /// <summary>
        /// Create a new player object and add it to the players collection
        /// </summary>
        /// <param name="p_heroName"></param>
        /// <param name="p_value"></param>
        /// <param name="p_energy"></param>
        /// <returns></returns>
        public static IHero CreateHero(string p_heroName, int p_value, int p_energy, IPlayer p_player)
        {
            try
            {
                IHero newHero = new HeroCard(p_heroName, p_value, p_energy, p_player);
                return newHero;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
