namespace Flashcard
{
    partial class mainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._btnSwitchLanguage = new System.Windows.Forms.Button();
            this._btnSwitchDifficulty = new System.Windows.Forms.Button();
            this._btnAddCard = new System.Windows.Forms.Button();
            this._cbSlotNumber = new System.Windows.Forms.ComboBox();
            this._lblSlotNumber = new System.Windows.Forms.Label();
            this._lblWordToTranslate = new System.Windows.Forms.Label();
            this._lbTranslationList = new System.Windows.Forms.ListBox();
            this._btnSubmit = new System.Windows.Forms.Button();
            this._lblValidation = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _btnSwitchLanguage
            // 
            this._btnSwitchLanguage.Location = new System.Drawing.Point(12, 25);
            this._btnSwitchLanguage.Name = "_btnSwitchLanguage";
            this._btnSwitchLanguage.Size = new System.Drawing.Size(75, 23);
            this._btnSwitchLanguage.TabIndex = 0;
            this._btnSwitchLanguage.Text = "deu->eng";
            this._btnSwitchLanguage.UseVisualStyleBackColor = true;
            // 
            // _btnSwitchDifficulty
            // 
            this._btnSwitchDifficulty.Location = new System.Drawing.Point(93, 25);
            this._btnSwitchDifficulty.Name = "_btnSwitchDifficulty";
            this._btnSwitchDifficulty.Size = new System.Drawing.Size(75, 23);
            this._btnSwitchDifficulty.TabIndex = 1;
            this._btnSwitchDifficulty.Text = "Basis";
            this._btnSwitchDifficulty.UseVisualStyleBackColor = true;
            this._btnSwitchDifficulty.Click += new System.EventHandler(this.BtnSwitchDifficulty_Click);
            // 
            // _btnAddCard
            // 
            this._btnAddCard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnAddCard.Location = new System.Drawing.Point(139, 448);
            this._btnAddCard.Name = "_btnAddCard";
            this._btnAddCard.Size = new System.Drawing.Size(108, 23);
            this._btnAddCard.TabIndex = 2;
            this._btnAddCard.Text = "Karte Hinzufügen";
            this._btnAddCard.UseVisualStyleBackColor = true;
            // 
            // _cbSlotNumber
            // 
            this._cbSlotNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._cbSlotNumber.FormattingEnabled = true;
            this._cbSlotNumber.Location = new System.Drawing.Point(12, 448);
            this._cbSlotNumber.Name = "_cbSlotNumber";
            this._cbSlotNumber.Size = new System.Drawing.Size(121, 23);
            this._cbSlotNumber.TabIndex = 3;
            this._cbSlotNumber.SelectedIndexChanged += new System.EventHandler(this.CbSlotNumberSelectIndexChanged);
            // 
            // _lblSlotNumber
            // 
            this._lblSlotNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._lblSlotNumber.AutoSize = true;
            this._lblSlotNumber.Location = new System.Drawing.Point(48, 426);
            this._lblSlotNumber.Name = "_lblSlotNumber";
            this._lblSlotNumber.Size = new System.Drawing.Size(48, 15);
            this._lblSlotNumber.TabIndex = 4;
            this._lblSlotNumber.Text = "Slot-Nr.";
            // 
            // _lblWordToTranslate
            // 
            this._lblWordToTranslate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this._lblWordToTranslate.AutoSize = true;
            this._lblWordToTranslate.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this._lblWordToTranslate.Location = new System.Drawing.Point(110, 197);
            this._lblWordToTranslate.Name = "_lblWordToTranslate";
            this._lblWordToTranslate.Size = new System.Drawing.Size(119, 54);
            this._lblWordToTranslate.TabIndex = 5;
            this._lblWordToTranslate.Text = "Word";
            // 
            // _lbTranslationList
            // 
            this._lbTranslationList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._lbTranslationList.FormattingEnabled = true;
            this._lbTranslationList.ItemHeight = 15;
            this._lbTranslationList.Location = new System.Drawing.Point(501, 25);
            this._lbTranslationList.Name = "_lbTranslationList";
            this._lbTranslationList.Size = new System.Drawing.Size(186, 379);
            this._lbTranslationList.Sorted = true;
            this._lbTranslationList.TabIndex = 6;
            // 
            // _btnSubmit
            // 
            this._btnSubmit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnSubmit.Location = new System.Drawing.Point(556, 410);
            this._btnSubmit.Name = "_btnSubmit";
            this._btnSubmit.Size = new System.Drawing.Size(75, 23);
            this._btnSubmit.TabIndex = 7;
            this._btnSubmit.Text = "Bestätigen";
            this._btnSubmit.UseVisualStyleBackColor = true;
            this._btnSubmit.Click += new System.EventHandler(this.BtnSubmit_Click);
            // 
            // _lblValidation
            // 
            this._lblValidation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._lblValidation.AutoEllipsis = true;
            this._lblValidation.Location = new System.Drawing.Point(501, 448);
            this._lblValidation.Name = "_lblValidation";
            this._lblValidation.Size = new System.Drawing.Size(186, 15);
            this._lblValidation.TabIndex = 8;
            this._lblValidation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(745, 487);
            this.Controls.Add(this._lblValidation);
            this.Controls.Add(this._btnSubmit);
            this.Controls.Add(this._lbTranslationList);
            this.Controls.Add(this._lblWordToTranslate);
            this.Controls.Add(this._lblSlotNumber);
            this.Controls.Add(this._cbSlotNumber);
            this.Controls.Add(this._btnAddCard);
            this.Controls.Add(this._btnSwitchDifficulty);
            this.Controls.Add(this._btnSwitchLanguage);
            this.Name = "mainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button _btnSwitchLanguage;
        private Button _btnSwitchDifficulty;
        private Button _btnAddCard;
        private ComboBox _cbSlotNumber;
        private Label _lblSlotNumber;
        private Label _lblWordToTranslate;
        private ListBox _lbTranslationList;
        private Button _btnSubmit;
        private Label _lblValidation;
    }
}