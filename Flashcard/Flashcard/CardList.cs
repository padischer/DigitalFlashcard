using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Flashcard
{
    public partial class CardList : Form
    {
        public List<Card> ListOfCards { get; private set; }
        private AccessData _accessData = new AccessData();
        public CardList(List<Card> list)
        {
            InitializeComponent();
            ListOfCards = list;
        }

        private void BtnCancel_OnClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CardList_Load(object sender, EventArgs e)
        {
            _lvCardList.View = View.Details;
            _lvCardList.GridLines = true;
            _lvCardList.FullRowSelect = true;

            FillListView();
        }


        private Card GetSelectedCard()
        {
            int selectedID = Int32.Parse(_lvCardList.SelectedItems[0].Text);
            return ListOfCards.ElementAt(selectedID - 1);
        }
        private void BtnEdit_OnClick(object sender, EventArgs e)
        {
            if(_lvCardList.SelectedItems.Count == 1)
            {
                EditCard editCard = new EditCard(GetSelectedCard());
                editCard.ShowDialog();
            }
            FillListView();
        }

        private void BtnDelete_OnClick(object sender, EventArgs e)
        {
            if(_lvCardList.SelectedItems.Count == 1)
            {
                _accessData.DeleteCard(GetSelectedCard().ID);
                ListOfCards.Remove(GetSelectedCard());
                FillListView();
            }    
        }

        private void FillListView()
        {
            _lvCardList.Clear();

            _lvCardList.Columns.Add("Nr.", _lvCardList.ClientSize.Width / 10);
            _lvCardList.Columns.Add("Deutsch", _lvCardList.ClientSize.Width / 3);
            _lvCardList.Columns.Add("Englisch", _lvCardList.ClientSize.Width / 3);
            _lvCardList.Columns.Add("Schwierigkeit", _lvCardList.ClientSize.Width / 5);

            int count = 1;

            foreach (Card card in ListOfCards)
            {
                string difficulty = string.Empty;
                if (card.Difficulty == 0)
                {
                    difficulty = "basis";
                }
                else
                {
                    difficulty = "erweitert";
                }

                ListViewItem item = new ListViewItem();
                item.Text = count.ToString();
                item.SubItems.Add(card.GetEnglishWord());
                item.SubItems.Add(card.GetGermanWord());
                item.SubItems.Add(difficulty);

                _lvCardList.Items.Add(item);
                count++;
            }
        }
    }
}
