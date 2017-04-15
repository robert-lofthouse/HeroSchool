using HeroSchool;
using HeroSchool.Factory;
using HeroSchool.Interface;
using HeroSchool.Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HeroSchoolUI
{
    public partial class frmCards : Form
    {
        IRepository<ICard> _cardRepo;
        IList<ICard> cardList = new List<ICard>();

        public frmCards()
        {
            InitializeComponent();
        }

        public frmCards(IRepository<ICard> p_cardRepo)
        {
            InitializeComponent();
            _cardRepo = p_cardRepo;
        }

        private void frmAddNewCard_Load(object sender, EventArgs e)
        {
            LoadList();
        }

        private void LoadList()
        {
            lstCards.Items.Clear();
            cardList = _cardRepo.Get();
            foreach (ICard card in cardList)
            {
                ListViewItem xitm = new ListViewItem(card.Name);
                xitm.SubItems.Add(card.Value.ToString());
                xitm.SubItems.Add(card.Type.ToString());
                xitm.SubItems.Add(card.Energy.ToString());
                xitm.SubItems.Add(card.Type == Global.CardType.Attack ? ((IActionable)card).ReturnEnergy.ToString() : "0");

                lstCards.Items.Add(xitm);
            }
        }

        private void btnSaveCard_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtName.Text.Trim() == "")
                {
                    MessageBox.Show("Please enter a card Name", "Card Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtName.Focus();
                    return;
                }
                if (cboCardType.Text.Trim() == "")
                {
                    MessageBox.Show("Please select enter a card Type", "Card Type", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cboCardType.Focus();
                    return;
                }
                if (txtValue.Text.Trim() == "")
                {
                    MessageBox.Show("Please enter a card Value", "Card Value", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtValue.Focus();
                    return;
                }
                if (txtEnergy.Text.Trim() == "")
                {
                    MessageBox.Show("Please enter a card Energy", "Card Energy", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtEnergy.Focus();
                    return;
                }
                if (txtReturnEnergy.Text.Trim() == "")
                {
                    MessageBox.Show("Please enter a card Return Energy", "Card Return Energy", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtReturnEnergy.Focus();
                    return;
                }

                Global.CardType cardType;
                Enum.TryParse<Global.CardType>(cboCardType.Text.ToString(), out cardType);
                Card newCard = CardFactory.CreateCard(txtName.Text, int.Parse(txtValue.Text), int.Parse(txtEnergy.Text), cardType, cardType == Global.CardType.Attack ? int.Parse(txtReturnEnergy.Text) : 0);

                _cardRepo.Add(newCard);

                LoadList();

                txtName.Clear();
                txtValue.Clear();
                txtEnergy.Clear();
                txtReturnEnergy.Clear();
                cboCardType.SelectedIndex = -1;
                txtName.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
