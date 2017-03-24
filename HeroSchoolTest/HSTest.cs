using Microsoft.VisualStudio.TestTools.UnitTesting;
using HeroSchool;

namespace HeroSchoolTest
{
    [TestClass]
    public class HSTest
    {
        PlayersMaster pm = new PlayersMaster();
        CardsMaster cm = new CardsMaster();

        [TestMethod]
        public void AddNewPlayer()
        {
            pm.CreatePlayer("Robert");
            pm.Add(new Player("Alan"));

            Assert.IsTrue(pm.Count == 2);
            Assert.IsTrue(pm[0].PlayerName == "Robert");
            Assert.IsTrue(pm[1].PlayerName == "Alan");
        }
    }
}
