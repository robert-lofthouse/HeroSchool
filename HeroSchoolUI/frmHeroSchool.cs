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
    public partial class frmHeroSchool : Form
    {
        public frmHeroSchool()
        {
            InitializeComponent();
        }

        private void btnCards_click(object sender, EventArgs e)
        {
            frmCards frmcards = new frmCards();
            frmcards.ShowDialog();
        }

        private void btnPlayers_Click(object sender, EventArgs e)
        {
            frmPlayers frmplayers = new frmPlayers();
            frmplayers.ShowDialog();

        }
    }
}
