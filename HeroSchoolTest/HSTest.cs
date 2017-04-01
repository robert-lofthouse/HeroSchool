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
        private FakeSchoolRepository _schoolRepo = new FakeSchoolRepository();
        private FakeCardRepository _cardRepo = new FakeCardRepository();

        private IBattle _battle;

        ///tests

        ///1 - Create a school using factory, add to a general list of schools
        [TestMethod]
        public void CreateNewSchools()
        {
            IList<ISchool> SchoolList;

            ISchool NewSchool = SchoolFactory.CreateSchool("NewSchool");

            _schoolRepo.Add(NewSchool);

            SchoolList = _schoolRepo.Get();

            Assert.IsTrue(SchoolList.Count == 4);
            Assert.IsTrue(SchoolList[3].Name == "NewSchool");

        }
        ///2 - Create a card using factorym , add to a general list of cards
        [TestMethod]
        public void CreateNewCards()
        {
            IList<ICard> CardList;
        
            //create an attack, defense and modifier card
            ICard NewCard = CardFactory.CreateCard("NewCard", 1, 1, Constants.CardType.Attack);

            _cardRepo.Add(NewCard);

            CardList = _cardRepo.Get();

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
            IList<ISchool> SchoolList = _schoolRepo.Get();

            School lofthouseSchool = SchoolList.Where(x => x.Name == "Lofthouse").First() as School;

            lofthouseSchool.AddPlayer(PlayerFactory.CreatePlayer("David"));

            Assert.AreEqual(lofthouseSchool.Players.Count(), 2);

            List<IPlayer> lofthouseSchoolPlayers = lofthouseSchool.Players.ToList();

            Assert.AreEqual(lofthouseSchoolPlayers[1].Name, "David");
        }
        ///7 - Create heros for a player
        [TestMethod]
        public void CreateNewHero()
        {
            IList<ISchool> schoolList = _schoolRepo.Get();
            //grab a random school from the repository
            School school = schoolList[new Random().Next(schoolList.Count() - 1)] as School;

            // grab a random player from the schools player list
            IPlayer player = school.Players.ToList()[new Random().Next(school.Players.Count()-1)];
            FakeHeroRepository heroRepo = new FakeHeroRepository(player);

            Assert.AreEqual(player.Heroes().Count(), 1);

            heroRepo.Add("MyHero", 14, 4);

            IList<IHero> heroes = heroRepo.Get();

            HeroCard myhero = (HeroCard)heroes.Where(x => x.Name == "MyHero").First();

            Assert.IsNotNull(myhero);
            Assert.AreEqual(player.Heroes().Count(), 2);
            Assert.AreEqual(myhero.Value, 14);
            Assert.AreEqual(myhero.Energy, 4);
            Assert.AreEqual(myhero.Type, Constants.CardType.Hero);
        }

        ///8 - Add cards to player collection
        [TestMethod]
        public void AddCardsToPlayer()
        {
            IList<ISchool> schoolList = _schoolRepo.Get();
            IList<ICard> cardList = _cardRepo.Get();

            //grab a random school from the repository
            ISchool school = schoolList[new Random().Next(schoolList.Count() - 1)];

            // grab a random player from the schools player list
            IPlayer player = school.Players.ToList()[new Random().Next(school.Players.Count()-1)];


            player.AddCardtoCollection(cardList.Where(x => x.Name == "Fireball").First());
            player.AddCardtoCollection(cardList.Where(x => x.Name == "Block").First());
            player.AddCardtoCollection(cardList.Where(x => x.Name == "Boost").First());

            Assert.AreEqual(player.AttackCardCollection().Count, 1);
            Assert.AreEqual(player.DefenseCardCollection().Count, 1);
            Assert.AreEqual(player.ModifierCardCollection().Count, 1);

            Assert.AreEqual(player.ModifierCardCollection()[0].Name, "Boost");
            Assert.AreEqual(player.DefenseCardCollection()[0].Name, "Block");
            Assert.AreEqual(player.AttackCardCollection()[0].Name, "Fireball");
        }

        ///9 - Add cards from collection to a hero
        [TestMethod]
        public void AddCardsToHero()
        {
            IList<ISchool> schoolList = _schoolRepo.Get();
            IList<ICard> cardList = _cardRepo.Get();

            //grab a random school from the repository
            ISchool school = schoolList[new Random().Next(schoolList.Count() - 1)];

            // grab a random player from the schools player list
            IPlayer player = school.Players.ToList()[new Random().Next(school.Players.Count() - 1)];

            //add the cards to the player's collection
            player.AddCardtoCollection(cardList.Where(x => x.Name == "Fireball").First());
            player.AddCardtoCollection(cardList.Where(x => x.Name == "Block").First());
            player.AddCardtoCollection(cardList.Where(x => x.Name == "Boost").First());            
            

            //create a new hero and add it to the player hero collection
            FakeHeroRepository heroRepo = new FakeHeroRepository(player);
            heroRepo.Add("MyHero", 14, 4);

            IList<IHero> heroes = heroRepo.Get();

            IHero myhero = (IHero)heroes.Where(x => x.Name == "MyHero").First();

            //add the fireball and block card to the hero deck
            myhero.AddCardtoDeck(cardList.Where(x => x.Name == "Fireball").First());
            myhero.AddCardtoDeck(cardList.Where(x => x.Name == "Block").First());

            Assert.AreEqual(myhero.CardDeck.Count, 2);
            Assert.AreNotEqual(myhero.CardDeck.Where(x => x.Name == "Fireball").First(), null);
            Assert.AreNotEqual(myhero.CardDeck.Where(x => x.Name == "Block").First(), null);

            Assert.AreEqual(myhero.CardDeck.Where(x => x.Name == "Fireball").First(), player.GetAttackCard("Fireball") as ICard);
        }
        ///10- Create a battle between 2 heros from opposing schools
        [TestMethod]
        public void CreateBattle()
        {
            //prepare
            IList<ISchool> schoolList = _schoolRepo.Get();
            IList<ICard> cardList = _cardRepo.Get();
            
            //add the cards to the player's collection

            foreach (ISchool school in schoolList)
            {
                foreach (IPlayer player in school.Players)
                {
                    foreach (ICard card in cardList)
                    {
                        player.AddCardtoCollection(card);
                    }
                }
            }

            //create the battle
            ISchool s1 = schoolList[0];
            IPlayer p1 = s1.Players.ToList()[0];
            FakeHeroRepository heroRepo1 = new FakeHeroRepository(p1);
            IHero h1 = p1.Heroes()[0];

            ISchool s2 = schoolList[1];
            IPlayer p2 = s2.Players.ToList()[0];

            FakeHeroRepository heroRepo2 = new FakeHeroRepository(p2);
            IHero h2 = p2.Heroes()[0];

            for (int i = 1; h1.Name == h2.Name; i++)
            {
                heroRepo2 = new FakeHeroRepository(p2);
                h2 = p2.Heroes()[i];
            }

            _battle = BattleFactory.CreateBattle(h1, h2);

            Assert.AreNotEqual(_battle.AttackingHero, null);
            Assert.AreNotEqual(_battle.DefendingHero, null);
            Assert.AreNotEqual(_battle.DefendingHero, _battle.AttackingHero);

        }
        ///11- draw 3 cards from player deck (into PlayableCards)
        ///12- play cards (into PlayedCards - must be able to play based on energy)
        ///13- execute attack (call doattack on the battle)
        ///14- Repeat from 11 until one hero's health is less than 1

    }
}
