using HeroSchool;
using HeroSchool.Factories;
using HeroSchool.Interfaces;
using HeroSchool.Repositories;
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
    public partial class frmPlayers : Form
    {
        IList<Player> playerList = new List<Player>();

        public frmPlayers()
        {
            InitializeComponent();
        }

        private void btnSavePlayer_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtName.Text.Trim() == "")
                {
                    MessageBox.Show("Please enter a Player Name", "Player Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtName.Focus();
                    return;
                }

                IPlayer newCard = PlayerFactory.CreatePlayer(txtName.Text, Globals.cardRepo);

                Globals.playerRepo.Add((Player)newCard);

                LoadList();

                txtName.Clear();
                txtName.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void frmPlayers_Load(object sender, EventArgs e)
        {
            LoadList();
        }
        private void LoadList()
        {
            lstPlayers.Items.Clear();
            playerList = Globals.playerRepo.Get();
            foreach (IPlayer player in playerList)
            {
                ListViewItem xitm = new ListViewItem(player.Name);
                lstPlayers.Items.Add(xitm);
            }
        }
    }
}
