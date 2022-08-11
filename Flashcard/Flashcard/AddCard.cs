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
        private bool _gerTextIsSet = false;
        private bool _engTextIsSet = false;

        public AddCard(MainForm form)
        {
            OriginalForm = form;
            InitializeComponent();
        }

        public bool ShouldExecute { get; set; }


        public string GetGermanWord()
        {
            return _txtGerWord.Text;
        }

        public string GetEnglishWord()
        {
            return _txtEngWord.Text;
        }


        public MainForm OriginalForm { get; set; }

        public void BtnSubmit_Click(object sender, EventArgs e)
        {

             ShouldExecute = true;
             this.Close();
             OriginalForm.Show();          
        }
        
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            ShouldExecute = false;
            this.Close();
            OriginalForm.Show();
        }
        /*
        private void ValidateGermanWord(object sender, EventArgs e)
        {
            ValidateTextBox(_txtGerWord, _errorProviderGer, _gerTextIsSet);
        }

        private void ValidateEnglishWord(object sender, EventArgs e)
        {
            ValidateTextBox(_txtEngWord, _errorProviderEng, _engTextIsSet);
        }

        private void ValidateTextBox(TextBox textBox, ErrorProvider errorProv, bool textIsSet)
        {
            if (string.IsNullOrEmpty(textBox.Text) || string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Focus();
                errorProv.SetError(textBox, "Bitte geben sie ein deutsches Wort an");
                textIsSet = false;
            }
            else
            {
                errorProv.SetError(textBox, "");
                textIsSet = true;
            }
        }
        */

        
    }
}
