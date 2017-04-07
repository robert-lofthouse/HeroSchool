using Microsoft.VisualStudio.TestTools.UnitTesting;
using HeroSchool;
using HeroSchool.Repositories;
using System.Collections.Generic;
using HeroSchool.Interfaces;
using HeroSchool.Factories;
using System.Linq;
using System;
using System.Diagnostics;

namespace HeroSchoolTest
{
    [TestClass]
    public class HSTest
    {
        IList<ISchool> _schoolList;
        IList<ICard> _cardList;

        private FakeCardRepository _cardRepo;
        private FakeSchoolRepository _schoolRepo;

        private IBattle _battle;

        private void BasicData()
        {
            _cardRepo = new FakeCardRepository();
            _schoolRepo = new FakeSchoolRepository(_cardRepo);

            _schoolList = _schoolRepo.Get();
            _cardList = _cardRepo.Get();

            foreach (ISchool school in _schoolList)
            {
                foreach (IPlayer player in school.Players)
                {
                    foreach (ICard card in _cardList)
                    {
                        player.AddCardtoCollection(card);

                        foreach (IHero hero in player.Heroes)
                        {
                            hero.AddCardtoDeck(card);
                        }
                    }
                }
            }
        }

        private void BattleData()
        {
            BasicData();

            Random rand = new Random();
            int s1rand = rand.Next(_schoolList.Count - 1);
            int s2rand = rand.Next(_schoolList.Count - 1);

            while (s1rand == s2rand)
            {
                s2rand = rand.Next(_schoolList.Count - 1);
            }

            ISchool s1 = _schoolList[s1rand];
            IPlayer p1 = s1.Players.ElementAt(rand.Next(s1.Players.Count - 1));
            IHero h1 = p1.Heroes.ElementAt(rand.Next(p1.Heroes.Count - 1));

            ISchool s2 = _schoolList[s2rand];
            IPlayer p2 = s2.Players.ElementAt(rand.Next(s2.Players.Count - 1));
            IHero h2 = p2.Heroes.ElementAt(rand.Next(p2.Heroes.Count - 1));

            for (int i = 0; h1.Name == h2.Name; i++)
            {
                h2 = p2.Heroes.ElementAt(i);
            }

            _battle = BattleFactory.CreateBattle(h1, h2);
        }

        private void BattleCardsDrawnData()
        {
            BattleData();
            IHero ha = _battle.AttackingHero;
            IHero hd = _battle.DefendingHero;

            while (ha.CardDeck.Count > 0)
            {
                ha.DrawCards(1);
            }
            while (hd.CardDeck.Count > 0)
            {
                hd.DrawCards(1);
            }
        }

        private void BattleCardsPlayedData()
        {
            BattleCardsDrawnData();
            IHero ha = _battle.AttackingHero;
            IHero hd = _battle.DefendingHero;

            ha.PlayCard(ha.PlayableCards.OfType<IActionable>().FirstOrDefault(x => x.Type == Global.CardType.Attack));
            hd.PlayCard(hd.PlayableCards.OfType<IDefendable>().FirstOrDefault());
        }

        private void BattleCardsModifiedData()
        {
            BattleCardsPlayedData();

            IHero ha = _battle.AttackingHero;
            IHero hd = _battle.DefendingHero;

            if (ha.PlayedCards.OfType<IActionable>().Any())
            {
                IActionable atkHeroAtkCard = ha.PlayedCards.OfType<IActionable>().First();
                if (ha.PlayableCards.OfType<IModifier>().Any())
                {
                    IModifier atkHeroModCard = ha.PlayableCards.OfType<IModifier>().First();
                    atkHeroAtkCard.ApplyModifierCard(atkHeroModCard);
                }
            }

            if (hd.PlayedCards.OfType<IDefendable>().Any())
            {
                IDefendable defHeroDefCard = hd.PlayedCards.OfType<IDefendable>().First();
                if (hd.PlayedCards.OfType<IDefendable>().Any())
                {
                    IModifier defHeroModCard = hd.PlayableCards.OfType<IModifier>().First();
                    defHeroDefCard.ApplyModifierCard(defHeroModCard);
                }
            }
        }

        //tests

        //1 - Create a school using factory, add to a general list of schools
        [TestMethod]
        public void TestCreateNewSchools()
        {
            BasicData();

            ISchool NewSchool = SchoolFactory.CreateSchool("NewSchool");

            _schoolRepo.Add(NewSchool);

            _schoolList = _schoolRepo.Get();

            Assert.IsTrue(_schoolList.Count == 4);
            Assert.IsTrue(_schoolList[3].Name == "NewSchool");
        }
        //2 - Create a card using factorym , add to a general list of cards
        [TestMethod]
        public void TestCreateNewCards()
        {
            BasicData();

            //create an attack, defense and modifier card
            ICard NewCard = CardFactory.CreateCard("NewCard", 1, 1, Global.CardType.Attack);

            _cardRepo.Add(NewCard);

            _cardList = _cardRepo.Get();

            Assert.AreEqual(_cardList.Count, 6);
            IActionable actcard = (ActionCard)_cardList[5];
            Assert.AreEqual(actcard.ReturnEnergy, 0);
            Assert.AreEqual(actcard.Energy, 1);
            Assert.AreEqual(actcard.Name, "NewCard");
        }
        //3 - Create a player using factory, add to a general list of players
        [TestMethod]
        public void TestCreateNewPlayer()
        {
            BasicData();

            School lofthouseSchool = _schoolList.First(x => x.Name == "Lofthouse")as School;

            lofthouseSchool.AddPlayer(PlayerFactory.CreatePlayer("David", _cardRepo));

            Assert.AreEqual(lofthouseSchool.Players.Count(), 2);
            Assert.AreEqual(lofthouseSchool.Players.ElementAt(1).Name, "David");
        }
        //7 - Create heros for a player
        [TestMethod]
        public void TestCreateNewHero()
        {
            BasicData();
            //grab a random school from the repository
            ISchool school = _schoolList[new Random().Next(_schoolList.Count - 1)];

            // grab a random player from the schools player list
            IPlayer player = school.Players.ElementAt(new Random().Next(school.Players.Count()-1));
            player.AddHero(HeroFactory.CreateHero("MyHero", 14, 4,player._id,new HeroArchetype(20,Global.HeroClass.Strength),_cardRepo,_schoolRepo));

            Assert.AreEqual(player.Heroes.Count(), 2);

            IHero myhero = player.Heroes.FirstOrDefault(x => x.Name == "MyHero");

            Assert.IsNotNull(myhero);
            Assert.AreEqual(player.Heroes.Count(), 2);
            Assert.AreEqual(myhero.Value, 14);
            Assert.AreEqual(myhero.Energy, 4);
            Assert.AreEqual(myhero.Type, Global.CardType.Hero);
        }

        //8 - Add cards to player collection
        [TestMethod]
        public void TestAddCardsToPlayer()
        {
            BasicData();

            //grab a random school from the repository
            ISchool school = _schoolList[new Random().Next(_schoolList.Count - 1)];

            // grab a random player from the schools player list
            IPlayer player = school
                .Players
                .ElementAt(new Random().Next(school.Players.Count()-1));

            ICard newAttackCard = CardFactory.CreateCard("New Attack", 1, 1, Global.CardType.Attack);
            _cardRepo.Add(newAttackCard);
            ICard newDefenseCard = CardFactory.CreateCard("New Defense", 1, 1, Global.CardType.Defense);
            _cardRepo.Add(newDefenseCard);
            ICard newModifierCard = CardFactory.CreateCard("New Modifier", 1, 1, Global.CardType.Modifier);
            _cardRepo.Add(newModifierCard);

            player.AddCardtoCollection(newAttackCard);
            player.AddCardtoCollection(newDefenseCard);
            player.AddCardtoCollection(newModifierCard);

            Assert.AreEqual(player.CardCollection().Count, 8);

            Assert.IsTrue(player.CardCollection().Any(x => x.Name == "New Modifier"));
            Assert.IsTrue(player.CardCollection().Any(x => x.Name == "New Defense"));
            Assert.IsTrue(player.CardCollection().Any(x => x.Name == "New Attack"));
        }

        //9 - Add cards from collection to a hero
        [TestMethod]
        public void TestAddCardsToHero()
        {
            BasicData();

            //grab a random school from the repository
            ISchool school = _schoolList[new Random().Next(_schoolList.Count - 1)];

            // grab a random player from the schools player list
            IPlayer player = school.Players.ElementAt(new Random().Next(school.Players.Count() - 1));

            IHero myhero = player.Heroes.ElementAt(0);

            //add the fireball card to the hero deck, it should fail
            myhero.AddCardtoDeck(_cardList.First(x => x.Name == "Fireball"));

            //create a new card and add it to the deck
            int beforDeckCount = myhero.CardDeck.Count;
            _cardRepo.Add(CardFactory.CreateCard("New Card", 4, 4, Global.CardType.Attack));
            _cardList = _cardRepo.Get();
            player.AddCardtoCollection(_cardList.First(x => x.Name == "New Card"));
            myhero.AddCardtoDeck(_cardList.First(x => x.Name == "New Card"));

            Assert.AreEqual(myhero.CardDeck.Count, beforDeckCount + 1);
            Assert.AreNotEqual(myhero.CardDeck.First(x => x.Name == "New Card"), null);

            Assert.AreEqual(myhero.CardDeck.FirstOrDefault(x => x.Name == "New Card"), player.CardCollection().FirstOrDefault(x=>x.Name =="New Card"));
        }
        //10- Create a battle between 2 heros from opposing schools
        [TestMethod]
        public void TestCreateBattle()
        {
            Random rand = new Random();
            //prepare
            BasicData();

            //create the battle
            int s1rand = rand.Next(_schoolList.Count - 1);
            int s2rand = rand.Next(_schoolList.Count - 1);

            while (s1rand == s2rand)
            {
                s2rand = rand.Next(_schoolList.Count - 1);
            }

            ISchool s1 = _schoolList[s1rand];
            IPlayer p1 = s1.Players.ElementAt(rand.Next(s1.Players.Count - 1));
            IHero h1 = p1.Heroes.ElementAt(rand.Next(p1.Heroes.Count - 1));

            ISchool s2 = _schoolList[s2rand];
            IPlayer p2 = s2.Players.ElementAt(rand.Next(s2.Players.Count - 1));
            IHero h2 = p2.Heroes.ElementAt(rand.Next(p2.Heroes.Count - 1));

            _battle = BattleFactory.CreateBattle(h1, h2);

            Assert.AreNotEqual(_battle.AttackingHero, null);
            Assert.AreNotEqual(_battle.DefendingHero, null);
            Assert.AreNotEqual(_battle.DefendingHero, _battle.AttackingHero);
        }
        //11- draw 3 cards from player deck (into PlayableCards)
        [TestMethod]
        public void TestDrawCards()
        {
            BattleData();

            IHero ha = _battle.AttackingHero;
            IHero hd = _battle.DefendingHero;

            ha.DrawCards(1);
            hd.DrawCards(1);

            Assert.AreEqual(ha.PlayableCards.Count, 1);
            Assert.AreEqual(hd.PlayableCards.Count, 1);

            ha.DrawCards(1);
            hd.DrawCards(1);

            Assert.AreEqual(_battle.AttackingHero.PlayableCards.Count, 2);
            Assert.AreEqual(_battle.DefendingHero.PlayableCards.Count, 2);
        }
        //12- play cards (into PlayedCards - must be able to play based on energy)
        [TestMethod]
        public void TestPlayCards()
        {
            BattleCardsDrawnData();

            IHero ha = _battle.AttackingHero;
            IHero hd = _battle.DefendingHero;

            int haenergy = ha.Energy;
            int hdenergy = hd.Energy;
            int haplayable = ha.PlayableCards.Count;
            int haplayed = hd.PlayedCards.Count;
            int hdplayable = ha.PlayableCards.Count;
            int hdplayed = hd.PlayedCards.Count;

            IActionable haplayablecard = ha.PlayableCards.OfType<IActionable>().FirstOrDefault();
            ha.PlayCard(haplayablecard);
            IDefendable hdplayablecard = hd.PlayableCards.OfType<IDefendable>().FirstOrDefault();
            hd.PlayCard(hdplayablecard);

            Assert.AreEqual(ha.Energy, haenergy - haplayablecard.Energy);
            Assert.AreEqual(ha.PlayedCards.Count, haplayed + 1);
            Assert.AreEqual(ha.PlayableCards.Count, haplayable - 1);

            Assert.AreEqual(hd.Energy, hdenergy - hdplayablecard.Energy);
            Assert.AreEqual(hd.PlayedCards.Count, hdplayed + 1);
            Assert.AreEqual(hd.PlayableCards.Count, hdplayable - 1);
        }
        //12.5 Apply Modifier
        [TestMethod]
        public void TestApplyModifier()
        {
            BattleCardsPlayedData();

            IHero ha = _battle.AttackingHero;
            IHero hd = _battle.DefendingHero;

            if (ha.PlayedCards.OfType<IActionable>().Any())
            {
                IActionable atkHeroAtkCard = ha.PlayedCards.OfType<IActionable>().First();
                if (ha.PlayableCards.OfType<IModifier>().Any())
                {
                    IModifier atkHeroModCard = ha.PlayableCards.OfType<IModifier>().First();
                    atkHeroAtkCard.ApplyModifierCard(atkHeroModCard);
                }
            }

            if (hd.PlayedCards.OfType<IDefendable>().Any())
            {
                IDefendable defHeroDefCard = hd.PlayedCards.OfType<IDefendable>().First();
                if (hd.PlayedCards.OfType<IDefendable>().Any())
                {
                    IModifier defHeroModCard = hd.PlayableCards.OfType<IModifier>().First();
                    defHeroDefCard.ApplyModifierCard(defHeroModCard);
                }
            }
        }

        //13- execute attack (call doattack on the battle)
        [TestMethod]
        public void TestExecuteAttack()
        {
            BattleCardsModifiedData();

            int attacker_before_playedcount = _battle.AttackingHero.PlayedCards.Count;
            string attacker_before_name = _battle.AttackingHero.ToString();
            int defender_before_playedcount = _battle.DefendingHero.PlayedCards.Count;
            string defender_before_name = _battle.DefendingHero.ToString();

            Debug.Print("*****Before Attack*****");
            Debug.Print("**attacker_before_playedcount:{0}", attacker_before_playedcount.ToString());
            Debug.Print("**attacker_before_name:{0}", attacker_before_name);
            Debug.Print("**defender_before_playedcount:{0}", defender_before_playedcount.ToString());
            Debug.Print("**defender_before_name:{0}", defender_before_name);
            Debug.Print("***********************");

            _battle.DoAttack();

            int attacker_after_playedcount = _battle.AttackingHero.PlayedCards.Count;
            string attacker_after_name = _battle.AttackingHero.ToString();
            int defender_after_playedcount = _battle.DefendingHero.PlayedCards.Count;
            string defender_after_name = _battle.DefendingHero.ToString();

            Debug.Print("*****After Attack*****");
            Debug.Print("**attacker_after_playedcount:{0}", attacker_after_playedcount.ToString());
            Debug.Print("**attacker_after_name:{0}", attacker_after_name);
            Debug.Print("**defender_after_playedcount:{0}", defender_after_playedcount.ToString());
            Debug.Print("**defender_after_name:{0}", defender_after_name);
            Debug.Print("***********************");

            Assert.AreNotEqual(attacker_before_name, attacker_after_name);
            Assert.AreNotEqual(defender_before_name, defender_after_name);

            Assert.AreEqual(attacker_before_name, defender_after_name );
            Assert.AreEqual(defender_before_name, attacker_after_name);

            Assert.AreNotEqual(attacker_before_playedcount, defender_after_playedcount);
        }
        //14- Repeat from 11 until one hero's health is less than 1
        [TestMethod]
        public void TestCompleteBattle()
        {
            BattleCardsModifiedData();

            while (_battle.AttackingHero.Value > 0 && _battle.DefendingHero.Value > 0)
            {
                Debug.WriteLine(string.Format("Before Attack; Attacking Hero - {0}, Defending Hero - {1}", _battle.AttackingHero.ToString(), _battle.DefendingHero.ToString()));
                _battle.DoAttack();
                Debug.WriteLine(string.Format("After Attack; Attacking Hero - {0}, Defending Hero - {1}", _battle.AttackingHero.ToString(), _battle.DefendingHero.ToString()));

                // Draw cards
                _battle.AttackingHero.DrawCards(1);
                _battle.DefendingHero.DrawCards(1);

                // Play Cards
                _battle
                    .AttackingHero
                    .PlayCard(_battle.AttackingHero.PlayableCards.OfType<IActionable>().FirstOrDefault(x => x.Type == Global.CardType.Attack));
                _battle
                    .DefendingHero
                    .PlayCard(_battle.DefendingHero.PlayableCards.OfType<IDefendable>().FirstOrDefault());
            }
            Debug.WriteLine(string.Format("Battle finished - Winner : {0}", _battle.AttackingHero.Value > 0 ? _battle.AttackingHero : _battle.DefendingHero));
        }

        [TestMethod]
        public void TestAddToCardRepo()
        {
            ICard newcard = CardFactory.CreateCard("New Attack Card", 10, 4, Global.CardType.Attack);
            IRepository<ICard> CardRepo = new CardRepository();

            CardRepo.Add(newcard);
        }

        [TestMethod]
        public void GetAllCardsfromRepo()
        {
            IRepository<ICard> CardRepo = new CardRepository();

            IList<ICard> cardlist = CardRepo.Get();

            Assert.IsNotNull(cardlist);
            Assert.IsTrue(cardlist.Count > 0);
            Assert.IsTrue(cardlist.FirstOrDefault(x => x.Name == "New Attack Card").Type == Global.CardType.Attack);
        }

        [TestMethod]
        public void GetCardFromRepo()
        {
            ICard card = CardFactory.CreateCard("New Attack Card", 0, 0, Global.CardType.Attack);

            IRepository<ICard> cardRepo = new CardRepository();

            ICard cardfromrepo = cardRepo.Get(card);
        }

        [TestMethod]
        public void DelCardFromRepo()
        {
            ICard card = CardFactory.CreateCard("234", 0, 0, Global.CardType.Attack);

            IRepository<ICard> cardRepo = new CardRepository();

            ICard cardfromrepo = cardRepo.Get(card);

            cardRepo.Delete(cardfromrepo);
        }
    }
}
