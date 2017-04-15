using HeroSchool;
using HeroSchool.Interface;
using HeroSchool.Model;
using HeroSchool.Repository;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HeroSchoolUI
{
    public partial class frmBattle : Form
    {
        IList<Player> playerList1;
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
            Battles.Instance.RefreshBattleEvent += new EventHandler<EventArgs>(LoadHero);
            Battles.Instance.AttackEvent += delegate (object senderx, EventArgs ar) { Battles.Instance.RaiseBattleEvent(); btnDrawCards.Enabled = true; };
            Battles.Instance.VictoryEvent += new EventHandler<Battles.VictoryArgs>(SetVictor);

            LoadPlayerList();
        }

        private void LoadPlayerList()
        {
            cboPlayer1.DataSource = playerList1;
        }

        private void LoadBattleList()
        {
            cboBattles.Items.Clear();
            List<Battle> awaitingBattles = Battles.Instance.GetBattles(Global.BattleType.AwaitingHero);
            cboBattles.Items.Add("<New Battle>");

            foreach (var item in awaitingBattles)
            {
                cboBattles.Items.Add(item);
            }
        }

        private void cboPlayer1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboHero1.Text = "";
            cboHero1.DataSource = ((Player)cboPlayer1.SelectedItem).Heroes;

        }

        private void btnCreateBattle_Click(object sender, EventArgs e)
        {
            Hero _hero = (Hero)cboHero1.SelectedItem;

            switch (btnCreateBattle.Text)
            {
                case "Create Battle":
                    if (cboPlayer1.Text == "" || cboHero1.Text == "")
                    {
                        MessageBox.Show("Player and hero must be selected");
                    }

                    cboPlayer1.Enabled = false;
                    cboHero1.Enabled = false;

                    battle = Battles.Instance.AddBattle(_hero);


                    break;

                case "Join Battle":
                    if (cboPlayer1.Text == "" || cboHero1.Text == "")
                    {
                        MessageBox.Show("Player and hero must be selected");
                    }

                    cboPlayer1.Enabled = false;
                    cboHero1.Enabled = false;

                    battle = Battles.Instance.JoinBattle(((Battle)cboBattles.SelectedItem)._id, (Hero)cboHero1.SelectedItem);

                    break;
                case "Refresh Battle Status":


                    break;
                default:
                    break;
            }

            Battles.Instance.RaiseBattleEvent();
            btnCreateBattle.Text = "Refresh Battle Status";

        }

        private void cboBattles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboBattles.Text != "<New Battle>")
            {
                btnCreateBattle.Text = "Join Battle";
            }
            else
            {
                btnCreateBattle.Text = "Create Battle";
            }
        }

        private void cboHero1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadBattleList();
        }

        private void SetVictor(object sender, Battles.VictoryArgs e)
        {
            
            Hero _hero = (Hero)cboHero1.SelectedItem;
            if (e.Victor == _hero)
            {
                lblResult.Text = "Winner";
                lblResult.BackColor = System.Drawing.Color.Green;
            }
            else
            {
                lblResult.Text = "Loser";
                lblResult.BackColor = System.Drawing.Color.Red;
            }

            lblResult.Visible = true;
        }

        private void LoadHero(object sender, EventArgs e)
        {
            Hero _hero = (Hero)cboHero1.SelectedItem;
            txtHeroName.Text = _hero.Name;
            txtHeroHealth.Text = _hero.Value.ToString();
            txtHeroEnergy.Text = _hero.Energy.ToString();

            txtCardDeck.Text = string.Format("Attack Cards:{0}, Defense Cards:{1}, Modifier Cards:{2}", _hero.AttackCardDeck.Count, _hero.DefenseCardDeck.Count, _hero.ModifierCardDeck.Count);

            lstDrawnCards.Items.Clear();
            lstPlayedCards.Items.Clear();

            foreach (var item in _hero.PlayableCards)
            {
                var xitm = lstDrawnCards.Items.Add(item.Name);
                xitm.SubItems.Add(item.Value.ToString());
                xitm.SubItems.Add(item.Type.ToString());
                xitm.SubItems.Add(item.Energy.ToString());
                xitm.SubItems.Add(item.Type == Global.CardType.Attack ? ((IActionable)item).ReturnEnergy.ToString() : "0");

                xitm.Tag = item;
            }

            foreach (var item in _hero.PlayedCards)
            {
                var xitm = lstPlayedCards.Items.Add(item.Name);
                xitm.SubItems.Add(item.Value.ToString());
                xitm.SubItems.Add(item.Type.ToString());
                xitm.SubItems.Add(item.Energy.ToString());
                xitm.SubItems.Add(item.Type == Global.CardType.Attack ? ((IActionable)item).ReturnEnergy.ToString() : "0");

                xitm.Tag = item;
            }

            if (battle != null && battle.Type == Global.BattleType.Active)
            {
                grpHero.BackColor = battle.AttackingHero == _hero ? System.Drawing.Color.Green : System.Drawing.Color.Blue;
                btnDoAttack.Enabled = battle.AttackingHero == _hero ? true : false;
            }

        }

        private void btnDrawCards_Click(object sender, EventArgs e)
        {
            Hero _hero = (Hero)cboHero1.SelectedItem;

            _hero.DrawCards(3);

            btnDrawCards.Enabled = false;

            Battles.Instance.RaiseBattleEvent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnPlayCards_Click(object sender, EventArgs e)
        {
            Hero _hero = (Hero)cboHero1.SelectedItem;
            foreach (ListViewItem item in lstDrawnCards.Items)
            {
                if (item.Checked)
                {
                    if (item.Tag is IActionable)
                        _hero.PlayCard((ActionCard)item.Tag);
                }
            }

            Battles.Instance.RaiseBattleEvent();
        }

        private void btnDoAttack_Click(object sender, EventArgs e)
        {
            Hero _hero = (Hero)cboHero1.SelectedItem;

            Global.AttackResult atkres = battle.DoAttack();
            Battles.Instance.RaiseAttackEvent();
            if (atkres == Global.AttackResult.AttackSuccededDamagedAndKilled)
                Battles.Instance.RaiseVictoryEvent(_hero);
        }

    }
}
