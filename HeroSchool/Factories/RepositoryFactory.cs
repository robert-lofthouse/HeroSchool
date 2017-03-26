using HeroSchool.Interfaces;
using HeroSchool.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroSchool.Factories
{
    public static class RepositoryFactory 
    {
        public static IRepository CreateRepository(Constants.RepositoryType p_repoType)
        {
            switch (p_repoType)
            {
                case Constants.RepositoryType.Card:
                    return new CardRepository();
                case Constants.RepositoryType.Player:
                    return new PlayerRepository();
                default:
                    throw new ArgumentException("Invalid Repository Type");
            }
        }

    }
}
