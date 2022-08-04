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
            this.btnSwitchLanguage = new System.Windows.Forms.Button();
            this.btnSwitchDifficulty = new System.Windows.Forms.Button();
            this.btnAddCard = new System.Windows.Forms.Button();
            this.cbSlotNumber = new System.Windows.Forms.ComboBox();
            this.lblSlotNumber = new System.Windows.Forms.Label();
            this.lblWordToTranslate = new System.Windows.Forms.Label();
            this.lbTranslationList = new System.Windows.Forms.ListBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSwitchLanguage
            // 
            this.btnSwitchLanguage.Location = new System.Drawing.Point(12, 25);
            this.btnSwitchLanguage.Name = "btnSwitchLanguage";
            this.btnSwitchLanguage.Size = new System.Drawing.Size(75, 23);
            this.btnSwitchLanguage.TabIndex = 0;
            this.btnSwitchLanguage.Text = "deu->eng";
            this.btnSwitchLanguage.UseVisualStyleBackColor = true;
            // 
            // btnSwitchDifficulty
            // 
            this.btnSwitchDifficulty.Location = new System.Drawing.Point(93, 25);
            this.btnSwitchDifficulty.Name = "btnSwitchDifficulty";
            this.btnSwitchDifficulty.Size = new System.Drawing.Size(75, 23);
            this.btnSwitchDifficulty.TabIndex = 1;
            this.btnSwitchDifficulty.Text = "Basis";
            this.btnSwitchDifficulty.UseVisualStyleBackColor = true;
            // 
            // btnAddCard
            // 
            this.btnAddCard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddCard.Location = new System.Drawing.Point(139, 411);
            this.btnAddCard.Name = "btnAddCard";
            this.btnAddCard.Size = new System.Drawing.Size(108, 23);
            this.btnAddCard.TabIndex = 2;
            this.btnAddCard.Text = "Karte Hinzufügen";
            this.btnAddCard.UseVisualStyleBackColor = true;
            // 
            // cbSlotNumber
            // 
            this.cbSlotNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbSlotNumber.FormattingEnabled = true;
            this.cbSlotNumber.Location = new System.Drawing.Point(12, 411);
            this.cbSlotNumber.Name = "cbSlotNumber";
            this.cbSlotNumber.Size = new System.Drawing.Size(121, 23);
            this.cbSlotNumber.TabIndex = 3;
            // 
            // lblSlotNumber
            // 
            this.lblSlotNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSlotNumber.AutoSize = true;
            this.lblSlotNumber.Location = new System.Drawing.Point(48, 389);
            this.lblSlotNumber.Name = "lblSlotNumber";
            this.lblSlotNumber.Size = new System.Drawing.Size(48, 15);
            this.lblSlotNumber.TabIndex = 4;
            this.lblSlotNumber.Text = "Slot-Nr.";
            // 
            // lblWordToTranslate
            // 
            this.lblWordToTranslate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblWordToTranslate.AutoSize = true;
            this.lblWordToTranslate.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblWordToTranslate.Location = new System.Drawing.Point(110, 179);
            this.lblWordToTranslate.Name = "lblWordToTranslate";
            this.lblWordToTranslate.Size = new System.Drawing.Size(119, 54);
            this.lblWordToTranslate.TabIndex = 5;
            this.lblWordToTranslate.Text = "Word";
            // 
            // lbTranslationList
            // 
            this.lbTranslationList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbTranslationList.FormattingEnabled = true;
            this.lbTranslationList.ItemHeight = 15;
            this.lbTranslationList.Location = new System.Drawing.Point(524, 25);
            this.lbTranslationList.Name = "lbTranslationList";
            this.lbTranslationList.Size = new System.Drawing.Size(186, 379);
            this.lbTranslationList.TabIndex = 6;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSubmit.Location = new System.Drawing.Point(577, 411);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 7;
            this.btnSubmit.Text = "Bestätigen";
            this.btnSubmit.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 450);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.lbTranslationList);
            this.Controls.Add(this.lblWordToTranslate);
            this.Controls.Add(this.lblSlotNumber);
            this.Controls.Add(this.cbSlotNumber);
            this.Controls.Add(this.btnAddCard);
            this.Controls.Add(this.btnSwitchDifficulty);
            this.Controls.Add(this.btnSwitchLanguage);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnSwitchLanguage;
        private Button btnSwitchDifficulty;
        private Button btnAddCard;
        private ComboBox cbSlotNumber;
        private Label lblSlotNumber;
        private Label lblWordToTranslate;
        private ListBox lbTranslationList;
        private Button btnSubmit;
    }
}