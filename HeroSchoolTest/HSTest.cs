using Microsoft.VisualStudio.TestTools.UnitTesting;
using HeroSchool;

namespace HeroSchoolTest
{
    [TestClass]
    public class HSTest
    {
        PlayerCard player1;
        PlayerCard player2;

        [TestMethod]
        public void CreatePlayer1()
        {
            player1 = new PlayerCard("Rob", 100);
            player1.AttackCardDeck.Add(new AttackCard("Lightning", 3));
            player1.AttackCardDeck.Add(new AttackCard("Fireball", 4));
            player1.AttackCardDeck.Add(new AttackCard("Stone", 1));

            player1.DefenseCardDeck.Add(new DefenseCard("Block", 3));
            player1.DefenseCardDeck.Add(new DefenseCard("Dodge", 2));
            player1.DefenseCardDeck.Add(new DefenseCard("Turtle", 1));

            player1.ModifierCardDeck.Add(new ModifierCard("Focus", 1));
            player1.ModifierCardDeck.Add(new ModifierCard("Rage", 2));
            player1.ModifierCardDeck.Add(new ModifierCard("Nuke", 50));

            Assert.IsNotNull(player1);
            Assert.IsTrue(player1.ModifierCardDeck.Count == 3);
            Assert.IsTrue(player1.AttackCardDeck.Count == 3);
            Assert.IsTrue(player1.DefenseCardDeck.Count == 3);

            Assert.IsTrue(player1.Name == "Rob");
            Assert.IsTrue(player1.Value == 100);
            Assert.IsTrue(player1.Type == Constants.CardType.Player);

            Assert.IsTrue(player1.ModifierCardDeck[1].Name == "Rage");
            
        }
        
        [TestMethod]
        public void CreatePlayer2()
        {
            player2 = new PlayerCard("Alan", 100);
            player2.AttackCardDeck.Add(new AttackCard("Laserblast", 3));
            player2.AttackCardDeck.Add(new AttackCard("Bazooka", 4));
            player2.AttackCardDeck.Add(new AttackCard("Punch", 1));

            player2.DefenseCardDeck.Add(new DefenseCard("Parry", 3));
            player2.DefenseCardDeck.Add(new DefenseCard("Duck", 2));
            player2.DefenseCardDeck.Add(new DefenseCard("Rockstand", 1));

            player2.ModifierCardDeck.Add(new ModifierCard("Concentate", 1));
            player2.ModifierCardDeck.Add(new ModifierCard("Anger", 2));
            player2.ModifierCardDeck.Add(new ModifierCard("Destroy", 50));
        }

        [TestMethod]
        public void Attacktest()
        {
            CreatePlayer1();
            CreatePlayer2();

            //add a defense card to play from the deck
            player1.PlayCard(player1.DefenseCardDeck.Find(card => card.Name == "Dodge"));

            //add an attack card to play from the deck
            player2.PlayCard(player2.AttackCardDeck.Find(card => card.Name == "Laserblast"));

            //apply the attack card to the defence card from the played cards
            Constants.AttackResult ar = player1.PerformAttack(player2.PlayedAttackCards.Find(x => x.Name == "Laserblast"));

            Assert.IsNotNull(ar);
        }
    }
}
