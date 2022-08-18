namespace Flashcard
{
    partial class EditCard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._cbDifficulty = new System.Windows.Forms.ComboBox();
            this._lblDifficulty = new System.Windows.Forms.Label();
            this._txtEngWord = new System.Windows.Forms.TextBox();
            this._txtGerWord = new System.Windows.Forms.TextBox();
            this._lblEngWord = new System.Windows.Forms.Label();
            this._lblGerWord = new System.Windows.Forms.Label();
            this._btnCancel = new System.Windows.Forms.Button();
            this._btnSubmit = new System.Windows.Forms.Button();
            this._lblEditCard = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _cbDifficulty
            // 
            this._cbDifficulty.FormattingEnabled = true;
            this._cbDifficulty.Location = new System.Drawing.Point(318, 226);
            this._cbDifficulty.Name = "_cbDifficulty";
            this._cbDifficulty.Size = new System.Drawing.Size(100, 23);
            this._cbDifficulty.TabIndex = 17;
            // 
            // _lblDifficulty
            // 
            this._lblDifficulty.AutoSize = true;
            this._lblDifficulty.Location = new System.Drawing.Point(239, 229);
            this._lblDifficulty.Name = "_lblDifficulty";
            this._lblDifficulty.Size = new System.Drawing.Size(44, 15);
            this._lblDifficulty.TabIndex = 16;
            this._lblDifficulty.Text = "Modus";
            // 
            // _txtEngWord
            // 
            this._txtEngWord.Location = new System.Drawing.Point(318, 191);
            this._txtEngWord.Name = "_txtEngWord";
            this._txtEngWord.Size = new System.Drawing.Size(100, 23);
            this._txtEngWord.TabIndex = 15;
            // 
            // _txtGerWord
            // 
            this._txtGerWord.Location = new System.Drawing.Point(318, 157);
            this._txtGerWord.Name = "_txtGerWord";
            this._txtGerWord.Size = new System.Drawing.Size(100, 23);
            this._txtGerWord.TabIndex = 14;
            // 
            // _lblEngWord
            // 
            this._lblEngWord.AutoSize = true;
            this._lblEngWord.Location = new System.Drawing.Point(214, 194);
            this._lblEngWord.Name = "_lblEngWord";
            this._lblEngWord.Size = new System.Drawing.Size(91, 15);
            this._lblEngWord.TabIndex = 13;
            this._lblEngWord.Text = "englisches Wort";
            // 
            // _lblGerWord
            // 
            this._lblGerWord.AutoSize = true;
            this._lblGerWord.Location = new System.Drawing.Point(216, 160);
            this._lblGerWord.Name = "_lblGerWord";
            this._lblGerWord.Size = new System.Drawing.Size(89, 15);
            this._lblGerWord.TabIndex = 12;
            this._lblGerWord.Text = "deutsches Wort";
            // 
            // _btnCancel
            // 
            this._btnCancel.Location = new System.Drawing.Point(318, 275);
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.Size = new System.Drawing.Size(75, 23);
            this._btnCancel.TabIndex = 11;
            this._btnCancel.Text = "Abbrechen";
            this._btnCancel.UseVisualStyleBackColor = true;
            this._btnCancel.Click += new System.EventHandler(this._btnCancel_Click);
            // 
            // _btnSubmit
            // 
            this._btnSubmit.Location = new System.Drawing.Point(230, 275);
            this._btnSubmit.Name = "_btnSubmit";
            this._btnSubmit.Size = new System.Drawing.Size(75, 23);
            this._btnSubmit.TabIndex = 10;
            this._btnSubmit.Text = "Bestätigen";
            this._btnSubmit.UseVisualStyleBackColor = true;
            this._btnSubmit.Click += new System.EventHandler(this._btnSubmit_Click);
            // 
            // _lblEditCard
            // 
            this._lblEditCard.AutoSize = true;
            this._lblEditCard.Location = new System.Drawing.Point(252, 106);
            this._lblEditCard.Name = "_lblEditCard";
            this._lblEditCard.Size = new System.Drawing.Size(93, 15);
            this._lblEditCard.TabIndex = 9;
            this._lblEditCard.Text = "Karte bearbeiten";
            // 
            // EditCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 421);
            this.Controls.Add(this._cbDifficulty);
            this.Controls.Add(this._lblDifficulty);
            this.Controls.Add(this._txtEngWord);
            this.Controls.Add(this._txtGerWord);
            this.Controls.Add(this._lblEngWord);
            this.Controls.Add(this._lblGerWord);
            this.Controls.Add(this._btnCancel);
            this.Controls.Add(this._btnSubmit);
            this.Controls.Add(this._lblEditCard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "EditCard";
            this.Text = "EditCard";
            this.Load += new System.EventHandler(this.EditCard_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComboBox _cbDifficulty;
        private Label _lblDifficulty;
        private TextBox _txtEngWord;
        private TextBox _txtGerWord;
        private Label _lblEngWord;
        private Label _lblGerWord;
        private Button _btnCancel;
        private Button _btnSubmit;
        private Label _lblEditCard;
    }
}