using Microsoft.VisualStudio.TestTools.UnitTesting;
using HeroSchool;
using HeroSchool.Repositories;
using System.Collections.Generic;
using HeroSchool.Interfaces;
using HeroSchool.Factories;
using System.Linq;
using System;

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
            IList<IHeroSchool> SchoolList;

            ISchool NewSchool = SchoolFactory.CreateSchool("NewSchool");

            schoolRepo.Add(NewSchool);

            SchoolList = schoolRepo.Get();

            Assert.IsTrue(SchoolList.Count == 4);
            Assert.IsTrue(SchoolList[3].Name == "NewSchool");

        }
        ///2 - Create a card using factorym , add to a general list of cards
        [TestMethod]
        public void CreateNewCards()
        {
            IList<IHeroSchool> CardList;
        
            //create an attack, defense and modifier card
            ICard NewCard = CardFactory.CreateCard("NewCard", 1, 1, Constants.CardType.Attack);

            cardRepo.Add(NewCard);

            CardList = cardRepo.Get();

            Assert.AreEqual(CardList.Count, 6);
            IActionable actcard = (ActionCard)CardList[5];
            Assert.AreEqual(actcard.ReturnEnergy, 0);
            Assert.AreEqual(actcard.Energy, 1);
            Assert.AreEqual(actcard.Name, "NewCard");

        }
        ///3 - Create a player using factory, add to a general list of players
        [TestMethod]
        public void CreateNewPlayer()
        {
            IList<IHeroSchool> SchoolList = schoolRepo.Get();

            School lofthouseSchool = SchoolList.Where(x => x.Name == "Lofthouse").First() as School;

            lofthouseSchool.AddPlayer(PlayerFactory.CreatePlayer("David"));

            Assert.AreEqual(lofthouseSchool.Players().Count(), 2);

            List<IPlayer> lofthouseSchoolPlayers = lofthouseSchool.Players().ToList();

            Assert.AreEqual(lofthouseSchoolPlayers[1].Name, "David");
        }
        ///7 - Create heros for a player
        [TestMethod]
        public void CreateNewHero()
        {
            IList<IHeroSchool> schoolList = schoolRepo.Get();
            //grab a random school from the repository
            School school = schoolList[new Random().Next(schoolList.Count() - 1)] as School;

            // grab a random player from the schools player list
            Player player = (Player)school.Players().ToList()[new Random().Next(school.Players().Count()-1)];
            FakeHeroRepository heroRepo = new FakeHeroRepository(player);

            Assert.AreEqual(player.Heroes().Count(), 1);

            heroRepo.Add("MyHero", 14, 4);

            IList<IHeroSchool> heroes = heroRepo.Get();

            HeroCard myhero = (HeroCard)heroes.Where(x => x.Name == "MyHero").First();

            Assert.IsNotNull(myhero);
            Assert.AreEqual(player.Heroes().Count(), 2);
            Assert.AreEqual(myhero.Value, 14);
            Assert.AreEqual(myhero.Energy, 4);
            Assert.AreEqual(myhero.Type, Constants.CardType.Hero);
        }

        ///8 - Add cards to player collection
        ///9 - Add cards from collection to a hero
        ///10- Create a battle between 2 heros from opposing schools
        ///11- draw 3 cards from player deck (into PlayableCards)
        ///12- play cards (into PlayedCards - must be able to play based on energy)
        ///13- execute attack (call doattack on the battle)
        ///14- Repeat from 11 until one hero's health is less than 1

    }
}
