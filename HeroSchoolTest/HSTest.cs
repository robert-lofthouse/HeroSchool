using Microsoft.VisualStudio.TestTools.UnitTesting;
using HeroSchool;
using HeroSchool.Repositories;
using System.Collections.Generic;
using HeroSchool.Interfaces;
using HeroSchool.Factories;
using System.Linq;

namespace HeroSchoolTest
{


    [TestClass]
    public class HSTest
    {
        private FakeSchoolRepository schoolRepo = new FakeSchoolRepository();
        private FakeCardRepository cardRepo = new FakeCardRepository();

        

        private IBattle Battle;

        ///tests

        ///1 - Create a school using factory, add to a general list of schools
        [TestMethod]
        public void CreateNewSchools()
        {
            List<School> SchoolList;

            ISchool NewSchool = SchoolFactory.CreateSchool("NewSchool");

            schoolRepo.Add(NewSchool);

            SchoolList = (List<School>)schoolRepo.Get();

            Assert.IsTrue(SchoolList.Count == 4);
            Assert.IsTrue(SchoolList[3].Name == "NewSchool");

        }
        ///2 - Create a card using factorym , add to a general list of cards
        [TestMethod]
        public void CreateNewCards()
        {
            List<Card> CardList;
        
            //create an attack, defense and modifier card
            Card NewCard = CardFactory.CreateCard("NewCard", 1, 1, Constants.CardType.Attack);

            cardRepo.Add(NewCard);

            CardList = (List<Card>)cardRepo.Get();

            Assert.AreEqual(CardList.Count, 6);
            ActionCard actcard = (ActionCard)CardList[5];
            Assert.AreEqual(actcard.ReturnEnergy, 0);
            Assert.AreEqual(actcard.Energy, 1);
            Assert.AreEqual(actcard.Name, "NewCard");

        }
        ///3 - Create a player using factory, add to a general list of players
        [TestMethod]
        public void CreateNewPlayers()
        {
            List<School> SchoolList = (List<School>)schoolRepo.Get();

            School buckSchool = SchoolList.Find(x => x.Name == "Buck");
            School lofthouseSchool = SchoolList.Find(x => x.Name == "Lofthouse");
            School ogilvieSchool = SchoolList.Find(x => x.Name == "Ogilvie");

            buckSchool.AddPlayer(PlayerFactory.CreatePlayer("Aidan"));
            lofthouseSchool.AddPlayer(PlayerFactory.CreatePlayer("David"));
            ogilvieSchool.AddPlayer(PlayerFactory.CreatePlayer("Simon"));

            Assert.AreEqual(buckSchool.Players.Count(), 2);
            Assert.AreEqual(lofthouseSchool.Players.Count(), 2);
            Assert.AreEqual(ogilvieSchool.Players.Count(), 2);

            List<IPlayer> buckSchoolPlayers = buckSchool.Players.ToList();
            List<IPlayer> lofthouseSchoolPlayers = lofthouseSchool.Players.ToList();
            List<IPlayer> ogilvieSchoolPlayers = ogilvieSchool.Players.ToList();

            Assert.AreEqual(buckSchoolPlayers[1].Name, "Aidan");
            Assert.AreEqual(lofthouseSchoolPlayers[1].Name, "David");
            Assert.AreEqual(ogilvieSchoolPlayers[1].Name, "Simon");
        }

        ///4 - Retrieve schools into general list of schools
        ///5 - Retrieve Cards into general list of cards
        ///7 - Create heros in school
        ///8 - Add cards to player collection
        ///9 - Add cards from collection to a hero
        ///10- Create a battle between 2 heros from opposing schools
        ///11- draw 3 cards from player deck (into PlayableCards)
        ///12- play cards (into PlayedCards - must be able to play based on energy)
        ///13- execute attack (call doattack on the battle)
        ///14- Repeat from 11 until one hero's health is less than 1

    }
}
