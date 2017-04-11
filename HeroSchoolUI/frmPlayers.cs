using HeroSchool;
using HeroSchool.Interface;
using Microsoft.Practices.Unity;
using HeroSchool.Repository;
using System;
using System.Windows.Forms;

namespace HeroSchoolUI
{
    public partial class frmPlayers : Form
    {
        private Repository<Player> _playerRepo;
        private IRepository<ICard> _cardRepo;
        private frmHeroes _frmheroes;

        public frmPlayers()
        {
            InitializeComponent();
        }

        public frmPlayers(Repository<Player> p_playerRepo, IRepository<ICard> p_cardRepo, frmHeroes p_frmheroes)
        {
            InitializeComponent();
            _playerRepo = p_playerRepo;
            _cardRepo = p_cardRepo;
            _frmheroes = p_frmheroes;
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

                IPlayer newPlayer = new Player(txtName.Text, _cardRepo);

                _playerRepo.Add((Player)newPlayer);

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
            foreach (Player player in _playerRepo.Get())
            {
                ListViewItem xitm = new ListViewItem(player.Name);

                xitm.Tag = player;
                lstPlayers.Items.Add(xitm);
            }
        }

        private void lstPlayers_DoubleClick(object sender, EventArgs e)
        {

            var player = (Player)lstPlayers.SelectedItems[0].Tag;

            _frmheroes.player = player;
            _frmheroes.ShowDialog();
            _playerRepo.Update(player);
        }

        private void lstPlayers_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
