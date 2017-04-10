using HeroSchool;
using HeroSchool.Interfaces;
using HeroSchool.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroSchoolUI
{
    public static class Globals
    {
        public static Repository<Player> playerRepo = new Repository<Player>();
        public static IRepository<Card> cardRepo = new CardRepository();
    }
}
