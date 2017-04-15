using HeroSchool;
using HeroSchool.Interface;
using HeroSchool.Model;
using HeroSchool.Repository;
using Microsoft.Practices.Unity;
using System;
using System.Threading;
using System.Windows.Forms;

namespace HeroSchoolUI
{
    public partial class frmHeroSchool : Form
    {

        frmPlayers frmplayers;
        frmCards frmcards;
        Repository<Player> _playerRepo;

        public frmHeroSchool()
        {
            InitializeComponent();
        }


        public frmHeroSchool(frmCards p_frmcards, frmPlayers p_frmplayers, Repository<Player> p_playerrepo)
        {
            InitializeComponent();
            frmplayers = p_frmplayers;
            frmcards = p_frmcards;
            _playerRepo = p_playerrepo;
        }

        private void btnCards_click(object sender, EventArgs e)
        {
            frmcards.ShowDialog();
        }

        private void btnPlayers_Click(object sender, EventArgs e)
        {
            frmplayers.ShowDialog();

        }

        private void frmHeroSchool_Load(object sender, EventArgs e)
        {

        }

        private void btnBattle_Click(object sender, EventArgs e)
        {
            frmBattle frmbattle = new frmBattle(_playerRepo);
            Battles.Instance.AddBattleForm(frmbattle);
            frmbattle.Show();
        }
    }
}


