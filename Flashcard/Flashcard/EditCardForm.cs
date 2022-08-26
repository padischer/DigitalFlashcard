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
    public partial class EditCardForm : Form
    {
        private bool _gerTextIsSet;
        private bool _engTextIsSet;
        private Card _cardToEdit;
        private Mode _currentMode;
        private AccessData accessData = new AccessData();
        private const string _basisText = "basis";
        private enum Mode
        {
            Add = 0,
            Edit = 1
        }
        public bool ShouldExecute { get; private set; }

        public EditCardForm()
        {
            InitializeComponent();
            _currentMode = Mode.Add;
        }

        public EditCardForm(Card cardToEdit)
        {
            InitializeComponent();
            _cardToEdit = cardToEdit;
            _currentMode = Mode.Edit;
        }

        private void AddCard_Load(object sender, EventArgs e)
        {
            _cbDifficulty.Items.Add(_basisText);
            _cbDifficulty.Items.Add(_basisText);
            _cbDifficulty.SelectedIndex = 0;

            if(_currentMode == Mode.Edit)
            {
                _txtEngWord.Text = _cardToEdit.GetEnglishWord();
                _txtGerWord.Text = _cardToEdit.GetGermanWord();
                _cbDifficulty.SelectedIndex = (int)_cardToEdit.Difficulty;
            }
        }

        public string GetGermanWord()
        {
            return _txtGerWord.Text;
        }

        public string GetEnglishWord()
        {
            return _txtEngWord.Text;
        }

        public string GetDifficulty()
        {
            return _cbDifficulty.SelectedItem.ToString();
        }
        

        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            if(_engTextIsSet && _gerTextIsSet)
            {
                if(_currentMode == Mode.Add)
                {
                    ShouldExecute = true;
                    this.Close();
                }
                else
                {
                    int difficultyNumber;
                    Fields cardData = new Fields();

                    if (_cbDifficulty.SelectedItem.ToString() == _basisText)
                    {
                        difficultyNumber = 0;
                    }
                    else
                    {
                        difficultyNumber = 1;
                    }

                    _cardToEdit.Update(_txtGerWord.Text, _txtEngWord.Text, (CardBox.Difficulties)difficultyNumber);
                    cardData.AddField("GermanWord", _txtGerWord.Text);
                    cardData.AddField("EnglishWord", _txtEngWord.Text);
                    cardData.AddField("Difficulty", difficultyNumber);
                    cardData.AddField("Slot", _cardToEdit.Slot);
                    accessData.UpdateCard(_txtGerWord.Text, _txtEngWord.Text, _cbDifficulty.SelectedItem.ToString(), _cardToEdit.ID);

                    this.Close();
                }
                
            }      
        }
        
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            ShouldExecute = false;
            this.Close();
        }
               
        private void ValidateGermanWord(object sender, EventArgs e)
        {
            _gerTextIsSet = ValidateTextBox(_txtGerWord, _errorProviderGer);
        }

        private void ValidateEnglishWord(object sender, EventArgs e)
        {
            _engTextIsSet = ValidateTextBox(_txtEngWord, _errorProviderEng);
        }

        private bool ValidateTextBox(TextBox textBox, ErrorProvider errorProv)
        {
            if (string.IsNullOrEmpty(textBox.Text) || string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Focus();
                errorProv.SetError(textBox, "Bitte geben sie etwas ein");
                return false;
            }
            else
            {
                errorProv.SetError(textBox, String.Empty) ;
                return true;
            }
        }
    }
}
