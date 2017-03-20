using Microsoft.VisualStudio.TestTools.UnitTesting;
using HeroSchool;

namespace HeroSchoolTest
{
    [TestClass]
    public class HSTest
    {
        HeroCard player1;
        HeroCard player2;

        [TestMethod]
        public void CreatePlayer1()
        {
            player1 = new HeroCard("Rob", 100);
            player1.AttackCardCollection.Add(new AttackCard("Lightning", 3));
            player1.AttackCardCollection.Add(new AttackCard("Fireball", 4));
            player1.AttackCardCollection.Add(new AttackCard("Stone", 1));

            player1.DefenseCardCollection.Add(new DefenseCard("Block", 3));
            player1.DefenseCardCollection.Add(new DefenseCard("Dodge", 2));
            player1.DefenseCardCollection.Add(new DefenseCard("Turtle", 1));

            player1.ModifierCardCollection.Add(new ModifierCard("Focus", 1));
            player1.ModifierCardCollection.Add(new ModifierCard("Rage", 2));
            player1.ModifierCardCollection.Add(new ModifierCard("Nuke", 50));

            Assert.IsNotNull(player1);
            Assert.IsTrue(player1.ModifierCardCollection.Count == 3);
            Assert.IsTrue(player1.AttackCardCollection.Count == 3);
            Assert.IsTrue(player1.DefenseCardCollection.Count == 3);

            Assert.IsTrue(player1.Name == "Rob");
            Assert.IsTrue(player1.Value == 100);
            Assert.IsTrue(player1.Type == Constants.CardType.Player);

            Assert.IsTrue(player1.ModifierCardCollection[1].Name == "Rage");
            
        }
        
        [TestMethod]
        public void CreatePlayer2()
        {
            player2 = new HeroCard("Alan", 100);
            player2.AttackCardCollection.Add(new AttackCard("Laserblast", 3));
            player2.AttackCardCollection.Add(new AttackCard("Bazooka", 4));
            player2.AttackCardCollection.Add(new AttackCard("Punch", 1));

            player2.DefenseCardCollection.Add(new DefenseCard("Parry", 3));
            player2.DefenseCardCollection.Add(new DefenseCard("Duck", 2));
            player2.DefenseCardCollection.Add(new DefenseCard("Rockstand", 1));

            player2.ModifierCardCollection.Add(new ModifierCard("Concentate", 1));
            player2.ModifierCardCollection.Add(new ModifierCard("Anger", 2));
            player2.ModifierCardCollection.Add(new ModifierCard("Destroy", 50));
        }

        [TestMethod]
        public void Attacktest()
        {
            CreatePlayer1();
            CreatePlayer2();

            //add a defense card to play from the deck
            player1.PlayCardfromDeck(player1.DefenseCardCollection.Find(card => card.Name == "Dodge"));

            //add an attack card to play from the deck
            player2.PlayCardfromDeck(player2.AttackCardCollection.Find(card => card.Name == "Laserblast"));

            //apply the attack card to the defence card from the played cards
            Constants.AttackResult ar = player1.PerformAttack(player2.PlayedAttackCards.Find(x => x.Name == "Laserblast"));

            Assert.IsNotNull(ar);
        }
    }
}
