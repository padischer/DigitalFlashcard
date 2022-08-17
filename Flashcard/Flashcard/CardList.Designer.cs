namespace Flashcard
{
    partial class CardList
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
            this._btnCancel = new System.Windows.Forms.Button();
            this._lvCardList = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // _btnCancel
            // 
            this._btnCancel.Location = new System.Drawing.Point(298, 415);
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.Size = new System.Drawing.Size(75, 23);
            this._btnCancel.TabIndex = 1;
            this._btnCancel.Text = "Zurück";
            this._btnCancel.UseVisualStyleBackColor = true;
            this._btnCancel.Click += new System.EventHandler(this.BtnCancel_OnClick);
            // 
            // _lvCardList
            // 
            this._lvCardList.Location = new System.Drawing.Point(84, 12);
            this._lvCardList.Name = "_lvCardList";
            this._lvCardList.Size = new System.Drawing.Size(432, 368);
            this._lvCardList.TabIndex = 2;
            this._lvCardList.UseCompatibleStateImageBehavior = false;
            // 
            // CardList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(655, 450);
            this.Controls.Add(this._lvCardList);
            this.Controls.Add(this._btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "CardList";
            this.Text = "CardList";
            this.Load += new System.EventHandler(this.CardList_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private Button _btnCancel;
        private ListView _lvCardList;
    }
}