using HeroSchool.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroSchool
{
    public class HeroArchetype : IHeroArchetype
    {
        private int _heroPoints;
        private Constants.HeroClass _heroClass;

        public int HeroPoints
        {
            get => _heroPoints;
        }

        public Constants.HeroClass HeroClass
        {
            get => _heroClass;
        }

        public HeroArchetype(int p_heroPoints, Constants.HeroClass p_heroClass)
        {
            _heroClass = p_heroClass;
            _heroPoints = p_heroPoints;
        }
    }
}
