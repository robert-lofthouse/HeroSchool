using HeroSchool.Interfaces;

namespace HeroSchool.Factories
{
    public static class SchoolFactory
    {
        public static ISchool CreateSchool(string p_schoolName)
        {
            return new School(p_schoolName);
        }
    }
}
