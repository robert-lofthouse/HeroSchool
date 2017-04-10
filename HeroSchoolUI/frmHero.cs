using HeroSchool;
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

        public frmHero()
        {
            InitializeComponent();
        }

        private void frmHero_Load(object sender, EventArgs e)
        {

        }

        private void LoadList()
        {
            lstHeroes.Items.Clear();
            cardList = Globals.cardRepo.Get();
            foreach (ICard card in cardList)
            {
                ListViewItem xitm = new ListViewItem(card.Name);
                xitm.SubItems.Add(card.Value.ToString());
                xitm.SubItems.Add(card.Type.ToString());
                xitm.SubItems.Add(card.Energy.ToString());
                xitm.SubItems.Add(card.Type == Global.CardType.Attack ? ((IActionable)card).ReturnEnergy.ToString() : "0");

                lstHeroes.Items.Add(xitm);
            }
        }
    }
}
