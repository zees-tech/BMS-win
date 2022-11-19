namespace BMS
{
    partial class BillF
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
            this.txthsn = new System.Windows.Forms.TextBox();
            this.txtewaybill = new System.Windows.Forms.TextBox();
            this.cmbtransport = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtpaymentterm = new System.Windows.Forms.TextBox();
            this.packlbl = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtpackaging = new System.Windows.Forms.TextBox();
            this.txttransport_charge = new System.Windows.Forms.TextBox();
            this.txtrate = new System.Windows.Forms.TextBox();
            this.txtigst = new System.Windows.Forms.TextBox();
            this.CGSTlbl = new System.Windows.Forms.Label();
            this.txtttax = new System.Windows.Forms.TextBox();
            this.SGSTlbl = new System.Windows.Forms.Label();
            this.txtcgst = new System.Windows.Forms.TextBox();
            this.btnprevious = new System.Windows.Forms.Button();
            this.totaxlbl = new System.Windows.Forms.Label();
            this.btnadd = new System.Windows.Forms.Button();
            this.chbxnew_item = new System.Windows.Forms.CheckBox();
            this.itmlbl = new System.Windows.Forms.Label();
            this.txtqnty = new System.Windows.Forms.TextBox();
            this.txtsgst = new System.Windows.Forms.TextBox();
            this.hsnlbl = new System.Windows.Forms.Label();
            this.txtbillid = new System.Windows.Forms.TextBox();
            this.cmbitem = new System.Windows.Forms.ComboBox();
            this.lblhead = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbparty = new System.Windows.Forms.ComboBox();
            this.Descrplbl = new System.Windows.Forms.Label();
            this.itemcol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descriptcol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hsncol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qntycol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ratecol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amtcol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnNext = new System.Windows.Forms.Button();
            this.txtdescrp = new System.Windows.Forms.TextBox();
            this.dgvitemdt = new System.Windows.Forms.DataGridView();
            this.IGSTlbl = new System.Windows.Forms.Label();
            this.ewaybil_lbl = new System.Windows.Forms.Label();
            this.btndelete = new System.Windows.Forms.Button();
            this.lblauthor = new System.Windows.Forms.Label();
            this.operatorlbl = new System.Windows.Forms.Label();
            this.datelbl = new System.Windows.Forms.Label();
            this.billidlbl = new System.Windows.Forms.Label();
            this.btnprnt = new System.Windows.Forms.Button();
            this.btndiscard = new System.Windows.Forms.Button();
            this.btnsave = new System.Windows.Forms.Button();
            this.btnnew = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.subtlbl = new System.Windows.Forms.Label();
            this.totlbl = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.numofitmlbl = new System.Windows.Forms.Label();
            this.pcslbl = new System.Windows.Forms.Label();
            this.txttotal = new System.Windows.Forms.TextBox();
            this.txtdiscount = new System.Windows.Forms.TextBox();
            this.txtsubtotal = new System.Windows.Forms.TextBox();
            this.txtgrtotal = new System.Windows.Forms.TextBox();
            this.txtdiscrat = new System.Windows.Forms.TextBox();
            this.txtnumofitm = new System.Windows.Forms.TextBox();
            this.txtpcs = new System.Windows.Forms.TextBox();
            this.txtnumwrd = new System.Windows.Forms.TextBox();
            this.inwrdlbl = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.AdItemgrp = new System.Windows.Forms.GroupBox();
            this.ratelbl = new System.Windows.Forms.Label();
            this.qntylbl = new System.Windows.Forms.Label();
            this.date_ = new System.Windows.Forms.DateTimePicker();
            this.lblprerate = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvitemdt)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.AdItemgrp.SuspendLayout();
            this.SuspendLayout();
            // 
            // txthsn
            // 
            this.txthsn.Location = new System.Drawing.Point(901, 22);
            this.txthsn.Name = "txthsn";
            this.txthsn.Size = new System.Drawing.Size(100, 20);
            this.txthsn.TabIndex = 5;
            // 
            // txtewaybill
            // 
            this.txtewaybill.Location = new System.Drawing.Point(93, 95);
            this.txtewaybill.MaxLength = 16;
            this.txtewaybill.Name = "txtewaybill";
            this.txtewaybill.Size = new System.Drawing.Size(128, 20);
            this.txtewaybill.TabIndex = 117;
            this.txtewaybill.TabStop = false;
            this.txtewaybill.Text = "Not Generated";
            this.txtewaybill.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cmbtransport
            // 
            this.cmbtransport.FormattingEnabled = true;
            this.cmbtransport.Location = new System.Drawing.Point(486, 641);
            this.cmbtransport.Name = "cmbtransport";
            this.cmbtransport.Size = new System.Drawing.Size(121, 21);
            this.cmbtransport.TabIndex = 115;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(426, 644);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 113;
            this.label3.Text = "Transport";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(398, 618);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 114;
            this.label2.Text = "Payment Terms";
            // 
            // txtpaymentterm
            // 
            this.txtpaymentterm.Location = new System.Drawing.Point(486, 616);
            this.txtpaymentterm.Name = "txtpaymentterm";
            this.txtpaymentterm.Size = new System.Drawing.Size(121, 20);
            this.txtpaymentterm.TabIndex = 112;
            // 
            // packlbl
            // 
            this.packlbl.AutoSize = true;
            this.packlbl.Location = new System.Drawing.Point(1118, 643);
            this.packlbl.Name = "packlbl";
            this.packlbl.Size = new System.Drawing.Size(95, 13);
            this.packlbl.TabIndex = 110;
            this.packlbl.Text = "Packaging Charge";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1136, 669);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 111;
            this.label4.Text = "Tranport Charge";
            // 
            // txtpackaging
            // 
            this.txtpackaging.Location = new System.Drawing.Point(1226, 640);
            this.txtpackaging.Name = "txtpackaging";
            this.txtpackaging.Size = new System.Drawing.Size(100, 20);
            this.txtpackaging.TabIndex = 108;
            this.txtpackaging.Text = "0";
            this.txtpackaging.TextChanged += new System.EventHandler(this.txtpackaging_TextChanged);
            // 
            // txttransport_charge
            // 
            this.txttransport_charge.Location = new System.Drawing.Point(1226, 666);
            this.txttransport_charge.Name = "txttransport_charge";
            this.txttransport_charge.Size = new System.Drawing.Size(100, 20);
            this.txttransport_charge.TabIndex = 109;
            this.txttransport_charge.Text = "0";
            this.txttransport_charge.TextChanged += new System.EventHandler(this.txttransport_charge_TextChanged);
            // 
            // txtrate
            // 
            this.txtrate.Location = new System.Drawing.Point(1113, 22);
            this.txtrate.Name = "txtrate";
            this.txtrate.Size = new System.Drawing.Size(100, 20);
            this.txtrate.TabIndex = 5;
            this.txtrate.Text = "0";
            // 
            // txtigst
            // 
            this.txtigst.Location = new System.Drawing.Point(239, 15);
            this.txtigst.Name = "txtigst";
            this.txtigst.Size = new System.Drawing.Size(100, 20);
            this.txtigst.TabIndex = 10;
            this.txtigst.Text = "0";
            // 
            // CGSTlbl
            // 
            this.CGSTlbl.AutoSize = true;
            this.CGSTlbl.Location = new System.Drawing.Point(12, 45);
            this.CGSTlbl.Name = "CGSTlbl";
            this.CGSTlbl.Size = new System.Drawing.Size(36, 13);
            this.CGSTlbl.TabIndex = 9;
            this.CGSTlbl.Text = "CGST";
            // 
            // txtttax
            // 
            this.txtttax.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtttax.Location = new System.Drawing.Point(239, 42);
            this.txtttax.Name = "txtttax";
            this.txtttax.Size = new System.Drawing.Size(100, 20);
            this.txtttax.TabIndex = 10;
            this.txtttax.Text = "0";
            // 
            // SGSTlbl
            // 
            this.SGSTlbl.AutoSize = true;
            this.SGSTlbl.Location = new System.Drawing.Point(12, 18);
            this.SGSTlbl.Name = "SGSTlbl";
            this.SGSTlbl.Size = new System.Drawing.Size(36, 13);
            this.SGSTlbl.TabIndex = 9;
            this.SGSTlbl.Text = "SGST";
            // 
            // txtcgst
            // 
            this.txtcgst.Location = new System.Drawing.Point(54, 42);
            this.txtcgst.Name = "txtcgst";
            this.txtcgst.Size = new System.Drawing.Size(100, 20);
            this.txtcgst.TabIndex = 10;
            this.txtcgst.Text = "0";
            // 
            // btnprevious
            // 
            this.btnprevious.Location = new System.Drawing.Point(1171, 11);
            this.btnprevious.Name = "btnprevious";
            this.btnprevious.Size = new System.Drawing.Size(75, 23);
            this.btnprevious.TabIndex = 107;
            this.btnprevious.Text = "Previous";
            this.btnprevious.UseVisualStyleBackColor = true;
            this.btnprevious.Click += new System.EventHandler(this.btnprevious_Click);
            // 
            // totaxlbl
            // 
            this.totaxlbl.AutoSize = true;
            this.totaxlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totaxlbl.Location = new System.Drawing.Point(158, 45);
            this.totaxlbl.Name = "totaxlbl";
            this.totaxlbl.Size = new System.Drawing.Size(75, 13);
            this.totaxlbl.TabIndex = 9;
            this.totaxlbl.Text = "TOTAL TAX";
            // 
            // btnadd
            // 
            this.btnadd.Location = new System.Drawing.Point(1236, 18);
            this.btnadd.Name = "btnadd";
            this.btnadd.Size = new System.Drawing.Size(75, 23);
            this.btnadd.TabIndex = 6;
            this.btnadd.Text = "Add";
            this.btnadd.UseVisualStyleBackColor = true;
            this.btnadd.Click += new System.EventHandler(this.btnadd_Click);
            // 
            // chbxnew_item
            // 
            this.chbxnew_item.AutoSize = true;
            this.chbxnew_item.Location = new System.Drawing.Point(20, 216);
            this.chbxnew_item.Name = "chbxnew_item";
            this.chbxnew_item.Size = new System.Drawing.Size(71, 17);
            this.chbxnew_item.TabIndex = 105;
            this.chbxnew_item.Text = "New Item";
            this.chbxnew_item.UseVisualStyleBackColor = true;
            this.chbxnew_item.CheckedChanged += new System.EventHandler(this.chbxnew_item_CheckedChanged);
            // 
            // itmlbl
            // 
            this.itmlbl.AutoSize = true;
            this.itmlbl.Location = new System.Drawing.Point(6, 1);
            this.itmlbl.Name = "itmlbl";
            this.itmlbl.Size = new System.Drawing.Size(47, 13);
            this.itmlbl.TabIndex = 7;
            this.itmlbl.Text = "Item No.";
            // 
            // txtqnty
            // 
            this.txtqnty.Location = new System.Drawing.Point(1007, 21);
            this.txtqnty.Name = "txtqnty";
            this.txtqnty.Size = new System.Drawing.Size(100, 20);
            this.txtqnty.TabIndex = 5;
            this.txtqnty.Text = "0";
            // 
            // txtsgst
            // 
            this.txtsgst.Location = new System.Drawing.Point(54, 15);
            this.txtsgst.Name = "txtsgst";
            this.txtsgst.Size = new System.Drawing.Size(100, 20);
            this.txtsgst.TabIndex = 10;
            this.txtsgst.Text = "0";
            // 
            // hsnlbl
            // 
            this.hsnlbl.AutoSize = true;
            this.hsnlbl.Location = new System.Drawing.Point(898, 1);
            this.hsnlbl.Name = "hsnlbl";
            this.hsnlbl.Size = new System.Drawing.Size(58, 13);
            this.hsnlbl.TabIndex = 7;
            this.hsnlbl.Text = "HSN Code";
            // 
            // txtbillid
            // 
            this.txtbillid.Location = new System.Drawing.Point(1126, 66);
            this.txtbillid.Name = "txtbillid";
            this.txtbillid.Size = new System.Drawing.Size(100, 20);
            this.txtbillid.TabIndex = 99;
            this.txtbillid.Text = "#####";
            // 
            // cmbitem
            // 
            this.cmbitem.FormattingEnabled = true;
            this.cmbitem.Location = new System.Drawing.Point(6, 22);
            this.cmbitem.Name = "cmbitem";
            this.cmbitem.Size = new System.Drawing.Size(121, 21);
            this.cmbitem.TabIndex = 3;
            this.cmbitem.SelectedIndexChanged += new System.EventHandler(this.cmbitem_SelectedIndexChanged);
            // 
            // lblhead
            // 
            this.lblhead.AutoSize = true;
            this.lblhead.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblhead.ForeColor = System.Drawing.Color.Maroon;
            this.lblhead.Location = new System.Drawing.Point(675, 3);
            this.lblhead.Name = "lblhead";
            this.lblhead.Size = new System.Drawing.Size(84, 25);
            this.lblhead.TabIndex = 73;
            this.lblhead.Text = "Tax Bill";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 25);
            this.label1.TabIndex = 72;
            this.label1.Text = "M/s:";
            // 
            // cmbparty
            // 
            this.cmbparty.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbparty.FormattingEnabled = true;
            this.cmbparty.Location = new System.Drawing.Point(75, 37);
            this.cmbparty.Name = "cmbparty";
            this.cmbparty.Size = new System.Drawing.Size(536, 33);
            this.cmbparty.TabIndex = 71;
            this.cmbparty.SelectedIndexChanged += new System.EventHandler(this.cmbparty_SelectedIndexChanged);
            // 
            // Descrplbl
            // 
            this.Descrplbl.AutoSize = true;
            this.Descrplbl.Location = new System.Drawing.Point(130, 1);
            this.Descrplbl.Name = "Descrplbl";
            this.Descrplbl.Size = new System.Drawing.Size(60, 13);
            this.Descrplbl.TabIndex = 7;
            this.Descrplbl.Text = "Description";
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
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(1265, 11);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 106;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // txtdescrp
            // 
            this.txtdescrp.Location = new System.Drawing.Point(133, 22);
            this.txtdescrp.Name = "txtdescrp";
            this.txtdescrp.Size = new System.Drawing.Size(757, 20);
            this.txtdescrp.TabIndex = 4;
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
            this.Descriptcol,
            this.hsncol,
            this.qntycol,
            this.ratecol,
            this.amtcol});
            this.dgvitemdt.Location = new System.Drawing.Point(20, 252);
            this.dgvitemdt.Name = "dgvitemdt";
            this.dgvitemdt.RowHeadersVisible = false;
            this.dgvitemdt.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvitemdt.Size = new System.Drawing.Size(1305, 294);
            this.dgvitemdt.TabIndex = 75;
            // 
            // IGSTlbl
            // 
            this.IGSTlbl.AutoSize = true;
            this.IGSTlbl.Location = new System.Drawing.Point(201, 18);
            this.IGSTlbl.Name = "IGSTlbl";
            this.IGSTlbl.Size = new System.Drawing.Size(32, 13);
            this.IGSTlbl.TabIndex = 9;
            this.IGSTlbl.Text = "IGST";
            // 
            // ewaybil_lbl
            // 
            this.ewaybil_lbl.AutoSize = true;
            this.ewaybil_lbl.Location = new System.Drawing.Point(18, 98);
            this.ewaybil_lbl.Name = "ewaybil_lbl";
            this.ewaybil_lbl.Size = new System.Drawing.Size(69, 13);
            this.ewaybil_lbl.TabIndex = 116;
            this.ewaybil_lbl.Text = "Eway Bill No.";
            // 
            // btndelete
            // 
            this.btndelete.Location = new System.Drawing.Point(1250, 216);
            this.btndelete.Name = "btndelete";
            this.btndelete.Size = new System.Drawing.Size(75, 23);
            this.btndelete.TabIndex = 104;
            this.btndelete.Text = "Delete";
            this.btndelete.UseVisualStyleBackColor = true;
            this.btndelete.Click += new System.EventHandler(this.btndelete_Click);
            // 
            // lblauthor
            // 
            this.lblauthor.AutoSize = true;
            this.lblauthor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblauthor.Location = new System.Drawing.Point(115, 690);
            this.lblauthor.Name = "lblauthor";
            this.lblauthor.Size = new System.Drawing.Size(48, 13);
            this.lblauthor.TabIndex = 103;
            this.lblauthor.Text = "Authorlbl";
            // 
            // operatorlbl
            // 
            this.operatorlbl.AutoSize = true;
            this.operatorlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.operatorlbl.Location = new System.Drawing.Point(17, 690);
            this.operatorlbl.Name = "operatorlbl";
            this.operatorlbl.Size = new System.Drawing.Size(92, 13);
            this.operatorlbl.TabIndex = 102;
            this.operatorlbl.Text = "You Are Login As:";
            // 
            // datelbl
            // 
            this.datelbl.AutoSize = true;
            this.datelbl.Location = new System.Drawing.Point(1086, 103);
            this.datelbl.Name = "datelbl";
            this.datelbl.Size = new System.Drawing.Size(30, 13);
            this.datelbl.TabIndex = 98;
            this.datelbl.Text = "Date";
            // 
            // billidlbl
            // 
            this.billidlbl.AutoSize = true;
            this.billidlbl.Location = new System.Drawing.Point(1076, 70);
            this.billidlbl.Name = "billidlbl";
            this.billidlbl.Size = new System.Drawing.Size(40, 13);
            this.billidlbl.TabIndex = 97;
            this.billidlbl.Text = "Bill No.";
            // 
            // btnprnt
            // 
            this.btnprnt.Location = new System.Drawing.Point(1265, 98);
            this.btnprnt.Name = "btnprnt";
            this.btnprnt.Size = new System.Drawing.Size(75, 23);
            this.btnprnt.TabIndex = 96;
            this.btnprnt.Text = "Print";
            this.btnprnt.UseVisualStyleBackColor = true;
            this.btnprnt.Click += new System.EventHandler(this.btnprnt_Click);
            // 
            // btndiscard
            // 
            this.btndiscard.Location = new System.Drawing.Point(1265, 69);
            this.btndiscard.Name = "btndiscard";
            this.btndiscard.Size = new System.Drawing.Size(75, 23);
            this.btndiscard.TabIndex = 95;
            this.btndiscard.Text = "Discard";
            this.btndiscard.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btndiscard.UseVisualStyleBackColor = true;
            this.btndiscard.Click += new System.EventHandler(this.btndiscard_Click);
            // 
            // btnsave
            // 
            this.btnsave.Location = new System.Drawing.Point(1265, 40);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(75, 23);
            this.btnsave.TabIndex = 94;
            this.btnsave.Text = "Save";
            this.btnsave.UseVisualStyleBackColor = true;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // btnnew
            // 
            this.btnnew.Location = new System.Drawing.Point(1265, 11);
            this.btnnew.Name = "btnnew";
            this.btnnew.Size = new System.Drawing.Size(75, 23);
            this.btnnew.TabIndex = 93;
            this.btnnew.Text = "New";
            this.btnnew.UseVisualStyleBackColor = true;
            this.btnnew.Click += new System.EventHandler(this.btnnew_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(1186, 616);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(31, 13);
            this.label11.TabIndex = 91;
            this.label11.Text = "Total";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(1168, 588);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 13);
            this.label10.TabIndex = 90;
            this.label10.Text = "Discount";
            // 
            // subtlbl
            // 
            this.subtlbl.AutoSize = true;
            this.subtlbl.Location = new System.Drawing.Point(1170, 562);
            this.subtlbl.Name = "subtlbl";
            this.subtlbl.Size = new System.Drawing.Size(46, 13);
            this.subtlbl.TabIndex = 89;
            this.subtlbl.Text = "Subtotal";
            // 
            // totlbl
            // 
            this.totlbl.AutoSize = true;
            this.totlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totlbl.Location = new System.Drawing.Point(665, 647);
            this.totlbl.Name = "totlbl";
            this.totlbl.Size = new System.Drawing.Size(196, 39);
            this.totlbl.TabIndex = 92;
            this.totlbl.Text = "Grand Total";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(922, 588);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(75, 13);
            this.label12.TabIndex = 88;
            this.label12.Text = "Discount Rate";
            // 
            // numofitmlbl
            // 
            this.numofitmlbl.AutoSize = true;
            this.numofitmlbl.Location = new System.Drawing.Point(421, 592);
            this.numofitmlbl.Name = "numofitmlbl";
            this.numofitmlbl.Size = new System.Drawing.Size(59, 13);
            this.numofitmlbl.TabIndex = 86;
            this.numofitmlbl.Text = "No. of Item";
            // 
            // pcslbl
            // 
            this.pcslbl.AutoSize = true;
            this.pcslbl.Location = new System.Drawing.Point(958, 562);
            this.pcslbl.Name = "pcslbl";
            this.pcslbl.Size = new System.Drawing.Size(39, 13);
            this.pcslbl.TabIndex = 87;
            this.pcslbl.Text = "Pieces";
            // 
            // txttotal
            // 
            this.txttotal.Location = new System.Drawing.Point(1226, 613);
            this.txttotal.Name = "txttotal";
            this.txttotal.Size = new System.Drawing.Size(100, 20);
            this.txttotal.TabIndex = 84;
            this.txttotal.Text = "0";
            // 
            // txtdiscount
            // 
            this.txtdiscount.Location = new System.Drawing.Point(1226, 586);
            this.txtdiscount.Name = "txtdiscount";
            this.txtdiscount.Size = new System.Drawing.Size(100, 20);
            this.txtdiscount.TabIndex = 83;
            this.txtdiscount.Text = "0";
            // 
            // txtsubtotal
            // 
            this.txtsubtotal.Location = new System.Drawing.Point(1226, 560);
            this.txtsubtotal.Name = "txtsubtotal";
            this.txtsubtotal.Size = new System.Drawing.Size(100, 20);
            this.txtsubtotal.TabIndex = 82;
            this.txtsubtotal.Text = "0";
            // 
            // txtgrtotal
            // 
            this.txtgrtotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtgrtotal.Location = new System.Drawing.Point(863, 644);
            this.txtgrtotal.Name = "txtgrtotal";
            this.txtgrtotal.Size = new System.Drawing.Size(144, 45);
            this.txtgrtotal.TabIndex = 81;
            this.txtgrtotal.Text = "0";
            // 
            // txtdiscrat
            // 
            this.txtdiscrat.Location = new System.Drawing.Point(1002, 586);
            this.txtdiscrat.Name = "txtdiscrat";
            this.txtdiscrat.Size = new System.Drawing.Size(88, 20);
            this.txtdiscrat.TabIndex = 80;
            this.txtdiscrat.Text = "0";
            this.txtdiscrat.TextChanged += new System.EventHandler(this.txtdiscrat_TextChanged);
            // 
            // txtnumofitm
            // 
            this.txtnumofitm.Location = new System.Drawing.Point(486, 590);
            this.txtnumofitm.Name = "txtnumofitm";
            this.txtnumofitm.Size = new System.Drawing.Size(88, 20);
            this.txtnumofitm.TabIndex = 85;
            this.txtnumofitm.Text = "0";
            // 
            // txtpcs
            // 
            this.txtpcs.Location = new System.Drawing.Point(1002, 560);
            this.txtpcs.Name = "txtpcs";
            this.txtpcs.Size = new System.Drawing.Size(88, 20);
            this.txtpcs.TabIndex = 79;
            this.txtpcs.Text = "0";
            // 
            // txtnumwrd
            // 
            this.txtnumwrd.Location = new System.Drawing.Point(75, 559);
            this.txtnumwrd.Name = "txtnumwrd";
            this.txtnumwrd.Size = new System.Drawing.Size(782, 20);
            this.txtnumwrd.TabIndex = 78;
            // 
            // inwrdlbl
            // 
            this.inwrdlbl.AutoSize = true;
            this.inwrdlbl.Location = new System.Drawing.Point(21, 562);
            this.inwrdlbl.Name = "inwrdlbl";
            this.inwrdlbl.Size = new System.Drawing.Size(48, 13);
            this.inwrdlbl.TabIndex = 77;
            this.inwrdlbl.Text = "In Word:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtigst);
            this.groupBox1.Controls.Add(this.CGSTlbl);
            this.groupBox1.Controls.Add(this.txtttax);
            this.groupBox1.Controls.Add(this.SGSTlbl);
            this.groupBox1.Controls.Add(this.txtcgst);
            this.groupBox1.Controls.Add(this.txtsgst);
            this.groupBox1.Controls.Add(this.totaxlbl);
            this.groupBox1.Controls.Add(this.IGSTlbl);
            this.groupBox1.Location = new System.Drawing.Point(20, 589);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(357, 73);
            this.groupBox1.TabIndex = 76;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tax Details";
            // 
            // AdItemgrp
            // 
            this.AdItemgrp.Controls.Add(this.ratelbl);
            this.AdItemgrp.Controls.Add(this.qntylbl);
            this.AdItemgrp.Controls.Add(this.hsnlbl);
            this.AdItemgrp.Controls.Add(this.Descrplbl);
            this.AdItemgrp.Controls.Add(this.itmlbl);
            this.AdItemgrp.Controls.Add(this.btnadd);
            this.AdItemgrp.Controls.Add(this.txtrate);
            this.AdItemgrp.Controls.Add(this.txtqnty);
            this.AdItemgrp.Controls.Add(this.txthsn);
            this.AdItemgrp.Controls.Add(this.txtdescrp);
            this.AdItemgrp.Controls.Add(this.cmbitem);
            this.AdItemgrp.Location = new System.Drawing.Point(14, 136);
            this.AdItemgrp.Name = "AdItemgrp";
            this.AdItemgrp.Size = new System.Drawing.Size(1326, 69);
            this.AdItemgrp.TabIndex = 74;
            this.AdItemgrp.TabStop = false;
            this.AdItemgrp.Text = "Add Item";
            // 
            // ratelbl
            // 
            this.ratelbl.AutoSize = true;
            this.ratelbl.Location = new System.Drawing.Point(1110, 1);
            this.ratelbl.Name = "ratelbl";
            this.ratelbl.Size = new System.Drawing.Size(30, 13);
            this.ratelbl.TabIndex = 7;
            this.ratelbl.Text = "Rate";
            // 
            // qntylbl
            // 
            this.qntylbl.AutoSize = true;
            this.qntylbl.Location = new System.Drawing.Point(1004, 1);
            this.qntylbl.Name = "qntylbl";
            this.qntylbl.Size = new System.Drawing.Size(46, 13);
            this.qntylbl.TabIndex = 7;
            this.qntylbl.Text = "Quantity";
            // 
            // date_
            // 
            this.date_.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.date_.Location = new System.Drawing.Point(1126, 98);
            this.date_.Name = "date_";
            this.date_.Size = new System.Drawing.Size(101, 20);
            this.date_.TabIndex = 118;
            // 
            // lblprerate
            // 
            this.lblprerate.AutoSize = true;
            this.lblprerate.Location = new System.Drawing.Point(1134, 217);
            this.lblprerate.Name = "lblprerate";
            this.lblprerate.Size = new System.Drawing.Size(0, 13);
            this.lblprerate.TabIndex = 119;
            // 
            // BillF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1354, 709);
            this.Controls.Add(this.lblprerate);
            this.Controls.Add(this.date_);
            this.Controls.Add(this.txtewaybill);
            this.Controls.Add(this.cmbtransport);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtpaymentterm);
            this.Controls.Add(this.packlbl);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtpackaging);
            this.Controls.Add(this.txttransport_charge);
            this.Controls.Add(this.btnprevious);
            this.Controls.Add(this.chbxnew_item);
            this.Controls.Add(this.txtbillid);
            this.Controls.Add(this.lblhead);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbparty);
            this.Controls.Add(this.dgvitemdt);
            this.Controls.Add(this.ewaybil_lbl);
            this.Controls.Add(this.btndelete);
            this.Controls.Add(this.lblauthor);
            this.Controls.Add(this.operatorlbl);
            this.Controls.Add(this.datelbl);
            this.Controls.Add(this.billidlbl);
            this.Controls.Add(this.btnprnt);
            this.Controls.Add(this.btndiscard);
            this.Controls.Add(this.btnsave);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.subtlbl);
            this.Controls.Add(this.totlbl);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.numofitmlbl);
            this.Controls.Add(this.pcslbl);
            this.Controls.Add(this.txttotal);
            this.Controls.Add(this.txtdiscount);
            this.Controls.Add(this.txtsubtotal);
            this.Controls.Add(this.txtgrtotal);
            this.Controls.Add(this.txtdiscrat);
            this.Controls.Add(this.txtnumofitm);
            this.Controls.Add(this.txtpcs);
            this.Controls.Add(this.txtnumwrd);
            this.Controls.Add(this.inwrdlbl);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.AdItemgrp);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnnew);
            this.Name = "BillF";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Bill";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dgvitemdt)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.AdItemgrp.ResumeLayout(false);
            this.AdItemgrp.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txthsn;
        private System.Windows.Forms.TextBox txtewaybill;
        private System.Windows.Forms.ComboBox cmbtransport;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtpaymentterm;
        private System.Windows.Forms.Label packlbl;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtpackaging;
        private System.Windows.Forms.TextBox txttransport_charge;
        private System.Windows.Forms.TextBox txtrate;
        private System.Windows.Forms.TextBox txtigst;
        private System.Windows.Forms.Label CGSTlbl;
        private System.Windows.Forms.TextBox txtttax;
        private System.Windows.Forms.Label SGSTlbl;
        private System.Windows.Forms.TextBox txtcgst;
        private System.Windows.Forms.Button btnprevious;
        private System.Windows.Forms.Label totaxlbl;
        private System.Windows.Forms.Button btnadd;
        private System.Windows.Forms.CheckBox chbxnew_item;
        private System.Windows.Forms.Label itmlbl;
        private System.Windows.Forms.TextBox txtqnty;
        private System.Windows.Forms.TextBox txtsgst;
        private System.Windows.Forms.Label hsnlbl;
        private System.Windows.Forms.TextBox txtbillid;
        private System.Windows.Forms.ComboBox cmbitem;
        private System.Windows.Forms.Label lblhead;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbparty;
        private System.Windows.Forms.Label Descrplbl;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemcol;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descriptcol;
        private System.Windows.Forms.DataGridViewTextBoxColumn hsncol;
        private System.Windows.Forms.DataGridViewTextBoxColumn qntycol;
        private System.Windows.Forms.DataGridViewTextBoxColumn ratecol;
        private System.Windows.Forms.DataGridViewTextBoxColumn amtcol;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.TextBox txtdescrp;
        private System.Windows.Forms.DataGridView dgvitemdt;
        private System.Windows.Forms.Label IGSTlbl;
        private System.Windows.Forms.Label ewaybil_lbl;
        private System.Windows.Forms.Button btndelete;
        private System.Windows.Forms.Label lblauthor;
        private System.Windows.Forms.Label operatorlbl;
        private System.Windows.Forms.Label datelbl;
        private System.Windows.Forms.Label billidlbl;
        private System.Windows.Forms.Button btnprnt;
        private System.Windows.Forms.Button btndiscard;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.Button btnnew;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label subtlbl;
        private System.Windows.Forms.Label totlbl;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label numofitmlbl;
        private System.Windows.Forms.Label pcslbl;
        private System.Windows.Forms.TextBox txttotal;
        private System.Windows.Forms.TextBox txtdiscount;
        private System.Windows.Forms.TextBox txtsubtotal;
        private System.Windows.Forms.TextBox txtgrtotal;
        private System.Windows.Forms.TextBox txtdiscrat;
        private System.Windows.Forms.TextBox txtnumofitm;
        private System.Windows.Forms.TextBox txtpcs;
        private System.Windows.Forms.TextBox txtnumwrd;
        private System.Windows.Forms.Label inwrdlbl;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox AdItemgrp;
        private System.Windows.Forms.Label ratelbl;
        private System.Windows.Forms.Label qntylbl;
        private System.Windows.Forms.DateTimePicker date_;
        private System.Windows.Forms.Label lblprerate;
    }
}