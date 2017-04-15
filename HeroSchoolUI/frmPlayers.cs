using HeroSchool.Interface;
using HeroSchool.Model;
using HeroSchool.Repository;
using System;
using System.Windows.Forms;

namespace HeroSchoolUI
{
    public partial class frmPlayers : Form
    {
        private Repository<Player> _playerRepo;
        private IRepository<ICard> _cardRepo;
        private frmPlayer _frmplayer;

        public frmPlayers()
        {
            InitializeComponent();
        }

        public frmPlayers(Repository<Player> p_playerRepo, IRepository<ICard> p_cardRepo, frmPlayer p_frmplayer)
        {
            InitializeComponent();
            _playerRepo = p_playerRepo;
            _cardRepo = p_cardRepo;
            _frmplayer= p_frmplayer;
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

                Player newPlayer = new Player(txtName.Text);
                newPlayer.SetCardRepository(_cardRepo);

                _playerRepo.Add(newPlayer);

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

            foreach (Player player in _playerRepo.Get())
            {
                ListViewItem xitm = new ListViewItem(player.Name);
                player.SetCardRepository(_cardRepo);
                xitm.Tag = player;
                lstPlayers.Items.Add(xitm);
            }
        }

        private void lstPlayers_DoubleClick(object sender, EventArgs e)
        {

            var player = (Player)lstPlayers.SelectedItems[0].Tag;

            _frmplayer.player = player;
            _frmplayer.ShowDialog();

            _playerRepo.Update(player);
        }

        private void lstPlayers_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
