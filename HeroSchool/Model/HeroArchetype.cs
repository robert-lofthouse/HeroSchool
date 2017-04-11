using HeroSchool.Interface;

namespace HeroSchool
{
    public class HeroArchetype : IHeroArchetype
    {
        private int _heroPoints;
        private Global.HeroClass _heroClass;

        public int HeroPoints
        {
            get => _heroPoints;
        }

        public Global.HeroClass HeroClass
        {
            get => _heroClass;
        }

        public HeroArchetype(int p_heroPoints, Global.HeroClass p_heroClass)
        {
            _heroClass = p_heroClass;
            _heroPoints = p_heroPoints;
        }
    }
}
