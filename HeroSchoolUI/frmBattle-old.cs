using HeroSchool.Model;
using HeroSchool.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeroSchoolUI.OldForm

{
    public partial class frmBattle : Form
    {
        IList<Player> playerList1;
        IList<Player> playerList2;
        Repository<Player> _playerRepo;

        Battle battle;

        public frmBattle()
        {
            InitializeComponent();
        }

        public frmBattle(Repository<Player> p_playerrepo)
        {
            InitializeComponent();
            _playerRepo = p_playerrepo;

        }

        private void frmBattle_Load(object sender, EventArgs e)
        {
            playerList1 = _playerRepo.Get();
            playerList2 = _playerRepo.Get();

            LoadLists();
        }

        private void LoadLists()
        {

            cboPlayer1.DataSource = playerList1;
            cboPlayer2.DataSource = playerList2;

        }

        private void cboPlayer1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboHero1.Text = "";
            cboHero1.DataSource = ((Player)cboPlayer1.SelectedItem).Heroes;
            
        }

        private void cboPlayer2_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboHero2.Text = "";
            cboHero2.DataSource = ((Player)cboPlayer2.SelectedItem).Heroes;
                        
        }

        private void btnCreateBattle_Click(object sender, EventArgs e)
        {
            if (cboPlayer1.Text == cboPlayer2.Text)
            {
                MessageBox.Show("Player 1 and Player 2 must be different");
            }
            else
            {

                cboPlayer1.Enabled = false;
                cboPlayer2.Enabled = false;
                cboHero1.Enabled = false;
                cboHero2.Enabled = false;

                grpHero1.Text = cboHero1.Text;
                grpHero2.Text = cboHero2.Text;

                battle = Battles.GetInstance.AddBattle((Hero)cboHero1.SelectedItem, (Hero)cboHero2.SelectedItem);

                SetGroupColours();
            }

        }

        private void SetGroupColours()
        {
            if (battle.AttackingHero.ToString() == cboHero1.Text)
            {
                grpHero1.ForeColor = Color.Red;
                grpHero2.ForeColor = Color.Blue;
            }
            else
            {
                grpHero2.ForeColor = Color.Red;
                grpHero1.ForeColor = Color.Blue;

            }

        }
    }
}
