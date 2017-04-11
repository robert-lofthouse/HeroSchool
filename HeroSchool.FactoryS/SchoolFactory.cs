using HeroSchool.Interface;

namespace HeroSchool.Factory
{
    public static class SchoolFactory
    {
        public static ISchool CreateSchool(string p_schoolName)
        {
            return new School(p_schoolName);
        }
    }
}
