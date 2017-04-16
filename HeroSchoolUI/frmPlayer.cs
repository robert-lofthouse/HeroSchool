using HeroSchool;
using HeroSchool.Interface;
using HeroSchool.Model;
using HeroSchool.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace HeroSchoolUI
{
    public partial class frmPlayer : Form
    {
        public Player player;
        IRepository<ICard> _cardRepo;
        frmHero _frmHero;

        public frmPlayer()
        {
            InitializeComponent();
        }

        public frmPlayer(IRepository<ICard> p_cradrepo, frmHero p_frmhero)
        {
            InitializeComponent();
            _cardRepo = p_cradrepo;
            _frmHero = p_frmhero;
        }

        private void frmPlayerCards_Load(object sender, EventArgs e)
        {
            LoadCardLists();
            LoadHeroList();
            txtPlayerName.Text = player.Name;
        }

        private void LoadCardLists()
        {
            lstPlayerCards.Items.Clear();
            lstCards.Items.Clear();

            IList<ICard> cardlist = _cardRepo.Get();

            foreach (Card card in cardlist.Where(x => !player.CardCollection().Any(c => c._id == x._id)))
            {
                ListViewItem xitm = new ListViewItem(card.Name);
                xitm.SubItems.Add(card.Value.ToString());
                xitm.SubItems.Add(card.Type.ToString());
                xitm.SubItems.Add(card.Energy.ToString());
                xitm.SubItems.Add(card.Type == Global.CardType.Attack ? ((IActionable)card).ReturnEnergy.ToString() : "0");

                xitm.Tag = card;
                lstCards.Items.Add(xitm);
            }

            foreach (Card card in player.CardCollection())
            {
                ListViewItem xitm = new ListViewItem(card.Name);
                xitm.SubItems.Add(card.Value.ToString());
                xitm.SubItems.Add(card.Type.ToString());
                xitm.SubItems.Add(card.Energy.ToString());
                xitm.SubItems.Add(card.Type == Global.CardType.Attack ? ((IActionable)card).ReturnEnergy.ToString() : "0");

                xitm.Tag = card;
                lstPlayerCards.Items.Add(xitm);
            }


        }

        private void lstCards_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void LoadHeroList()
        {
            lstHeroes.Items.Clear();

            foreach (Hero hero in player.Heroes)
            {
                ListViewItem xitm = new ListViewItem(hero.Name);
                xitm.SubItems.Add(hero.Value.ToString());
                xitm.SubItems.Add(hero.Energy.ToString());

                hero.SetPlayer(player);
                xitm.Tag = hero;
                lstHeroes.Items.Add(xitm);
            }
        }

        private void btnSaveHero_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtName.Text.Trim() == "")
                {
                    MessageBox.Show("Please enter a Hero Name", "Hero Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtName.Focus();
                    return;
                }
                if (txtValue.Text.Trim() == "")
                {
                    MessageBox.Show("Please enter a Hero Value", "Hero Value", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtValue.Focus();
                    return;
                }
                if (txtEnergy.Text.Trim() == "")
                {
                    MessageBox.Show("Please enter a Hero Energy", "Hero Energy", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtEnergy.Focus();
                    return;
                }

                Hero newHero = new Hero(txtName.Text, int.Parse(txtValue.Text), int.Parse(txtEnergy.Text),  new HeroArcheType(20, Global.HeroClass.Strength));
                newHero.SetPlayer(player);
                player.AddHero(newHero);


                LoadHeroList();

                txtName.Clear();
                txtValue.Clear();
                txtEnergy.Clear();
                txtName.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnRemoveFromPlayer_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lstPlayerCards.Items)
            {
                if (item.Checked)
                {
                    player.RemoveCardFromCollection((Card)item.Tag);
                }
            }
            LoadCardLists();
        }

        private void btnAddToPlayer_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lstCards.Items)
            {
                if(item.Checked)
                {
                    switch (((Card)item.Tag).Type)
                    {
                        case Global.CardType.Attack:
                            player.AddCardtoCollection((ActionCard)item.Tag);
                            break;
                        case Global.CardType.Defense:
                            player.AddCardtoCollection((DefenseCard)item.Tag);
                            break;
                        case Global.CardType.Modifier:
                            player.AddCardtoCollection((ModifierCard)item.Tag);
                            break;
                    }    

                }
            }
            LoadCardLists();
        }

        private void lstHeroes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lstHeroes_DoubleClick(object sender, EventArgs e)
        {
            var hero = (Hero)lstHeroes.SelectedItems[0].Tag;

            _frmHero.player = player;
            _frmHero.hero = hero;
            _frmHero.ShowDialog();

        }
    }
}
