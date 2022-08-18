using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AirtableApiClient;

namespace Flashcard
{
    public partial class WSBD : Form
    {
        private AccessData accessData = new AccessData();
        public Card CardToEdit { get; private set; }

        public WSBD(Card card)
        {
            InitializeComponent();
            CardToEdit = card;
        }

        private void EditCard_Load(object sender, EventArgs e)
        {
            _cbDifficulty.Items.Add("basis");
            _cbDifficulty.Items.Add("erweitert");
            _cbDifficulty.SelectedIndex = 0;

            _txtEngWord.Text = CardToEdit.GetEnglishWord();
            _txtGerWord.Text = CardToEdit.GetGermanWord();
            _cbDifficulty.SelectedIndex = (int)CardToEdit.Difficulty;
        }

        private void _btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _btnSubmit_Click(object sender, EventArgs e)
        {
            int difficultyNumber;
            Fields cardData = new Fields();

            if (_cbDifficulty.SelectedItem.ToString() == "basis")
            {
                difficultyNumber = 0;
            }
            else
            {
                difficultyNumber = 1;
            }

            CardToEdit.Update(_txtGerWord.Text, _txtEngWord.Text, (CardBox.Difficulties)difficultyNumber);
            var diff = CardToEdit.Difficulty;
            cardData.AddField("GermanWord", _txtGerWord.Text);
            cardData.AddField("EnglishWord", _txtEngWord.Text);
            cardData.AddField("Difficulty", difficultyNumber);
            cardData.AddField("Slot", CardToEdit.SlotID);
            accessData.UpdateCard(cardData, CardToEdit.ID);

            this.Close();
        }

        
    }
}
