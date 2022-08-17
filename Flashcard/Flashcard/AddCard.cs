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
    public partial class AddCard : Form
    {
        private bool _gerTextIsSet;
        private bool _engTextIsSet;
        private MainForm _originalForm;
        public bool ShouldExecute { get; private set; }
        
        public AddCard(MainForm form)
        {
            _originalForm = form;
            InitializeComponent();
        }

        private void AddCard_Load(object sender, EventArgs e)
        {
            _cbDifficulty.Items.Add("basis");
            _cbDifficulty.Items.Add("erweitert");
            _cbDifficulty.SelectedIndex = 0;
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
                ShouldExecute = true;
                this.Close();
                _originalForm.Show();
            }      
        }
        
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            ShouldExecute = false;
            this.Close();
            _originalForm.Show();
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
                errorProv.SetError(textBox, "");
                return true;
            }
        }
    }
}
