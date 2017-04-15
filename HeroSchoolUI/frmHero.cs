using HeroSchool;
using HeroSchool.Interface;
using HeroSchool.Model;
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
    public partial class frmHero : Form
    {
        public Player player;
        public Hero hero;

        public frmHero()
        {
            InitializeComponent();
        }

        private void frmHero_Load(object sender, EventArgs e)
        {
            LoadLists();
            txtName.Text = hero.Name;
            txtValue.Text = hero.Value.ToString();
            txtEnergy.Text = hero.Energy.ToString();
        }

        private void LoadLists()
        {
            lstHeroCards.Items.Clear();
            lstPlayerCards.Items.Clear();

            foreach (Card card in player.CardCollection().Where(x => !hero.CardDeck().Any(c => c._id == x._id)))
            {
                ListViewItem xitm = new ListViewItem(card.Name);
                xitm.SubItems.Add(card.Value.ToString());
                xitm.SubItems.Add(card.Type.ToString());
                xitm.SubItems.Add(card.Energy.ToString());
                xitm.SubItems.Add(card.Type == Global.CardType.Attack ? ((IActionable)card).ReturnEnergy.ToString() : "0");

                xitm.Tag = card;
                lstPlayerCards.Items.Add(xitm);
            }

            foreach (Card card in hero.CardDeck())
            {
                ListViewItem xitm = new ListViewItem(card.Name);
                xitm.SubItems.Add(card.Value.ToString());
                xitm.SubItems.Add(card.Type.ToString());
                xitm.SubItems.Add(card.Energy.ToString());
                xitm.SubItems.Add(card.Type == Global.CardType.Attack ? ((IActionable)card).ReturnEnergy.ToString() : "0");

                xitm.Tag = card;
                lstHeroCards.Items.Add(xitm);
            }
        }

        private void btnAddToHero_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lstPlayerCards.Items)
            {
                if (item.Checked)
                {
                    hero.AddCardtoDeck((Card)item.Tag);
                }
            }
            LoadLists();
        }

        private void btnRemoveFromHero_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lstHeroCards.Items)
            {
                if (item.Checked)
                {
                    hero.RemoveCardFromDeck((Card)item.Tag);
                }
            }
            LoadLists();
        }
    }
}
