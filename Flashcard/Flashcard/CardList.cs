using System;
using System.Collections.Generic;
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

            //Add column header
            _lvCardList.Columns.Add("Deutsch", 100);
            _lvCardList.Columns.Add("Englisch", 100);
            _lvCardList.Columns.Add("Schwierigkeit", 100);

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
                
                if(card.PrimaryLanguage == CardBox.Languages.German)
                {
                    item.Text = card.WordToTranslate;
                    item.SubItems.Add(card.Translation);
                }
                else
                {
                    item.Text = card.Translation;
                    item.SubItems.Add(card.WordToTranslate);
                }

                item.SubItems.Add(difficulty);
                _lvCardList.Items.Add(item);
            }
        }
    }
}
