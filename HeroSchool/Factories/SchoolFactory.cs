using HeroSchool.Interfaces;

namespace HeroSchool
{
    public static class SchoolFactory
    {
        static ISchool CreateSchool(string p_schoolName)
        {
            return new School(p_schoolName);
        }
    }
}
