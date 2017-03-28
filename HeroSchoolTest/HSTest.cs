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

        private List<Card> CardList = new List<Card>();
        private List<ISchool> SchoolList = new List<ISchool>();
        private IBattle Battle;

        ///tests

        ///1 - Create a school using factory, add to a general list of schools
        [TestMethod]
        public void CreateNewSchools()
        {
            ISchool buckSchool = SchoolFactory.CreateSchool("Buck");
            ISchool lofthouseSchool = SchoolFactory.CreateSchool("Lofthouse");

            SchoolList.Add(buckSchool);
            SchoolList.Add(lofthouseSchool);

            Assert.IsTrue(SchoolList.ToList().Count == 2);
            Assert.IsTrue(SchoolList.ToList()[0].Name == "Buck");
            Assert.IsTrue(SchoolList.ToList()[1].Name == "Lofthouse");

        }
        ///2 - Create a card using factorym , add to a general list of cards
        [TestMethod]
        public void CreateNewCards()
        {
            //create an attack, defense and modifier card
            Card atkcard = CardFactory.CreateCard("Attack1", 1, 1, Constants.CardType.Attack);
            Card atkcard2 = CardFactory.CreateCard("Attack2", 2, 2, Constants.CardType.Attack,1);
            Card defcard = CardFactory.CreateCard("Defense1", 2, 2, Constants.CardType.Defense,1);
            Card defcard2 = CardFactory.CreateCard("Defense2", 3, 2, Constants.CardType.Defense,1);
            Card modCard = CardFactory.CreateCard("Modifier1", 1, 1, Constants.CardType.Modifier);

            CardList.Add(atkcard);
            CardList.Add(atkcard2);
            CardList.Add(defcard);
            CardList.Add(defcard2);
            CardList.Add(modCard);

            Assert.AreEqual(CardList.Count, 5);
            ActionCard actcard = (ActionCard)CardList[2];
            Assert.AreEqual(actcard.ReturnEnergy, 1);
            Assert.AreEqual(actcard.Energy, 2);

        }
        ///3 - Create a player using factory, add to a general list of players
        ///4 - Retrieve schools into general list of schools
        ///5 - Retrieve Cards into general list of cards
        ///6 - Retrieve players into general list of players
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
