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
        public static HeroCard CreateHero(string p_heroName, int p_value, int p_energy)
        {
            try
            {
                return new HeroCard(p_heroName, p_value, p_energy);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
