using HeroSchool.Interfaces;

namespace HeroSchool
{
    public class Game : IGame
    {
        public string Name { get; set; }
        public string _id { get; set; }

        public string CollectionName { get; set; }

    }
}
