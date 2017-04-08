﻿using HeroSchool.Interfaces;
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
        /// <param name="p_player"></param>
        /// <param name="p_heroArchetype"></param>
        /// <returns></returns>
        public static Hero CreateHero(
            string p_heroName,
            int p_value,
            int p_energy,
            string p_player,
            HeroArchetype p_heroArchetype,
            IRepository<Card> p_cardRepo,
            IRepository<ISchool> p_schoolRepo)
        {
            try
            {
                return new Hero(p_heroName, p_value, p_energy, p_player, p_heroArchetype,p_cardRepo, p_schoolRepo);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
