namespace Flashcard
{
    partial class MainForm
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
            this._btnEndProgram = new System.Windows.Forms.Button();
            this._btnReset = new System.Windows.Forms.Button();
            this._btnCardList = new System.Windows.Forms.Button();
            this._btnSkip = new System.Windows.Forms.Button();
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
            this._btnSwitchLanguage.Click += new System.EventHandler(this.BtnSwitchLanguage_Click);
            // 
            // _btnSwitchDifficulty
            // 
            this._btnSwitchDifficulty.Location = new System.Drawing.Point(93, 25);
            this._btnSwitchDifficulty.Name = "_btnSwitchDifficulty";
            this._btnSwitchDifficulty.Size = new System.Drawing.Size(75, 23);
            this._btnSwitchDifficulty.TabIndex = 1;
            this._btnSwitchDifficulty.Text = "basis";
            this._btnSwitchDifficulty.UseVisualStyleBackColor = true;
            this._btnSwitchDifficulty.Click += new System.EventHandler(this.BtnSwitchDifficulty_Click);
            // 
            // _btnAddCard
            // 
            this._btnAddCard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnAddCard.Location = new System.Drawing.Point(135, 442);
            this._btnAddCard.Name = "_btnAddCard";
            this._btnAddCard.Size = new System.Drawing.Size(121, 23);
            this._btnAddCard.TabIndex = 2;
            this._btnAddCard.Text = "Karte Hinzufügen";
            this._btnAddCard.UseVisualStyleBackColor = true;
            this._btnAddCard.Click += new System.EventHandler(this.BtnAddCard_OnClick);
            // 
            // _cbSlotNumber
            // 
            this._cbSlotNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._cbSlotNumber.FormattingEnabled = true;
            this._cbSlotNumber.Location = new System.Drawing.Point(8, 442);
            this._cbSlotNumber.Name = "_cbSlotNumber";
            this._cbSlotNumber.Size = new System.Drawing.Size(121, 23);
            this._cbSlotNumber.TabIndex = 3;
            this._cbSlotNumber.SelectedIndexChanged += new System.EventHandler(this.CbSlotNumberSelectIndexChanged);
            // 
            // _lblSlotNumber
            // 
            this._lblSlotNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._lblSlotNumber.AutoSize = true;
            this._lblSlotNumber.Location = new System.Drawing.Point(44, 420);
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
            this._lblWordToTranslate.Location = new System.Drawing.Point(110, 202);
            this._lblWordToTranslate.Name = "_lblWordToTranslate";
            this._lblWordToTranslate.Size = new System.Drawing.Size(119, 54);
            this._lblWordToTranslate.TabIndex = 5;
            this._lblWordToTranslate.Text = "Word";
            // 
            // _lbTranslationList
            // 
            this._lbTranslationList.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this._lbTranslationList.FormattingEnabled = true;
            this._lbTranslationList.ItemHeight = 15;
            this._lbTranslationList.Location = new System.Drawing.Point(525, 30);
            this._lbTranslationList.Name = "_lbTranslationList";
            this._lbTranslationList.Size = new System.Drawing.Size(186, 379);
            this._lbTranslationList.Sorted = true;
            this._lbTranslationList.TabIndex = 6;
            // 
            // _btnSubmit
            // 
            this._btnSubmit.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this._btnSubmit.Location = new System.Drawing.Point(583, 415);
            this._btnSubmit.Name = "_btnSubmit";
            this._btnSubmit.Size = new System.Drawing.Size(71, 22);
            this._btnSubmit.TabIndex = 7;
            this._btnSubmit.Text = "Bestätigen";
            this._btnSubmit.UseVisualStyleBackColor = true;
            this._btnSubmit.Click += new System.EventHandler(this.BtnSubmit_Click);
            // 
            // _lblValidation
            // 
            this._lblValidation.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this._lblValidation.AutoEllipsis = true;
            this._lblValidation.Location = new System.Drawing.Point(484, 441);
            this._lblValidation.Name = "_lblValidation";
            this._lblValidation.Size = new System.Drawing.Size(256, 23);
            this._lblValidation.TabIndex = 8;
            this._lblValidation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _btnEndProgram
            // 
            this._btnEndProgram.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._btnEndProgram.Location = new System.Drawing.Point(8, 469);
            this._btnEndProgram.Name = "_btnEndProgram";
            this._btnEndProgram.Size = new System.Drawing.Size(121, 23);
            this._btnEndProgram.TabIndex = 9;
            this._btnEndProgram.Text = "Beenden";
            this._btnEndProgram.UseVisualStyleBackColor = true;
            this._btnEndProgram.Click += new System.EventHandler(this.BtnEndProgram_Click);
            // 
            // _btnReset
            // 
            this._btnReset.Location = new System.Drawing.Point(135, 469);
            this._btnReset.Name = "_btnReset";
            this._btnReset.Size = new System.Drawing.Size(121, 23);
            this._btnReset.TabIndex = 10;
            this._btnReset.Text = "Zurücksetzen";
            this._btnReset.UseVisualStyleBackColor = true;
            this._btnReset.Click += new System.EventHandler(this.BtnReset_OnClick);
            // 
            // _btnCardList
            // 
            this._btnCardList.Location = new System.Drawing.Point(262, 469);
            this._btnCardList.Name = "_btnCardList";
            this._btnCardList.Size = new System.Drawing.Size(121, 23);
            this._btnCardList.TabIndex = 11;
            this._btnCardList.Text = "Kartenliste";
            this._btnCardList.UseVisualStyleBackColor = true;
            this._btnCardList.Click += new System.EventHandler(this.BtnCardList_OnClick);
            // 
            // _btnSkip
            // 
            this._btnSkip.Location = new System.Drawing.Point(262, 442);
            this._btnSkip.Name = "_btnSkip";
            this._btnSkip.Size = new System.Drawing.Size(121, 23);
            this._btnSkip.TabIndex = 12;
            this._btnSkip.Text = "Überspringen";
            this._btnSkip.UseVisualStyleBackColor = true;
            this._btnSkip.Click += new System.EventHandler(this.BtnSkip_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 497);
            this.Controls.Add(this._btnSkip);
            this.Controls.Add(this._btnCardList);
            this.Controls.Add(this._btnReset);
            this.Controls.Add(this._btnEndProgram);
            this.Controls.Add(this._lblValidation);
            this.Controls.Add(this._btnSubmit);
            this.Controls.Add(this._lbTranslationList);
            this.Controls.Add(this._lblWordToTranslate);
            this.Controls.Add(this._lblSlotNumber);
            this.Controls.Add(this._cbSlotNumber);
            this.Controls.Add(this._btnAddCard);
            this.Controls.Add(this._btnSwitchDifficulty);
            this.Controls.Add(this._btnSwitchLanguage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MainForm";
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
        private Button _btnEndProgram;
        private Button _btnReset;
        private Button _btnCardList;
        private Button _btnSkip;
    }
}