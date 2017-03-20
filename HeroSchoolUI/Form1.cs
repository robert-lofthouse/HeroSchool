﻿using HeroSchool;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeroSchoolUI
{
    public partial class Form1 : Form
    {
        PlayerCard player1;
        PlayerCard player2;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            ResetPlayers();
        }
        public void CreatePlayer2()
        {
            player2 = new PlayerCard("Alan", 10);
            player2.AddAttackCard("Laserblast", 3);
            player2.AddAttackCard("Bazooka", 6);
            player2.AddAttackCard("Punch", 1);

            player2.AddDefenseCard("Parry", 3);
            player2.AddDefenseCard("Duck", 2);
            player2.AddDefenseCard("Rockstand", 1);

            player2.ModifierCardDeck.Add(new ModifierCard("Concentate", 1));
            player2.ModifierCardDeck.Add(new ModifierCard("Anger", 2));
            player2.ModifierCardDeck.Add(new ModifierCard("Destroy", 50));
        }
        public void CreatePlayer1()
        {
            player1 = new PlayerCard("Rob", 10);
            player1.AddAttackCard("Lightning", 3);
            player1.AddAttackCard("Fireball", 6);
            player1.AddAttackCard("Stone", 1);

            player1.AddDefenseCard("Block", 3);
            player1.AddDefenseCard("Dodge", 2);
            player1.AddDefenseCard("Turtle", 1);

            player1.ModifierCardDeck.Add(new ModifierCard("Focus", 1));
            player1.ModifierCardDeck.Add(new ModifierCard("Rage", 2));
            player1.ModifierCardDeck.Add(new ModifierCard("Nuke", 50));

        }
        public void ResetPlayers()
        {
            CreatePlayer1();
            CreatePlayer2();

            txtPlayer1Value.Text = player1.Value.ToString();
            txtPlayer2Value.Text = player2.Value.ToString();

            Player1.BackColor = SystemColors.Control;
            Player2.BackColor = SystemColors.Control;

            BindList(player1.DefenseCardDeck, lstDefenseCardDeckP1);
            BindList(player1.AttackCardDeck, lstAttackCardDeckP1);
            BindList(player1.PlayedAttackCards, lstPlayedAttackCardsP1);
            BindList(player1.PlayedDefenseCards, lstPlayedDefenseCardsP1);
            BindList(player2.DefenseCardDeck, lstDefenseCardDeckP2);
            BindList(player2.AttackCardDeck, lstAttackCardDeckP2);
            BindList(player2.PlayedAttackCards, lstPlayedAttackCardsP2);
            BindList(player2.PlayedDefenseCards, lstPlayedDefenseCardsP2);

        }

        private void BindList(List<DefenseCard> ls, ListBox lb)
        {
            lb.DataSource = null;
            BindingSource bs = new BindingSource();
            bs.DataSource = ls;
            lb.DataSource = bs;
        }

        private void BindList(List<AttackCard> ls, ListBox lb)
        {
            lb.DataSource = null;
            BindingSource bs = new BindingSource();
            bs.DataSource = ls;
            lb.DataSource = bs;
        }

        private void lstAttackCardDeckP1_MouseDown(object sender, MouseEventArgs e)
        {
            lstAttackCardDeckP1.DoDragDrop(lstAttackCardDeckP1.SelectedItem.ToString().Split('(')[0].Trim(), DragDropEffects.Move);
        }

        private void lstPlayedAttackCardsP1_DragDrop(object sender, DragEventArgs e)
        {
            AttackCard atkCard = player1.AttackCard(e.Data.GetData(DataFormats.StringFormat).ToString().Split('(')[0].Trim());

            if (atkCard != null)
            {
                player1.PlayCard(atkCard);

                BindList(player1.PlayedAttackCards, lstPlayedAttackCardsP1);
                BindList(player1.AttackCardDeck, lstAttackCardDeckP1);
            }
        }
        private void lstPlayedAttackCardsP1_DragOver(object sender, DragEventArgs e)
        {
            string atkCardName = e.Data.GetData(DataFormats.StringFormat).ToString().Split('(')[0].Trim();

            if (player1.AttackCard(atkCardName) != null)
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {

            ResetPlayers();
        }

        private void lstDefenseCardDeckP1_MouseDown(object sender, MouseEventArgs e)
        {
            lstDefenseCardDeckP1.DoDragDrop(lstDefenseCardDeckP1.SelectedItem.ToString().Split('(')[0].Trim(), DragDropEffects.Move);
        }

        private void lstPlayedDefenseCardsP1_DragOver(object sender, DragEventArgs e)
        {
            string defCardName = e.Data.GetData(DataFormats.StringFormat).ToString().Split('(')[0].Trim();

            if (player1.DefenseCard(defCardName) != null)
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void lstAttackCardDeckP2_MouseDown(object sender, MouseEventArgs e)
        {
            lstAttackCardDeckP2.DoDragDrop(lstAttackCardDeckP2.SelectedItem.ToString(), DragDropEffects.Move);
        }

        private void lstPlayedAttackCardsP2_DragDrop(object sender, DragEventArgs e)
        {
            string atkCardName = e.Data.GetData(DataFormats.StringFormat).ToString().Split('(')[0].Trim();

            if (player2.AttackCard(atkCardName) != null)
            {
                player2.PlayCard(player2.AttackCard(atkCardName));
                BindList(player2.PlayedAttackCards, lstPlayedAttackCardsP2);
                BindList(player2.AttackCardDeck, lstAttackCardDeckP2);
            }

        }

        private void lstPlayedAttackCardsP2_DragOver(object sender, DragEventArgs e)
        {
            AttackCard atkCard = player2.AttackCard(e.Data.GetData(DataFormats.StringFormat).ToString().Split('(')[0].Trim());

            if (atkCard != null)
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
        
        private void lstDefenseCardDeckP2_MouseDown(object sender, MouseEventArgs e)
        {
            lstDefenseCardDeckP2.DoDragDrop(lstDefenseCardDeckP2.SelectedItem.ToString().Split('(')[0].Trim(), DragDropEffects.Move);
        }

        private void lstPlayedDefenseCardsP2_DragOver(object sender, DragEventArgs e)
        {
            DefenseCard defCard = player2.DefenseCard(e.Data.GetData(DataFormats.StringFormat).ToString().Split('(')[0].Trim());

            if (defCard != null)
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void lstPlayedAttackCardsP1_MouseDown(object sender, MouseEventArgs e)
        {
            lstPlayedAttackCardsP1.DoDragDrop(lstPlayedAttackCardsP1.SelectedItem.ToString(), DragDropEffects.Copy);
        }

        private void lstPlayedAttackCardsP2_MouseDown(object sender, MouseEventArgs e)
        {
            lstPlayedAttackCardsP2.DoDragDrop(lstPlayedAttackCardsP2.SelectedItem.ToString(), DragDropEffects.Copy);
        }

        private void txtPlayer2Value_DragOver(object sender, DragEventArgs e)
        {
            AttackCard atkCard = player1.PlayedAttackCard(e.Data.GetData(DataFormats.StringFormat).ToString().Split('(')[0].Trim());

            if (atkCard != null)
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void txtPlayer1Value_DragOver(object sender, DragEventArgs e)
        {
            AttackCard atkCard = player2.PlayedAttackCard(e.Data.GetData(DataFormats.StringFormat).ToString().Split('(')[0].Trim());

            if (atkCard != null)
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void txtPlayer2Value_DragDrop(object sender, DragEventArgs e)
        {
            AttackCard cardToUseforAttack = player1.PlayedAttackCard(e.Data.GetData(DataFormats.StringFormat).ToString().Split('(')[0].Trim());

            if (cardToUseforAttack != null)
            {

                if (player2.PerformAttack(cardToUseforAttack) == Constants.AttackResult.AttackSuccededDamagedAndKilled)
                {
                    Player2.BackColor = Color.Red;
                }

                txtPlayer2Value.Text = player2.Value.ToString();

                BindList(player2.PlayedDefenseCards, lstPlayedDefenseCardsP2);
                BindList(player1.PlayedAttackCards, lstPlayedAttackCardsP1);
            }
        }

        private void txtPlayer1Value_DragDrop(object sender, DragEventArgs e)
        {
            AttackCard cardToUseforAttack = player2.PlayedAttackCard(e.Data.GetData(DataFormats.StringFormat).ToString().Split('(')[0].Trim());

            if (cardToUseforAttack != null)
            {

                if (player1.PerformAttack(cardToUseforAttack) == Constants.AttackResult.AttackSuccededDamagedAndKilled)
                {
                    Player1.BackColor = Color.Red;
                }

                txtPlayer1Value.Text = player1.Value.ToString();

                BindList(player1.PlayedDefenseCards, lstPlayedDefenseCardsP1);
                BindList(player2.PlayedAttackCards, lstPlayedAttackCardsP2);
            }
        }

        private void lstPlayedDefenseCardsP1_DragDrop(object sender, DragEventArgs e)
        {
            DefenseCard defCard = player1.DefenseCard(e.Data.GetData(DataFormats.StringFormat).ToString().Split('(')[0].Trim());

            if (defCard!= null)
            {
                player1.PlayCard(defCard);

                BindList(player1.PlayedDefenseCards, lstPlayedDefenseCardsP1);
                BindList(player1.DefenseCardDeck, lstDefenseCardDeckP1);
            }

        }

        private void lstPlayedDefenseCardsP2_DragDrop(object sender, DragEventArgs e)
        {
            DefenseCard defCard = player2.DefenseCard(e.Data.GetData(DataFormats.StringFormat).ToString().Split('(')[0].Trim());

            if (defCard != null)
            {
                player2.PlayCard(defCard);
                BindList(player2.PlayedDefenseCards, lstPlayedDefenseCardsP2);
                BindList(player2.DefenseCardDeck, lstDefenseCardDeckP2);
            }

        }
    }
}
