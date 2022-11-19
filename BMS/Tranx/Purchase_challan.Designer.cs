namespace bms1
{
    partial class Purchase_challan
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
            this.previousbtn = new System.Windows.Forms.Button();
            this.AdItemgrp = new System.Windows.Forms.GroupBox();
            this.ratelbl = new System.Windows.Forms.Label();
            this.qntylbl = new System.Windows.Forms.Label();
            this.hsnlbl = new System.Windows.Forms.Label();
            this.Descrplbl = new System.Windows.Forms.Label();
            this.itmlbl = new System.Windows.Forms.Label();
            this.addbtn = new System.Windows.Forms.Button();
            this.ratetxt = new System.Windows.Forms.TextBox();
            this.qntytxt = new System.Windows.Forms.TextBox();
            this.hsntxt = new System.Windows.Forms.TextBox();
            this.descrptxt = new System.Windows.Forms.TextBox();
            this.itemcmbx = new System.Windows.Forms.ComboBox();
            this.comlbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.suppliercmbx = new System.Windows.Forms.ComboBox();
            this.itemdtdgv = new System.Windows.Forms.DataGridView();
            this.itemcol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descriptcol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hsncol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qntycol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ratecol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amtcol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.new_itemchbx = new System.Windows.Forms.CheckBox();
            this.Nextbtn = new System.Windows.Forms.Button();
            this.delbtn = new System.Windows.Forms.Button();
            this.emplbl = new System.Windows.Forms.Label();
            this.operatorlbl = new System.Windows.Forms.Label();
            this.datetxt = new System.Windows.Forms.TextBox();
            this.datelbl = new System.Windows.Forms.Label();
            this.billidtxt = new System.Windows.Forms.TextBox();
            this.billidlbl = new System.Windows.Forms.Label();
            this.prntbtn = new System.Windows.Forms.Button();
            this.discardbtn = new System.Windows.Forms.Button();
            this.savebtn = new System.Windows.Forms.Button();
            this.newbtn = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.subtlbl = new System.Windows.Forms.Label();
            this.totlbl = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.numofitmtxt = new System.Windows.Forms.TextBox();
            this.pcstxt = new System.Windows.Forms.TextBox();
            this.numwrdtxt = new System.Windows.Forms.TextBox();
            this.inwrdlbl = new System.Windows.Forms.Label();
            this.pcslbl = new System.Windows.Forms.Label();
            this.tottxt = new System.Windows.Forms.TextBox();
            this.disctxt = new System.Windows.Forms.TextBox();
            this.subttxt = new System.Windows.Forms.TextBox();
            this.grtottxt = new System.Windows.Forms.TextBox();
            this.discrattxt = new System.Windows.Forms.TextBox();
            this.numofitmlbl = new System.Windows.Forms.Label();
            this.AdItemgrp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.itemdtdgv)).BeginInit();
            this.SuspendLayout();
            // 
            // previousbtn
            // 
            this.previousbtn.Location = new System.Drawing.Point(892, 46);
            this.previousbtn.Name = "previousbtn";
            this.previousbtn.Size = new System.Drawing.Size(75, 23);
            this.previousbtn.TabIndex = 95;
            this.previousbtn.Text = "Previous";
            this.previousbtn.UseVisualStyleBackColor = true;
            this.previousbtn.Click += new System.EventHandler(this.previousbtn_Click);
            // 
            // AdItemgrp
            // 
            this.AdItemgrp.Controls.Add(this.ratelbl);
            this.AdItemgrp.Controls.Add(this.qntylbl);
            this.AdItemgrp.Controls.Add(this.hsnlbl);
            this.AdItemgrp.Controls.Add(this.Descrplbl);
            this.AdItemgrp.Controls.Add(this.itmlbl);
            this.AdItemgrp.Controls.Add(this.addbtn);
            this.AdItemgrp.Controls.Add(this.ratetxt);
            this.AdItemgrp.Controls.Add(this.qntytxt);
            this.AdItemgrp.Controls.Add(this.hsntxt);
            this.AdItemgrp.Controls.Add(this.descrptxt);
            this.AdItemgrp.Controls.Add(this.itemcmbx);
            this.AdItemgrp.Location = new System.Drawing.Point(12, 157);
            this.AdItemgrp.Name = "AdItemgrp";
            this.AdItemgrp.Size = new System.Drawing.Size(1049, 69);
            this.AdItemgrp.TabIndex = 62;
            this.AdItemgrp.TabStop = false;
            this.AdItemgrp.Text = "Add Item";
            // 
            // ratelbl
            // 
            this.ratelbl.AutoSize = true;
            this.ratelbl.Location = new System.Drawing.Point(852, 20);
            this.ratelbl.Name = "ratelbl";
            this.ratelbl.Size = new System.Drawing.Size(30, 13);
            this.ratelbl.TabIndex = 7;
            this.ratelbl.Text = "Rate";
            // 
            // qntylbl
            // 
            this.qntylbl.AutoSize = true;
            this.qntylbl.Location = new System.Drawing.Point(746, 20);
            this.qntylbl.Name = "qntylbl";
            this.qntylbl.Size = new System.Drawing.Size(46, 13);
            this.qntylbl.TabIndex = 7;
            this.qntylbl.Text = "Quantity";
            // 
            // hsnlbl
            // 
            this.hsnlbl.AutoSize = true;
            this.hsnlbl.Location = new System.Drawing.Point(640, 20);
            this.hsnlbl.Name = "hsnlbl";
            this.hsnlbl.Size = new System.Drawing.Size(58, 13);
            this.hsnlbl.TabIndex = 7;
            this.hsnlbl.Text = "HSN Code";
            // 
            // Descrplbl
            // 
            this.Descrplbl.AutoSize = true;
            this.Descrplbl.Location = new System.Drawing.Point(130, 20);
            this.Descrplbl.Name = "Descrplbl";
            this.Descrplbl.Size = new System.Drawing.Size(60, 13);
            this.Descrplbl.TabIndex = 7;
            this.Descrplbl.Text = "Description";
            // 
            // itmlbl
            // 
            this.itmlbl.AutoSize = true;
            this.itmlbl.Location = new System.Drawing.Point(6, 20);
            this.itmlbl.Name = "itmlbl";
            this.itmlbl.Size = new System.Drawing.Size(47, 13);
            this.itmlbl.TabIndex = 7;
            this.itmlbl.Text = "Item No.";
            // 
            // addbtn
            // 
            this.addbtn.Location = new System.Drawing.Point(961, 39);
            this.addbtn.Name = "addbtn";
            this.addbtn.Size = new System.Drawing.Size(75, 23);
            this.addbtn.TabIndex = 6;
            this.addbtn.Text = "Add";
            this.addbtn.UseVisualStyleBackColor = true;
            this.addbtn.Click += new System.EventHandler(this.addbtn_Click);
            // 
            // ratetxt
            // 
            this.ratetxt.Location = new System.Drawing.Point(855, 41);
            this.ratetxt.Name = "ratetxt";
            this.ratetxt.Size = new System.Drawing.Size(100, 20);
            this.ratetxt.TabIndex = 5;
            // 
            // qntytxt
            // 
            this.qntytxt.Location = new System.Drawing.Point(749, 40);
            this.qntytxt.Name = "qntytxt";
            this.qntytxt.Size = new System.Drawing.Size(100, 20);
            this.qntytxt.TabIndex = 5;
            // 
            // hsntxt
            // 
            this.hsntxt.Location = new System.Drawing.Point(643, 41);
            this.hsntxt.Name = "hsntxt";
            this.hsntxt.Size = new System.Drawing.Size(100, 20);
            this.hsntxt.TabIndex = 5;
            // 
            // descrptxt
            // 
            this.descrptxt.Location = new System.Drawing.Point(133, 41);
            this.descrptxt.Name = "descrptxt";
            this.descrptxt.Size = new System.Drawing.Size(504, 20);
            this.descrptxt.TabIndex = 4;
            // 
            // itemcmbx
            // 
            this.itemcmbx.FormattingEnabled = true;
            this.itemcmbx.Location = new System.Drawing.Point(6, 41);
            this.itemcmbx.Name = "itemcmbx";
            this.itemcmbx.Size = new System.Drawing.Size(121, 21);
            this.itemcmbx.TabIndex = 3;
            this.itemcmbx.SelectedIndexChanged += new System.EventHandler(this.itemcmbx_SelectedIndexChanged_1);
            // 
            // comlbl
            // 
            this.comlbl.AutoSize = true;
            this.comlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comlbl.ForeColor = System.Drawing.Color.Maroon;
            this.comlbl.Location = new System.Drawing.Point(494, 9);
            this.comlbl.Name = "comlbl";
            this.comlbl.Size = new System.Drawing.Size(70, 25);
            this.comlbl.TabIndex = 61;
            this.comlbl.Text = "label2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 25);
            this.label1.TabIndex = 60;
            this.label1.Text = "M/s:";
            // 
            // suppliercmbx
            // 
            this.suppliercmbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.suppliercmbx.FormattingEnabled = true;
            this.suppliercmbx.Location = new System.Drawing.Point(73, 58);
            this.suppliercmbx.Name = "suppliercmbx";
            this.suppliercmbx.Size = new System.Drawing.Size(366, 33);
            this.suppliercmbx.TabIndex = 59;
            this.suppliercmbx.SelectedIndexChanged += new System.EventHandler(this.suppliercmbx_SelectedIndexChanged_1);
            // 
            // itemdtdgv
            // 
            this.itemdtdgv.AllowUserToAddRows = false;
            this.itemdtdgv.AllowUserToDeleteRows = false;
            this.itemdtdgv.AllowUserToResizeColumns = false;
            this.itemdtdgv.AllowUserToResizeRows = false;
            this.itemdtdgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.itemdtdgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.itemcol,
            this.Descriptcol,
            this.hsncol,
            this.qntycol,
            this.ratecol,
            this.amtcol});
            this.itemdtdgv.Location = new System.Drawing.Point(18, 273);
            this.itemdtdgv.Name = "itemdtdgv";
            this.itemdtdgv.RowHeadersVisible = false;
            this.itemdtdgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.itemdtdgv.Size = new System.Drawing.Size(1043, 294);
            this.itemdtdgv.TabIndex = 63;
            // 
            // itemcol
            // 
            this.itemcol.HeaderText = "Item No.";
            this.itemcol.Name = "itemcol";
            this.itemcol.Width = 125;
            // 
            // Descriptcol
            // 
            this.Descriptcol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Descriptcol.HeaderText = "Description";
            this.Descriptcol.Name = "Descriptcol";
            // 
            // hsncol
            // 
            this.hsncol.HeaderText = "HSN Code";
            this.hsncol.Name = "hsncol";
            // 
            // qntycol
            // 
            this.qntycol.HeaderText = "Quantity";
            this.qntycol.Name = "qntycol";
            // 
            // ratecol
            // 
            this.ratecol.HeaderText = "Rate";
            this.ratecol.Name = "ratecol";
            // 
            // amtcol
            // 
            this.amtcol.HeaderText = "Amount";
            this.amtcol.Name = "amtcol";
            // 
            // new_itemchbx
            // 
            this.new_itemchbx.AutoSize = true;
            this.new_itemchbx.Location = new System.Drawing.Point(18, 237);
            this.new_itemchbx.Name = "new_itemchbx";
            this.new_itemchbx.Size = new System.Drawing.Size(71, 17);
            this.new_itemchbx.TabIndex = 93;
            this.new_itemchbx.Text = "New Item";
            this.new_itemchbx.UseVisualStyleBackColor = true;
            this.new_itemchbx.CheckedChanged += new System.EventHandler(this.new_itemchbx_CheckedChanged_1);
            // 
            // Nextbtn
            // 
            this.Nextbtn.Location = new System.Drawing.Point(986, 46);
            this.Nextbtn.Name = "Nextbtn";
            this.Nextbtn.Size = new System.Drawing.Size(75, 23);
            this.Nextbtn.TabIndex = 94;
            this.Nextbtn.Text = "Next";
            this.Nextbtn.UseVisualStyleBackColor = true;
            this.Nextbtn.Click += new System.EventHandler(this.Nextbtn_Click);
            // 
            // delbtn
            // 
            this.delbtn.Location = new System.Drawing.Point(973, 229);
            this.delbtn.Name = "delbtn";
            this.delbtn.Size = new System.Drawing.Size(75, 23);
            this.delbtn.TabIndex = 92;
            this.delbtn.Text = "Delete";
            this.delbtn.UseVisualStyleBackColor = true;
            this.delbtn.Click += new System.EventHandler(this.delbtn_Click);
            // 
            // emplbl
            // 
            this.emplbl.AutoSize = true;
            this.emplbl.Location = new System.Drawing.Point(113, 660);
            this.emplbl.Name = "emplbl";
            this.emplbl.Size = new System.Drawing.Size(48, 13);
            this.emplbl.TabIndex = 91;
            this.emplbl.Text = "Authorlbl";
            // 
            // operatorlbl
            // 
            this.operatorlbl.AutoSize = true;
            this.operatorlbl.Location = new System.Drawing.Point(15, 660);
            this.operatorlbl.Name = "operatorlbl";
            this.operatorlbl.Size = new System.Drawing.Size(92, 13);
            this.operatorlbl.TabIndex = 90;
            this.operatorlbl.Text = "You Are Login As:";
            // 
            // datetxt
            // 
            this.datetxt.Location = new System.Drawing.Point(848, 135);
            this.datetxt.Name = "datetxt";
            this.datetxt.Size = new System.Drawing.Size(100, 20);
            this.datetxt.TabIndex = 88;
            // 
            // datelbl
            // 
            this.datelbl.AutoSize = true;
            this.datelbl.Location = new System.Drawing.Point(807, 138);
            this.datelbl.Name = "datelbl";
            this.datelbl.Size = new System.Drawing.Size(30, 13);
            this.datelbl.TabIndex = 86;
            this.datelbl.Text = "Date";
            // 
            // billidtxt
            // 
            this.billidtxt.Location = new System.Drawing.Point(848, 102);
            this.billidtxt.Name = "billidtxt";
            this.billidtxt.Size = new System.Drawing.Size(100, 20);
            this.billidtxt.TabIndex = 87;
            // 
            // billidlbl
            // 
            this.billidlbl.AutoSize = true;
            this.billidlbl.Location = new System.Drawing.Point(797, 105);
            this.billidlbl.Name = "billidlbl";
            this.billidlbl.Size = new System.Drawing.Size(40, 13);
            this.billidlbl.TabIndex = 85;
            this.billidlbl.Text = "Bill No.";
            // 
            // prntbtn
            // 
            this.prntbtn.Location = new System.Drawing.Point(986, 133);
            this.prntbtn.Name = "prntbtn";
            this.prntbtn.Size = new System.Drawing.Size(75, 23);
            this.prntbtn.TabIndex = 84;
            this.prntbtn.Text = "Print";
            this.prntbtn.UseVisualStyleBackColor = true;
            this.prntbtn.Click += new System.EventHandler(this.prntbtn_Click);
            // 
            // discardbtn
            // 
            this.discardbtn.Location = new System.Drawing.Point(986, 104);
            this.discardbtn.Name = "discardbtn";
            this.discardbtn.Size = new System.Drawing.Size(75, 23);
            this.discardbtn.TabIndex = 83;
            this.discardbtn.Text = "Discard";
            this.discardbtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.discardbtn.UseVisualStyleBackColor = true;
            this.discardbtn.Click += new System.EventHandler(this.discardbtn_Click);
            // 
            // savebtn
            // 
            this.savebtn.Location = new System.Drawing.Point(986, 75);
            this.savebtn.Name = "savebtn";
            this.savebtn.Size = new System.Drawing.Size(75, 23);
            this.savebtn.TabIndex = 82;
            this.savebtn.Text = "Save";
            this.savebtn.UseVisualStyleBackColor = true;
            this.savebtn.Click += new System.EventHandler(this.savebtn_Click);
            // 
            // newbtn
            // 
            this.newbtn.Location = new System.Drawing.Point(986, 46);
            this.newbtn.Name = "newbtn";
            this.newbtn.Size = new System.Drawing.Size(75, 23);
            this.newbtn.TabIndex = 81;
            this.newbtn.Text = "New";
            this.newbtn.UseVisualStyleBackColor = true;
            this.newbtn.Click += new System.EventHandler(this.newbtn_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(920, 629);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(31, 13);
            this.label11.TabIndex = 79;
            this.label11.Text = "Total";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(902, 602);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 13);
            this.label10.TabIndex = 78;
            this.label10.Text = "Discount";
            // 
            // subtlbl
            // 
            this.subtlbl.AutoSize = true;
            this.subtlbl.Location = new System.Drawing.Point(905, 576);
            this.subtlbl.Name = "subtlbl";
            this.subtlbl.Size = new System.Drawing.Size(46, 13);
            this.subtlbl.TabIndex = 77;
            this.subtlbl.Text = "Subtotal";
            // 
            // totlbl
            // 
            this.totlbl.AutoSize = true;
            this.totlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totlbl.Location = new System.Drawing.Point(14, 593);
            this.totlbl.Name = "totlbl";
            this.totlbl.Size = new System.Drawing.Size(115, 25);
            this.totlbl.TabIndex = 80;
            this.totlbl.Text = "Grand Total";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(689, 602);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(75, 13);
            this.label12.TabIndex = 76;
            this.label12.Text = "Discount Rate";
            // 
            // numofitmtxt
            // 
            this.numofitmtxt.Location = new System.Drawing.Point(561, 573);
            this.numofitmtxt.Name = "numofitmtxt";
            this.numofitmtxt.Size = new System.Drawing.Size(88, 20);
            this.numofitmtxt.TabIndex = 73;
            // 
            // pcstxt
            // 
            this.pcstxt.Location = new System.Drawing.Point(770, 573);
            this.pcstxt.Name = "pcstxt";
            this.pcstxt.Size = new System.Drawing.Size(88, 20);
            this.pcstxt.TabIndex = 67;
            // 
            // numwrdtxt
            // 
            this.numwrdtxt.Location = new System.Drawing.Point(69, 626);
            this.numwrdtxt.Name = "numwrdtxt";
            this.numwrdtxt.Size = new System.Drawing.Size(782, 20);
            this.numwrdtxt.TabIndex = 66;
            // 
            // inwrdlbl
            // 
            this.inwrdlbl.AutoSize = true;
            this.inwrdlbl.Location = new System.Drawing.Point(15, 629);
            this.inwrdlbl.Name = "inwrdlbl";
            this.inwrdlbl.Size = new System.Drawing.Size(48, 13);
            this.inwrdlbl.TabIndex = 65;
            this.inwrdlbl.Text = "In Word:";
            // 
            // pcslbl
            // 
            this.pcslbl.AutoSize = true;
            this.pcslbl.Location = new System.Drawing.Point(725, 576);
            this.pcslbl.Name = "pcslbl";
            this.pcslbl.Size = new System.Drawing.Size(39, 13);
            this.pcslbl.TabIndex = 75;
            this.pcslbl.Text = "Pieces";
            // 
            // tottxt
            // 
            this.tottxt.Location = new System.Drawing.Point(961, 626);
            this.tottxt.Name = "tottxt";
            this.tottxt.Size = new System.Drawing.Size(100, 20);
            this.tottxt.TabIndex = 72;
            // 
            // disctxt
            // 
            this.disctxt.Location = new System.Drawing.Point(961, 599);
            this.disctxt.Name = "disctxt";
            this.disctxt.Size = new System.Drawing.Size(100, 20);
            this.disctxt.TabIndex = 71;
            // 
            // subttxt
            // 
            this.subttxt.Location = new System.Drawing.Point(961, 573);
            this.subttxt.Name = "subttxt";
            this.subttxt.Size = new System.Drawing.Size(100, 20);
            this.subttxt.TabIndex = 70;
            // 
            // grtottxt
            // 
            this.grtottxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grtottxt.Location = new System.Drawing.Point(145, 590);
            this.grtottxt.Name = "grtottxt";
            this.grtottxt.Size = new System.Drawing.Size(144, 30);
            this.grtottxt.TabIndex = 69;
            // 
            // discrattxt
            // 
            this.discrattxt.Location = new System.Drawing.Point(770, 599);
            this.discrattxt.Name = "discrattxt";
            this.discrattxt.Size = new System.Drawing.Size(88, 20);
            this.discrattxt.TabIndex = 68;
            // 
            // numofitmlbl
            // 
            this.numofitmlbl.AutoSize = true;
            this.numofitmlbl.Location = new System.Drawing.Point(496, 576);
            this.numofitmlbl.Name = "numofitmlbl";
            this.numofitmlbl.Size = new System.Drawing.Size(59, 13);
            this.numofitmlbl.TabIndex = 74;
            this.numofitmlbl.Text = "No. of Item";
            // 
            // Purchase_challan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1081, 678);
            this.Controls.Add(this.previousbtn);
            this.Controls.Add(this.AdItemgrp);
            this.Controls.Add(this.comlbl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.suppliercmbx);
            this.Controls.Add(this.itemdtdgv);
            this.Controls.Add(this.new_itemchbx);
            this.Controls.Add(this.delbtn);
            this.Controls.Add(this.emplbl);
            this.Controls.Add(this.operatorlbl);
            this.Controls.Add(this.datetxt);
            this.Controls.Add(this.datelbl);
            this.Controls.Add(this.billidtxt);
            this.Controls.Add(this.billidlbl);
            this.Controls.Add(this.prntbtn);
            this.Controls.Add(this.discardbtn);
            this.Controls.Add(this.savebtn);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.subtlbl);
            this.Controls.Add(this.totlbl);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.numofitmtxt);
            this.Controls.Add(this.pcstxt);
            this.Controls.Add(this.numwrdtxt);
            this.Controls.Add(this.inwrdlbl);
            this.Controls.Add(this.pcslbl);
            this.Controls.Add(this.tottxt);
            this.Controls.Add(this.disctxt);
            this.Controls.Add(this.subttxt);
            this.Controls.Add(this.grtottxt);
            this.Controls.Add(this.discrattxt);
            this.Controls.Add(this.numofitmlbl);
            this.Controls.Add(this.Nextbtn);
            this.Controls.Add(this.newbtn);
            this.Name = "Purchase_challan";
            this.Text = "Purchase_challan";
            this.AdItemgrp.ResumeLayout(false);
            this.AdItemgrp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.itemdtdgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button previousbtn;
        private System.Windows.Forms.GroupBox AdItemgrp;
        private System.Windows.Forms.Label ratelbl;
        private System.Windows.Forms.Label qntylbl;
        private System.Windows.Forms.Label hsnlbl;
        private System.Windows.Forms.Label Descrplbl;
        private System.Windows.Forms.Label itmlbl;
        private System.Windows.Forms.Button addbtn;
        private System.Windows.Forms.TextBox ratetxt;
        private System.Windows.Forms.TextBox qntytxt;
        private System.Windows.Forms.TextBox hsntxt;
        private System.Windows.Forms.TextBox descrptxt;
        private System.Windows.Forms.ComboBox itemcmbx;
        private System.Windows.Forms.Label comlbl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox suppliercmbx;
        private System.Windows.Forms.DataGridView itemdtdgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemcol;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descriptcol;
        private System.Windows.Forms.DataGridViewTextBoxColumn hsncol;
        private System.Windows.Forms.DataGridViewTextBoxColumn qntycol;
        private System.Windows.Forms.DataGridViewTextBoxColumn ratecol;
        private System.Windows.Forms.DataGridViewTextBoxColumn amtcol;
        private System.Windows.Forms.CheckBox new_itemchbx;
        private System.Windows.Forms.Button Nextbtn;
        private System.Windows.Forms.Button delbtn;
        private System.Windows.Forms.Label emplbl;
        private System.Windows.Forms.Label operatorlbl;
        private System.Windows.Forms.TextBox datetxt;
        private System.Windows.Forms.Label datelbl;
        private System.Windows.Forms.TextBox billidtxt;
        private System.Windows.Forms.Label billidlbl;
        private System.Windows.Forms.Button prntbtn;
        private System.Windows.Forms.Button discardbtn;
        private System.Windows.Forms.Button savebtn;
        private System.Windows.Forms.Button newbtn;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label subtlbl;
        private System.Windows.Forms.Label totlbl;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox numofitmtxt;
        private System.Windows.Forms.TextBox pcstxt;
        private System.Windows.Forms.TextBox numwrdtxt;
        private System.Windows.Forms.Label inwrdlbl;
        private System.Windows.Forms.Label pcslbl;
        private System.Windows.Forms.TextBox tottxt;
        private System.Windows.Forms.TextBox disctxt;
        private System.Windows.Forms.TextBox subttxt;
        private System.Windows.Forms.TextBox grtottxt;
        private System.Windows.Forms.TextBox discrattxt;
        private System.Windows.Forms.Label numofitmlbl;
    }
}