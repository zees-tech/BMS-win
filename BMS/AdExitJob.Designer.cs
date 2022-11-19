namespace BMS
{
    partial class AdExitJob
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
            this.comlbl = new System.Windows.Forms.Label();
            this.neworkchk = new System.Windows.Forms.CheckBox();
            this.mslbl = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvitemdt = new System.Windows.Forms.DataGridView();
            this.delbtn = new System.Windows.Forms.Button();
            this.discardbtn = new System.Windows.Forms.Button();
            this.newbtn = new System.Windows.Forms.Button();
            this.partyccmbx = new System.Windows.Forms.ComboBox();
            this.savebtn = new System.Windows.Forms.Button();
            this.addbtn = new System.Windows.Forms.Button();
            this.ratetxt = new System.Windows.Forms.TextBox();
            this.qntytxt = new System.Windows.Forms.TextBox();
            this.hsntxt = new System.Windows.Forms.TextBox();
            this.descripttxt = new System.Windows.Forms.TextBox();
            this.itemcmb = new System.Windows.Forms.ComboBox();
            this.worknocmb = new System.Windows.Forms.ComboBox();
            this.catlbl = new System.Windows.Forms.Label();
            this.newcatchk = new System.Windows.Forms.CheckBox();
            this.designtxt = new System.Windows.Forms.TextBox();
            this.cattxt = new System.Windows.Forms.TextBox();
            this.itemcol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.workcol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descriptioncol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hsncol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qntycol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ratecol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.designno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvitemdt)).BeginInit();
            this.SuspendLayout();
            // 
            // comlbl
            // 
            this.comlbl.AutoSize = true;
            this.comlbl.Location = new System.Drawing.Point(325, 14);
            this.comlbl.Name = "comlbl";
            this.comlbl.Size = new System.Drawing.Size(35, 13);
            this.comlbl.TabIndex = 31;
            this.comlbl.Text = "label6";
            // 
            // neworkchk
            // 
            this.neworkchk.AutoSize = true;
            this.neworkchk.Location = new System.Drawing.Point(12, 144);
            this.neworkchk.Name = "neworkchk";
            this.neworkchk.Size = new System.Drawing.Size(77, 17);
            this.neworkchk.TabIndex = 25;
            this.neworkchk.Text = "New Work";
            this.neworkchk.UseVisualStyleBackColor = true;
            this.neworkchk.CheckedChanged += new System.EventHandler(this.neworkchk_CheckedChanged);
            // 
            // mslbl
            // 
            this.mslbl.AutoSize = true;
            this.mslbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mslbl.Location = new System.Drawing.Point(12, 43);
            this.mslbl.Name = "mslbl";
            this.mslbl.Size = new System.Drawing.Size(51, 25);
            this.mslbl.TabIndex = 17;
            this.mslbl.Text = "M/s:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(607, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Rate";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(533, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Quantity";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(451, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "HSN";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(280, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Description";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Item No.";
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
            this.workcol,
            this.Descriptioncol,
            this.hsncol,
            this.qntycol,
            this.ratecol,
            this.designno});
            this.dgvitemdt.Location = new System.Drawing.Point(12, 170);
            this.dgvitemdt.Name = "dgvitemdt";
            this.dgvitemdt.RowHeadersVisible = false;
            this.dgvitemdt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvitemdt.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvitemdt.Size = new System.Drawing.Size(646, 350);
            this.dgvitemdt.TabIndex = 15;
            // 
            // delbtn
            // 
            this.delbtn.Location = new System.Drawing.Point(583, 138);
            this.delbtn.Name = "delbtn";
            this.delbtn.Size = new System.Drawing.Size(75, 23);
            this.delbtn.TabIndex = 27;
            this.delbtn.Text = "Delete";
            this.delbtn.UseVisualStyleBackColor = true;
            this.delbtn.Click += new System.EventHandler(this.delbtn_Click);
            // 
            // discardbtn
            // 
            this.discardbtn.Location = new System.Drawing.Point(583, 69);
            this.discardbtn.Name = "discardbtn";
            this.discardbtn.Size = new System.Drawing.Size(75, 23);
            this.discardbtn.TabIndex = 30;
            this.discardbtn.Text = "Discard";
            this.discardbtn.UseVisualStyleBackColor = true;
            this.discardbtn.Click += new System.EventHandler(this.discardbtn_Click);
            // 
            // newbtn
            // 
            this.newbtn.Location = new System.Drawing.Point(583, 11);
            this.newbtn.Name = "newbtn";
            this.newbtn.Size = new System.Drawing.Size(75, 23);
            this.newbtn.TabIndex = 28;
            this.newbtn.Text = "New";
            this.newbtn.UseVisualStyleBackColor = true;
            this.newbtn.Click += new System.EventHandler(this.newbtn_Click);
            // 
            // partyccmbx
            // 
            this.partyccmbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.partyccmbx.FormattingEnabled = true;
            this.partyccmbx.Location = new System.Drawing.Point(69, 40);
            this.partyccmbx.Name = "partyccmbx";
            this.partyccmbx.Size = new System.Drawing.Size(361, 33);
            this.partyccmbx.TabIndex = 12;
            this.partyccmbx.SelectedIndexChanged += new System.EventHandler(this.partyccmbx_SelectedIndexChanged);
            // 
            // savebtn
            // 
            this.savebtn.Location = new System.Drawing.Point(583, 40);
            this.savebtn.Name = "savebtn";
            this.savebtn.Size = new System.Drawing.Size(75, 23);
            this.savebtn.TabIndex = 29;
            this.savebtn.Text = "Save";
            this.savebtn.UseVisualStyleBackColor = true;
            this.savebtn.Click += new System.EventHandler(this.savebtn_Click);
            // 
            // addbtn
            // 
            this.addbtn.Location = new System.Drawing.Point(504, 138);
            this.addbtn.Name = "addbtn";
            this.addbtn.Size = new System.Drawing.Size(75, 23);
            this.addbtn.TabIndex = 26;
            this.addbtn.Text = "Add";
            this.addbtn.UseVisualStyleBackColor = true;
            this.addbtn.Click += new System.EventHandler(this.addbtn_Click);
            // 
            // ratetxt
            // 
            this.ratetxt.Location = new System.Drawing.Point(590, 112);
            this.ratetxt.Name = "ratetxt";
            this.ratetxt.Size = new System.Drawing.Size(68, 20);
            this.ratetxt.TabIndex = 24;
            // 
            // qntytxt
            // 
            this.qntytxt.Location = new System.Drawing.Point(516, 112);
            this.qntytxt.Name = "qntytxt";
            this.qntytxt.Size = new System.Drawing.Size(68, 20);
            this.qntytxt.TabIndex = 23;
            this.qntytxt.TextChanged += new System.EventHandler(this.qntytxt_TextChanged);
            // 
            // hsntxt
            // 
            this.hsntxt.Location = new System.Drawing.Point(426, 112);
            this.hsntxt.Name = "hsntxt";
            this.hsntxt.Size = new System.Drawing.Size(84, 20);
            this.hsntxt.TabIndex = 16;
            // 
            // descripttxt
            // 
            this.descripttxt.Location = new System.Drawing.Point(200, 112);
            this.descripttxt.Name = "descripttxt";
            this.descripttxt.Size = new System.Drawing.Size(220, 20);
            this.descripttxt.TabIndex = 14;
            // 
            // itemcmb
            // 
            this.itemcmb.FormattingEnabled = true;
            this.itemcmb.Location = new System.Drawing.Point(12, 112);
            this.itemcmb.Name = "itemcmb";
            this.itemcmb.Size = new System.Drawing.Size(88, 21);
            this.itemcmb.TabIndex = 13;
            this.itemcmb.SelectedIndexChanged += new System.EventHandler(this.itemcmb_SelectedIndexChanged);
            // 
            // worknocmb
            // 
            this.worknocmb.FormattingEnabled = true;
            this.worknocmb.Location = new System.Drawing.Point(106, 112);
            this.worknocmb.Name = "worknocmb";
            this.worknocmb.Size = new System.Drawing.Size(88, 21);
            this.worknocmb.TabIndex = 13;
            this.worknocmb.SelectedIndexChanged += new System.EventHandler(this.worknocmb_SelectedIndexChanged);
            // 
            // catlbl
            // 
            this.catlbl.AutoSize = true;
            this.catlbl.Location = new System.Drawing.Point(127, 96);
            this.catlbl.Name = "catlbl";
            this.catlbl.Size = new System.Drawing.Size(53, 13);
            this.catlbl.TabIndex = 22;
            this.catlbl.Text = "Work No.";
            // 
            // newcatchk
            // 
            this.newcatchk.AutoSize = true;
            this.newcatchk.Location = new System.Drawing.Point(106, 144);
            this.newcatchk.Name = "newcatchk";
            this.newcatchk.Size = new System.Drawing.Size(93, 17);
            this.newcatchk.TabIndex = 25;
            this.newcatchk.Text = "New Category";
            this.newcatchk.UseVisualStyleBackColor = true;
            this.newcatchk.CheckedChanged += new System.EventHandler(this.newcatchk_CheckedChanged);
            // 
            // designtxt
            // 
            this.designtxt.Location = new System.Drawing.Point(200, 142);
            this.designtxt.Name = "designtxt";
            this.designtxt.Size = new System.Drawing.Size(84, 20);
            this.designtxt.TabIndex = 16;
            this.designtxt.Text = "Design No.";
            this.designtxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cattxt
            // 
            this.cattxt.Location = new System.Drawing.Point(106, 112);
            this.cattxt.Name = "cattxt";
            this.cattxt.Size = new System.Drawing.Size(88, 20);
            this.cattxt.TabIndex = 16;
            this.cattxt.Text = "Name";
            this.cattxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.cattxt.Visible = false;
            // 
            // itemcol
            // 
            this.itemcol.HeaderText = "Item No.";
            this.itemcol.Name = "itemcol";
            this.itemcol.Width = 90;
            // 
            // workcol
            // 
            this.workcol.HeaderText = "Work No.";
            this.workcol.Name = "workcol";
            // 
            // Descriptioncol
            // 
            this.Descriptioncol.HeaderText = "Descrption";
            this.Descriptioncol.Name = "Descriptioncol";
            this.Descriptioncol.Width = 220;
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
            // designno
            // 
            this.designno.HeaderText = "Column1";
            this.designno.Name = "designno";
            this.designno.Visible = false;
            // 
            // AdExitJob
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 530);
            this.Controls.Add(this.comlbl);
            this.Controls.Add(this.newcatchk);
            this.Controls.Add(this.neworkchk);
            this.Controls.Add(this.mslbl);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.catlbl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvitemdt);
            this.Controls.Add(this.delbtn);
            this.Controls.Add(this.discardbtn);
            this.Controls.Add(this.newbtn);
            this.Controls.Add(this.partyccmbx);
            this.Controls.Add(this.savebtn);
            this.Controls.Add(this.addbtn);
            this.Controls.Add(this.ratetxt);
            this.Controls.Add(this.qntytxt);
            this.Controls.Add(this.designtxt);
            this.Controls.Add(this.hsntxt);
            this.Controls.Add(this.descripttxt);
            this.Controls.Add(this.worknocmb);
            this.Controls.Add(this.itemcmb);
            this.Controls.Add(this.cattxt);
            this.Name = "AdExitJob";
            this.Text = "AdExitJob";
            ((System.ComponentModel.ISupportInitialize)(this.dgvitemdt)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label comlbl;
        private System.Windows.Forms.CheckBox neworkchk;
        private System.Windows.Forms.Label mslbl;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvitemdt;
        private System.Windows.Forms.Button delbtn;
        private System.Windows.Forms.Button discardbtn;
        private System.Windows.Forms.Button newbtn;
        private System.Windows.Forms.ComboBox partyccmbx;
        private System.Windows.Forms.Button savebtn;
        private System.Windows.Forms.Button addbtn;
        private System.Windows.Forms.TextBox ratetxt;
        private System.Windows.Forms.TextBox qntytxt;
        private System.Windows.Forms.TextBox hsntxt;
        private System.Windows.Forms.TextBox descripttxt;
        private System.Windows.Forms.ComboBox itemcmb;
        private System.Windows.Forms.ComboBox worknocmb;
        private System.Windows.Forms.Label catlbl;
        private System.Windows.Forms.CheckBox newcatchk;
        private System.Windows.Forms.TextBox designtxt;
        private System.Windows.Forms.TextBox cattxt;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemcol;
        private System.Windows.Forms.DataGridViewTextBoxColumn workcol;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descriptioncol;
        private System.Windows.Forms.DataGridViewTextBoxColumn hsncol;
        private System.Windows.Forms.DataGridViewTextBoxColumn qntycol;
        private System.Windows.Forms.DataGridViewTextBoxColumn ratecol;
        private System.Windows.Forms.DataGridViewTextBoxColumn designno;
    }
}