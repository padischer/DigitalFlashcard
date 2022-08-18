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
        private List<Card> _cardList;

        public CardList(List<Card> list)
        {
            InitializeComponent();
            _cardList = list;
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

            _lvCardList.Columns.Add("Deutsch", _lvCardList.ClientSize.Width/3);
            _lvCardList.Columns.Add("Englisch", _lvCardList.ClientSize.Width / 3);
            _lvCardList.Columns.Add("Schwierigkeit", _lvCardList.ClientSize.Width / 3);

            foreach (Card card in _cardList)
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
                item.Text = card.GetEnglishWord();
                item.SubItems.Add(card.GetGermanWord());

                item.SubItems.Add(difficulty);
                _lvCardList.Items.Add(item);
            }
        }

        private void LvCardList_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            _lvCardList.Sorting = SortOrder.Descending;           
        }
    }
}
