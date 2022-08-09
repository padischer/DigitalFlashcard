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
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                
            }
            else
            {
                ShouldExecute = false;
                this.Close();
                OriginalForm.Show();
            }
            
        }
        
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            ShouldExecute = true;
            this.Close();
            OriginalForm.Show();
        }

        private void ValidateGermanWord(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_txtGerWord.Text))
            {
                _txtGerWord.Focus();
                _errorProviderGer.SetError(_txtGerWord, "Name should not be left blank!");
                _btnSubmit.Enabled = false;
            }
            else
            {
                _errorProviderGer.SetError(_txtGerWord, "");
                _btnSubmit.Enabled=true;
            }
        }
    }
}
