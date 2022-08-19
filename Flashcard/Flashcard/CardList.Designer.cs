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
            this._btnEdit = new System.Windows.Forms.Button();
            this._btnDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _btnCancel
            // 
            this._btnCancel.Location = new System.Drawing.Point(399, 415);
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.Size = new System.Drawing.Size(121, 23);
            this._btnCancel.TabIndex = 1;
            this._btnCancel.Text = "Zurück";
            this._btnCancel.UseVisualStyleBackColor = true;
            this._btnCancel.Click += new System.EventHandler(this.BtnCancel_OnClick);
            // 
            // _lvCardList
            // 
            this._lvCardList.Location = new System.Drawing.Point(115, 12);
            this._lvCardList.Name = "_lvCardList";
            this._lvCardList.Size = new System.Drawing.Size(437, 368);
            this._lvCardList.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this._lvCardList.TabIndex = 2;
            this._lvCardList.UseCompatibleStateImageBehavior = false;
            // 
            // _btnEdit
            // 
            this._btnEdit.Location = new System.Drawing.Point(272, 415);
            this._btnEdit.Name = "_btnEdit";
            this._btnEdit.Size = new System.Drawing.Size(121, 23);
            this._btnEdit.TabIndex = 3;
            this._btnEdit.Text = "Bearbeiten";
            this._btnEdit.UseVisualStyleBackColor = true;
            this._btnEdit.Click += new System.EventHandler(this.BtnEdit_OnClick);
            // 
            // _btnDelete
            // 
            this._btnDelete.Location = new System.Drawing.Point(145, 415);
            this._btnDelete.Name = "_btnDelete";
            this._btnDelete.Size = new System.Drawing.Size(121, 23);
            this._btnDelete.TabIndex = 4;
            this._btnDelete.Text = "Löschen";
            this._btnDelete.UseVisualStyleBackColor = true;
            this._btnDelete.Click += new System.EventHandler(this.BtnDelete_OnClick);
            // 
            // CardList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(655, 450);
            this.Controls.Add(this._btnDelete);
            this.Controls.Add(this._btnEdit);
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
        private Button _btnEdit;
        private Button _btnDelete;
    }
}