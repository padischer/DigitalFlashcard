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
            this.lblNewCard = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblGerWord = new System.Windows.Forms.Label();
            this.lblEngWord = new System.Windows.Forms.Label();
            this.txtGerWord = new System.Windows.Forms.TextBox();
            this.txtEngWord = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblNewCard
            // 
            this.lblNewCard.AutoSize = true;
            this.lblNewCard.Location = new System.Drawing.Point(184, 57);
            this.lblNewCard.Name = "lblNewCard";
            this.lblNewCard.Size = new System.Drawing.Size(130, 15);
            this.lblNewCard.TabIndex = 0;
            this.lblNewCard.Text = "Neue Karte Hinzufügen";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(162, 192);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 1;
            this.btnSubmit.Text = "Bestätigen";
            this.btnSubmit.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(250, 192);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Abbrechen";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // lblGerWord
            // 
            this.lblGerWord.AutoSize = true;
            this.lblGerWord.Location = new System.Drawing.Point(148, 111);
            this.lblGerWord.Name = "lblGerWord";
            this.lblGerWord.Size = new System.Drawing.Size(89, 15);
            this.lblGerWord.TabIndex = 3;
            this.lblGerWord.Text = "deutsches Wort";
            // 
            // lblEngWord
            // 
            this.lblEngWord.AutoSize = true;
            this.lblEngWord.Location = new System.Drawing.Point(146, 145);
            this.lblEngWord.Name = "lblEngWord";
            this.lblEngWord.Size = new System.Drawing.Size(91, 15);
            this.lblEngWord.TabIndex = 4;
            this.lblEngWord.Text = "englisches Wort";
            // 
            // txtGerWord
            // 
            this.txtGerWord.Location = new System.Drawing.Point(250, 108);
            this.txtGerWord.Name = "txtGerWord";
            this.txtGerWord.Size = new System.Drawing.Size(100, 23);
            this.txtGerWord.TabIndex = 5;
            // 
            // txtEngWord
            // 
            this.txtEngWord.Location = new System.Drawing.Point(250, 142);
            this.txtEngWord.Name = "txtEngWord";
            this.txtEngWord.Size = new System.Drawing.Size(100, 23);
            this.txtEngWord.TabIndex = 6;
            // 
            // AddCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 376);
            this.Controls.Add(this.txtEngWord);
            this.Controls.Add(this.txtGerWord);
            this.Controls.Add(this.lblEngWord);
            this.Controls.Add(this.lblGerWord);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.lblNewCard);
            this.Name = "AddCard";
            this.Text = "AddCard";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblNewCard;
        private Button btnSubmit;
        private Button btnCancel;
        private Label lblGerWord;
        private Label lblEngWord;
        private TextBox txtGerWord;
        private TextBox txtEngWord;
    }
}