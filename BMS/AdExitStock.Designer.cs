namespace BMS
{
    partial class AdExitStock
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
            this.itemcmb = new System.Windows.Forms.ComboBox();
            this.descripttxt = new System.Windows.Forms.TextBox();
            this.hsntxt = new System.Windows.Forms.TextBox();
            this.qntytxt = new System.Windows.Forms.TextBox();
            this.ratetxt = new System.Windows.Forms.TextBox();
            this.addbtn = new System.Windows.Forms.Button();
            this.dgvitemdt = new System.Windows.Forms.DataGridView();
            this.itemcol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descriptioncol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hsncol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qntycol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ratecol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.delbtn = new System.Windows.Forms.Button();
            this.partyccmbx = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.mslbl = new System.Windows.Forms.Label();
            this.newitemchk = new System.Windows.Forms.CheckBox();
            this.savebtn = new System.Windows.Forms.Button();
            this.discardbtn = new System.Windows.Forms.Button();
            this.comlbl = new System.Windows.Forms.Label();
            this.newbtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvitemdt)).BeginInit();
            this.SuspendLayout();
            // 
            // itemcmb
            // 
            this.itemcmb.FormattingEnabled = true;
            this.itemcmb.Location = new System.Drawing.Point(12, 111);
            this.itemcmb.Name = "itemcmb";
            this.itemcmb.Size = new System.Drawing.Size(104, 21);
            this.itemcmb.TabIndex = 1;
            this.itemcmb.SelectedIndexChanged += new System.EventHandler(this.itemcmb_SelectedIndexChanged);
            // 
            // descripttxt
            // 
            this.descripttxt.Location = new System.Drawing.Point(122, 111);
            this.descripttxt.Name = "descripttxt";
            this.descripttxt.Size = new System.Drawing.Size(298, 20);
            this.descripttxt.TabIndex = 2;
            // 
            // hsntxt
            // 
            this.hsntxt.Location = new System.Drawing.Point(426, 111);
            this.hsntxt.Name = "hsntxt";
            this.hsntxt.Size = new System.Drawing.Size(84, 20);
            this.hsntxt.TabIndex = 3;
            // 
            // qntytxt
            // 
            this.qntytxt.Location = new System.Drawing.Point(516, 111);
            this.qntytxt.Name = "qntytxt";
            this.qntytxt.Size = new System.Drawing.Size(68, 20);
            this.qntytxt.TabIndex = 4;
            // 
            // ratetxt
            // 
            this.ratetxt.Location = new System.Drawing.Point(590, 111);
            this.ratetxt.Name = "ratetxt";
            this.ratetxt.Size = new System.Drawing.Size(68, 20);
            this.ratetxt.TabIndex = 5;
            // 
            // addbtn
            // 
            this.addbtn.Location = new System.Drawing.Point(504, 137);
            this.addbtn.Name = "addbtn";
            this.addbtn.Size = new System.Drawing.Size(75, 23);
            this.addbtn.TabIndex = 7;
            this.addbtn.Text = "Add";
            this.addbtn.UseVisualStyleBackColor = true;
            this.addbtn.Click += new System.EventHandler(this.addbtn_Click);
            // 
            // dgvitemdt
            // 
            this.dgvitemdt.AllowUserToAddRows = false;
            this.dgvitemdt.AllowUserToDeleteRows = false;
            this.dgvitemdt.AllowUserToResizeColumns = false;
            this.dgvitemdt.AllowUserToResizeRows = false;
            this.dgvitemdt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvitemdt.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.itemcol,
            this.Descriptioncol,
            this.hsncol,
            this.qntycol,
            this.ratecol});
            this.dgvitemdt.Location = new System.Drawing.Point(12, 169);
            this.dgvitemdt.Name = "dgvitemdt";
            this.dgvitemdt.RowHeadersVisible = false;
            this.dgvitemdt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvitemdt.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvitemdt.Size = new System.Drawing.Size(646, 350);
            this.dgvitemdt.TabIndex = 3;
            // 
            // itemcol
            // 
            this.itemcol.HeaderText = "Item No.";
            this.itemcol.Name = "itemcol";
            this.itemcol.Width = 105;
            // 
            // Descriptioncol
            // 
            this.Descriptioncol.HeaderText = "Descrption";
            this.Descriptioncol.Name = "Descriptioncol";
            this.Descriptioncol.Width = 300;
            // 
            // hsncol
            // 
            this.hsncol.HeaderText = "HSN";
            this.hsncol.Name = "hsncol";
            this.hsncol.Width = 85;
            // 
            // qntycol
            // 
            this.qntycol.HeaderText = "Quantity";
            this.qntycol.Name = "qntycol";
            this.qntycol.Width = 70;
            // 
            // ratecol
            // 
            this.ratecol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ratecol.HeaderText = "Rate";
            this.ratecol.Name = "ratecol";
            // 
            // delbtn
            // 
            this.delbtn.Location = new System.Drawing.Point(583, 137);
            this.delbtn.Name = "delbtn";
            this.delbtn.Size = new System.Drawing.Size(75, 23);
            this.delbtn.TabIndex = 8;
            this.delbtn.Text = "Delete";
            this.delbtn.UseVisualStyleBackColor = true;
            this.delbtn.Click += new System.EventHandler(this.delbtn_Click);
            // 
            // partyccmbx
            // 
            this.partyccmbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.partyccmbx.FormattingEnabled = true;
            this.partyccmbx.Location = new System.Drawing.Point(69, 39);
            this.partyccmbx.Name = "partyccmbx";
            this.partyccmbx.Size = new System.Drawing.Size(361, 33);
            this.partyccmbx.TabIndex = 0;
            this.partyccmbx.SelectedIndexChanged += new System.EventHandler(this.partyccmbx_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Item No.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(254, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Description";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(451, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "HSN";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(533, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Quantity";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(607, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Rate";
            // 
            // mslbl
            // 
            this.mslbl.AutoSize = true;
            this.mslbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mslbl.Location = new System.Drawing.Point(12, 42);
            this.mslbl.Name = "mslbl";
            this.mslbl.Size = new System.Drawing.Size(51, 25);
            this.mslbl.TabIndex = 4;
            this.mslbl.Text = "M/s:";
            // 
            // newitemchk
            // 
            this.newitemchk.AutoSize = true;
            this.newitemchk.Location = new System.Drawing.Point(12, 143);
            this.newitemchk.Name = "newitemchk";
            this.newitemchk.Size = new System.Drawing.Size(71, 17);
            this.newitemchk.TabIndex = 6;
            this.newitemchk.Text = "New Item";
            this.newitemchk.UseVisualStyleBackColor = true;
            this.newitemchk.CheckedChanged += new System.EventHandler(this.newitemchk_CheckedChanged);
            // 
            // savebtn
            // 
            this.savebtn.Location = new System.Drawing.Point(583, 39);
            this.savebtn.Name = "savebtn";
            this.savebtn.Size = new System.Drawing.Size(75, 23);
            this.savebtn.TabIndex = 9;
            this.savebtn.Text = "Save";
            this.savebtn.UseVisualStyleBackColor = true;
            this.savebtn.Click += new System.EventHandler(this.savebtn_Click);
            // 
            // discardbtn
            // 
            this.discardbtn.Location = new System.Drawing.Point(583, 68);
            this.discardbtn.Name = "discardbtn";
            this.discardbtn.Size = new System.Drawing.Size(75, 23);
            this.discardbtn.TabIndex = 10;
            this.discardbtn.Text = "Discard";
            this.discardbtn.UseVisualStyleBackColor = true;
            this.discardbtn.Click += new System.EventHandler(this.discardbtn_Click);
            // 
            // comlbl
            // 
            this.comlbl.AutoSize = true;
            this.comlbl.Location = new System.Drawing.Point(325, 13);
            this.comlbl.Name = "comlbl";
            this.comlbl.Size = new System.Drawing.Size(35, 13);
            this.comlbl.TabIndex = 11;
            this.comlbl.Text = "label6";
            // 
            // newbtn
            // 
            this.newbtn.Location = new System.Drawing.Point(583, 10);
            this.newbtn.Name = "newbtn";
            this.newbtn.Size = new System.Drawing.Size(75, 23);
            this.newbtn.TabIndex = 9;
            this.newbtn.Text = "New";
            this.newbtn.UseVisualStyleBackColor = true;
            this.newbtn.Click += new System.EventHandler(this.newbtn_Click);
            // 
            // AdExitStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 530);
            this.Controls.Add(this.comlbl);
            this.Controls.Add(this.newitemchk);
            this.Controls.Add(this.mslbl);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvitemdt);
            this.Controls.Add(this.delbtn);
            this.Controls.Add(this.discardbtn);
            this.Controls.Add(this.newbtn);
            this.Controls.Add(this.savebtn);
            this.Controls.Add(this.addbtn);
            this.Controls.Add(this.ratetxt);
            this.Controls.Add(this.qntytxt);
            this.Controls.Add(this.hsntxt);
            this.Controls.Add(this.descripttxt);
            this.Controls.Add(this.partyccmbx);
            this.Controls.Add(this.itemcmb);
            this.Name = "AdExitStock";
            this.Text = "AdExitStock";
            ((System.ComponentModel.ISupportInitialize)(this.dgvitemdt)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox itemcmb;
        private System.Windows.Forms.TextBox descripttxt;
        private System.Windows.Forms.TextBox hsntxt;
        private System.Windows.Forms.TextBox qntytxt;
        private System.Windows.Forms.TextBox ratetxt;
        private System.Windows.Forms.Button addbtn;
        private System.Windows.Forms.DataGridView dgvitemdt;
        private System.Windows.Forms.Button delbtn;
        private System.Windows.Forms.ComboBox partyccmbx;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label mslbl;
        private System.Windows.Forms.CheckBox newitemchk;
        private System.Windows.Forms.Button savebtn;
        private System.Windows.Forms.Button discardbtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemcol;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descriptioncol;
        private System.Windows.Forms.DataGridViewTextBoxColumn hsncol;
        private System.Windows.Forms.DataGridViewTextBoxColumn qntycol;
        private System.Windows.Forms.DataGridViewTextBoxColumn ratecol;
        private System.Windows.Forms.Label comlbl;
        private System.Windows.Forms.Button newbtn;
    }
}