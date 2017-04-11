using HeroSchool;
using HeroSchool.Interface;
using HeroSchool.Model;
using System;
using System.Windows.Forms;

namespace HeroSchoolUI
{
    public partial class frmHeroes : Form
    {
        public Player player;
        IRepository<ICard> _cardRepo;

        public frmHeroes()
        {
            InitializeComponent();
        }

        public frmHeroes(IRepository<ICard> p_cardRepo)
        {
            InitializeComponent();
            _cardRepo = p_cardRepo;

        }

        private void frmHeroes_Load(object sender, EventArgs e)
        {
            txtPlayerName.Text = player.Name;
            LoadList();
        }

        private void LoadList()
        {
            lstHeroes.Items.Clear();
            
            foreach (Hero hero in player.Heroes)
            {
                ListViewItem xitm = new ListViewItem(hero.Name);
                xitm.SubItems.Add(hero.Value.ToString());
                xitm.SubItems.Add(hero.Energy.ToString());
                
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

                Hero newHero = new Hero(txtName.Text, int.Parse(txtValue.Text), int.Parse(txtEnergy.Text),player,new HeroArchetype(20,Global.HeroClass.Strength),_cardRepo);
                player.AddHero(newHero);
                

                LoadList();

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
    }
}
