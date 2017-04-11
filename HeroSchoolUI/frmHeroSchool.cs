using HeroSchool;
using HeroSchool.Interface;
using HeroSchool.Model;
using HeroSchool.Repository;
using Microsoft.Practices.Unity;
using System;
using System.Windows.Forms;

namespace HeroSchoolUI
{
    public partial class frmHeroSchool : Form
    {

        frmPlayers frmplayers;
        frmCards frmcards;

        public frmHeroSchool()
        {
            InitializeComponent();
        }

        public frmHeroSchool(frmCards p_frmcards, frmPlayers p_frmplayers)
        {
            InitializeComponent();
            frmplayers = p_frmplayers;
            frmcards = p_frmcards;
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
    }
}


