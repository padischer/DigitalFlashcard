namespace Flashcard
{
    partial class AddCard
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
            this.components = new System.ComponentModel.Container();
            this._lblNewCard = new System.Windows.Forms.Label();
            this._btnSubmit = new System.Windows.Forms.Button();
            this._btnCancel = new System.Windows.Forms.Button();
            this._lblGerWord = new System.Windows.Forms.Label();
            this._lblEngWord = new System.Windows.Forms.Label();
            this._txtGerWord = new System.Windows.Forms.TextBox();
            this._txtEngWord = new System.Windows.Forms.TextBox();
            this._errorProviderGer = new System.Windows.Forms.ErrorProvider(this.components);
            this._errorProviderEng = new System.Windows.Forms.ErrorProvider(this.components);
            this._lblDifficulty = new System.Windows.Forms.Label();
            this._cbDifficulty = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this._errorProviderGer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._errorProviderEng)).BeginInit();
            this.SuspendLayout();
            // 
            // _lblNewCard
            // 
            this._lblNewCard.AutoSize = true;
            this._lblNewCard.Location = new System.Drawing.Point(184, 57);
            this._lblNewCard.Name = "_lblNewCard";
            this._lblNewCard.Size = new System.Drawing.Size(130, 15);
            this._lblNewCard.TabIndex = 0;
            this._lblNewCard.Text = "Neue Karte Hinzufügen";
            // 
            // _btnSubmit
            // 
            this._btnSubmit.Location = new System.Drawing.Point(162, 226);
            this._btnSubmit.Name = "_btnSubmit";
            this._btnSubmit.Size = new System.Drawing.Size(75, 23);
            this._btnSubmit.TabIndex = 1;
            this._btnSubmit.Text = "Bestätigen";
            this._btnSubmit.UseVisualStyleBackColor = true;
            this._btnSubmit.Click += new System.EventHandler(this.BtnSubmit_Click);
            // 
            // _btnCancel
            // 
            this._btnCancel.Location = new System.Drawing.Point(250, 226);
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.Size = new System.Drawing.Size(75, 23);
            this._btnCancel.TabIndex = 2;
            this._btnCancel.Text = "Abbrechen";
            this._btnCancel.UseVisualStyleBackColor = true;
            this._btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // _lblGerWord
            // 
            this._lblGerWord.AutoSize = true;
            this._lblGerWord.Location = new System.Drawing.Point(148, 111);
            this._lblGerWord.Name = "_lblGerWord";
            this._lblGerWord.Size = new System.Drawing.Size(89, 15);
            this._lblGerWord.TabIndex = 3;
            this._lblGerWord.Text = "deutsches Wort";
            // 
            // _lblEngWord
            // 
            this._lblEngWord.AutoSize = true;
            this._lblEngWord.Location = new System.Drawing.Point(146, 145);
            this._lblEngWord.Name = "_lblEngWord";
            this._lblEngWord.Size = new System.Drawing.Size(91, 15);
            this._lblEngWord.TabIndex = 4;
            this._lblEngWord.Text = "englisches Wort";
            // 
            // _txtGerWord
            // 
            this._txtGerWord.Location = new System.Drawing.Point(250, 108);
            this._txtGerWord.Name = "_txtGerWord";
            this._txtGerWord.Size = new System.Drawing.Size(100, 23);
            this._txtGerWord.TabIndex = 5;
            this._txtGerWord.TextChanged += new System.EventHandler(this.ValidateGermanWord);
            // 
            // _txtEngWord
            // 
            this._txtEngWord.Location = new System.Drawing.Point(250, 142);
            this._txtEngWord.Name = "_txtEngWord";
            this._txtEngWord.Size = new System.Drawing.Size(100, 23);
            this._txtEngWord.TabIndex = 6;
            this._txtEngWord.TextChanged += new System.EventHandler(this.ValidateEnglishWord);
            // 
            // _errorProviderGer
            // 
            this._errorProviderGer.ContainerControl = this;
            // 
            // _errorProviderEng
            // 
            this._errorProviderEng.ContainerControl = this;
            // 
            // _lblDifficulty
            // 
            this._lblDifficulty.AutoSize = true;
            this._lblDifficulty.Location = new System.Drawing.Point(171, 180);
            this._lblDifficulty.Name = "_lblDifficulty";
            this._lblDifficulty.Size = new System.Drawing.Size(44, 15);
            this._lblDifficulty.TabIndex = 7;
            this._lblDifficulty.Text = "Modus";
            // 
            // _cbDifficulty
            // 
            this._cbDifficulty.FormattingEnabled = true;
            this._cbDifficulty.Location = new System.Drawing.Point(250, 177);
            this._cbDifficulty.Name = "_cbDifficulty";
            this._cbDifficulty.Size = new System.Drawing.Size(100, 23);
            this._cbDifficulty.TabIndex = 8;
            // 
            // AddCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 332);
            this.Controls.Add(this._cbDifficulty);
            this.Controls.Add(this._lblDifficulty);
            this.Controls.Add(this._txtEngWord);
            this.Controls.Add(this._txtGerWord);
            this.Controls.Add(this._lblEngWord);
            this.Controls.Add(this._lblGerWord);
            this.Controls.Add(this._btnCancel);
            this.Controls.Add(this._btnSubmit);
            this.Controls.Add(this._lblNewCard);
            this.Name = "AddCard";
            this.Text = "AddCard";
            this.Load += new System.EventHandler(this.AddCard_Load);
            ((System.ComponentModel.ISupportInitialize)(this._errorProviderGer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._errorProviderEng)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label _lblNewCard;
        private Button _btnSubmit;
        private Button _btnCancel;
        private Label _lblGerWord;
        private Label _lblEngWord;
        private TextBox _txtGerWord;
        private TextBox _txtEngWord;
        private ErrorProvider _errorProviderGer;
        private ErrorProvider _errorProviderEng;
        private ComboBox _cbDifficulty;
        private Label _lblDifficulty;
    }
}