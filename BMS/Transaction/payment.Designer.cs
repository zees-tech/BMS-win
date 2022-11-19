namespace BMS
{
    partial class payment
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
            this.partycmbx = new System.Windows.Forms.ComboBox();
            this.inwordtxt = new System.Windows.Forms.TextBox();
            this.receipttxt = new System.Windows.Forms.TextBox();
            this.amttxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Amount = new System.Windows.Forms.Label();
            this.partylbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.newbtn = new System.Windows.Forms.Button();
            this.prntbtn = new System.Windows.Forms.Button();
            this.Discardbtn = new System.Windows.Forms.Button();
            this.Savebtn = new System.Windows.Forms.Button();
            this.banktxt = new System.Windows.Forms.TextBox();
            this.transidtxt = new System.Windows.Forms.TextBox();
            this.transamttxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.transIDlbl = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.trans_date = new System.Windows.Forms.DateTimePicker();
            this.dgvcheque = new System.Windows.Forms.DataGridView();
            this.date_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.transID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deletebtn = new System.Windows.Forms.Button();
            this.addbtn = new System.Windows.Forms.Button();
            this.emplbl = new System.Windows.Forms.Label();
            this.operatorlbl = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.datetxt = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.referencetxt = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvcheque)).BeginInit();
            this.SuspendLayout();
            // 
            // partycmbx
            // 
            this.partycmbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.partycmbx.FormattingEnabled = true;
            this.partycmbx.Location = new System.Drawing.Point(96, 50);
            this.partycmbx.Name = "partycmbx";
            this.partycmbx.Size = new System.Drawing.Size(306, 33);
            this.partycmbx.TabIndex = 20;
            // 
            // inwordtxt
            // 
            this.inwordtxt.Location = new System.Drawing.Point(96, 322);
            this.inwordtxt.Name = "inwordtxt";
            this.inwordtxt.Size = new System.Drawing.Size(595, 20);
            this.inwordtxt.TabIndex = 16;
            // 
            // receipttxt
            // 
            this.receipttxt.Location = new System.Drawing.Point(590, 98);
            this.receipttxt.Name = "receipttxt";
            this.receipttxt.Size = new System.Drawing.Size(101, 20);
            this.receipttxt.TabIndex = 18;
            this.receipttxt.Text = "#####";
            this.receipttxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // amttxt
            // 
            this.amttxt.Location = new System.Drawing.Point(96, 296);
            this.amttxt.Name = "amttxt";
            this.amttxt.Size = new System.Drawing.Size(152, 20);
            this.amttxt.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(528, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Receipt Id";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(45, 325);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "In Word";
            // 
            // Amount
            // 
            this.Amount.AutoSize = true;
            this.Amount.Location = new System.Drawing.Point(47, 299);
            this.Amount.Name = "Amount";
            this.Amount.Size = new System.Drawing.Size(43, 13);
            this.Amount.TabIndex = 13;
            this.Amount.Text = "Amount";
            // 
            // partylbl
            // 
            this.partylbl.AutoSize = true;
            this.partylbl.Enabled = false;
            this.partylbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.partylbl.Location = new System.Drawing.Point(20, 53);
            this.partylbl.Name = "partylbl";
            this.partylbl.Size = new System.Drawing.Size(70, 25);
            this.partylbl.TabIndex = 14;
            this.partylbl.Text = "label1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(285, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 17);
            this.label1.TabIndex = 15;
            this.label1.Text = "Payment Memo";
            // 
            // newbtn
            // 
            this.newbtn.Location = new System.Drawing.Point(616, 43);
            this.newbtn.Name = "newbtn";
            this.newbtn.Size = new System.Drawing.Size(75, 23);
            this.newbtn.TabIndex = 6;
            this.newbtn.Text = "New";
            this.newbtn.UseVisualStyleBackColor = true;
            this.newbtn.Click += new System.EventHandler(this.newbtn_Click);
            // 
            // prntbtn
            // 
            this.prntbtn.Location = new System.Drawing.Point(616, 14);
            this.prntbtn.Name = "prntbtn";
            this.prntbtn.Size = new System.Drawing.Size(75, 23);
            this.prntbtn.TabIndex = 7;
            this.prntbtn.Text = "Print";
            this.prntbtn.UseVisualStyleBackColor = true;
            this.prntbtn.Click += new System.EventHandler(this.prntbtn_Click);
            // 
            // Discardbtn
            // 
            this.Discardbtn.Location = new System.Drawing.Point(557, 293);
            this.Discardbtn.Name = "Discardbtn";
            this.Discardbtn.Size = new System.Drawing.Size(66, 23);
            this.Discardbtn.TabIndex = 8;
            this.Discardbtn.Text = "Discard";
            this.Discardbtn.UseVisualStyleBackColor = true;
            this.Discardbtn.Click += new System.EventHandler(this.Discardbtn_Click);
            // 
            // Savebtn
            // 
            this.Savebtn.Location = new System.Drawing.Point(629, 293);
            this.Savebtn.Name = "Savebtn";
            this.Savebtn.Size = new System.Drawing.Size(62, 23);
            this.Savebtn.TabIndex = 9;
            this.Savebtn.Text = "Save";
            this.Savebtn.UseVisualStyleBackColor = true;
            this.Savebtn.Click += new System.EventHandler(this.Savebtn_Click);
            // 
            // banktxt
            // 
            this.banktxt.Location = new System.Drawing.Point(222, 124);
            this.banktxt.Name = "banktxt";
            this.banktxt.Size = new System.Drawing.Size(100, 20);
            this.banktxt.TabIndex = 21;
            // 
            // transidtxt
            // 
            this.transidtxt.Location = new System.Drawing.Point(328, 124);
            this.transidtxt.Name = "transidtxt";
            this.transidtxt.Size = new System.Drawing.Size(100, 20);
            this.transidtxt.TabIndex = 21;
            // 
            // transamttxt
            // 
            this.transamttxt.Location = new System.Drawing.Point(434, 124);
            this.transamttxt.Name = "transamttxt";
            this.transamttxt.Size = new System.Drawing.Size(100, 20);
            this.transamttxt.TabIndex = 21;
            this.transamttxt.TextChanged += new System.EventHandler(this.transamttxt_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(128, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Date";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(244, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Bank";
            // 
            // transIDlbl
            // 
            this.transIDlbl.AutoSize = true;
            this.transIDlbl.Location = new System.Drawing.Point(350, 108);
            this.transIDlbl.Name = "transIDlbl";
            this.transIDlbl.Size = new System.Drawing.Size(48, 13);
            this.transIDlbl.TabIndex = 11;
            this.transIDlbl.Text = "Trans ID";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(456, 108);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Amount";
            // 
            // trans_date
            // 
            this.trans_date.Location = new System.Drawing.Point(96, 124);
            this.trans_date.Name = "trans_date";
            this.trans_date.Size = new System.Drawing.Size(120, 20);
            this.trans_date.TabIndex = 23;
            // 
            // dgvcheque
            // 
            this.dgvcheque.AllowUserToAddRows = false;
            this.dgvcheque.AllowUserToDeleteRows = false;
            this.dgvcheque.AllowUserToResizeColumns = false;
            this.dgvcheque.AllowUserToResizeRows = false;
            this.dgvcheque.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvcheque.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.date_,
            this.Bank,
            this.transID,
            this.amt});
            this.dgvcheque.Location = new System.Drawing.Point(96, 150);
            this.dgvcheque.Name = "dgvcheque";
            this.dgvcheque.RowHeadersVisible = false;
            this.dgvcheque.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvcheque.Size = new System.Drawing.Size(438, 114);
            this.dgvcheque.TabIndex = 24;
            // 
            // date_
            // 
            this.date_.HeaderText = "Date";
            this.date_.Name = "date_";
            this.date_.Width = 120;
            // 
            // Bank
            // 
            this.Bank.HeaderText = "Bank";
            this.Bank.Name = "Bank";
            this.Bank.Width = 110;
            // 
            // transID
            // 
            this.transID.HeaderText = "ID";
            this.transID.Name = "transID";
            this.transID.Width = 105;
            // 
            // amt
            // 
            this.amt.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.amt.HeaderText = "Amount";
            this.amt.Name = "amt";
            // 
            // deletebtn
            // 
            this.deletebtn.Location = new System.Drawing.Point(629, 128);
            this.deletebtn.Name = "deletebtn";
            this.deletebtn.Size = new System.Drawing.Size(62, 23);
            this.deletebtn.TabIndex = 9;
            this.deletebtn.Text = "Delete";
            this.deletebtn.UseVisualStyleBackColor = true;
            this.deletebtn.Click += new System.EventHandler(this.deletebtn_Click);
            // 
            // addbtn
            // 
            this.addbtn.Location = new System.Drawing.Point(557, 128);
            this.addbtn.Name = "addbtn";
            this.addbtn.Size = new System.Drawing.Size(66, 23);
            this.addbtn.TabIndex = 8;
            this.addbtn.Text = "Add";
            this.addbtn.UseVisualStyleBackColor = true;
            this.addbtn.Click += new System.EventHandler(this.addbtn_Click);
            // 
            // emplbl
            // 
            this.emplbl.AutoSize = true;
            this.emplbl.Location = new System.Drawing.Point(110, 356);
            this.emplbl.Name = "emplbl";
            this.emplbl.Size = new System.Drawing.Size(48, 13);
            this.emplbl.TabIndex = 95;
            this.emplbl.Text = "Authorlbl";
            // 
            // operatorlbl
            // 
            this.operatorlbl.AutoSize = true;
            this.operatorlbl.Location = new System.Drawing.Point(12, 356);
            this.operatorlbl.Name = "operatorlbl";
            this.operatorlbl.Size = new System.Drawing.Size(92, 13);
            this.operatorlbl.TabIndex = 94;
            this.operatorlbl.Text = "You Are Login As:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(554, 75);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Date";
            // 
            // datetxt
            // 
            this.datetxt.Location = new System.Drawing.Point(590, 72);
            this.datetxt.Name = "datetxt";
            this.datetxt.Size = new System.Drawing.Size(101, 20);
            this.datetxt.TabIndex = 18;
            this.datetxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(33, 273);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Reference";
            // 
            // referencetxt
            // 
            this.referencetxt.Location = new System.Drawing.Point(96, 270);
            this.referencetxt.Name = "referencetxt";
            this.referencetxt.Size = new System.Drawing.Size(438, 20);
            this.referencetxt.TabIndex = 19;
            // 
            // payment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 378);
            this.Controls.Add(this.emplbl);
            this.Controls.Add(this.operatorlbl);
            this.Controls.Add(this.dgvcheque);
            this.Controls.Add(this.trans_date);
            this.Controls.Add(this.transamttxt);
            this.Controls.Add(this.transidtxt);
            this.Controls.Add(this.banktxt);
            this.Controls.Add(this.partycmbx);
            this.Controls.Add(this.inwordtxt);
            this.Controls.Add(this.datetxt);
            this.Controls.Add(this.receipttxt);
            this.Controls.Add(this.referencetxt);
            this.Controls.Add(this.amttxt);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.transIDlbl);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.Amount);
            this.Controls.Add(this.partylbl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.newbtn);
            this.Controls.Add(this.prntbtn);
            this.Controls.Add(this.addbtn);
            this.Controls.Add(this.Discardbtn);
            this.Controls.Add(this.deletebtn);
            this.Controls.Add(this.Savebtn);
            this.Name = "payment";
            this.Text = "payment";
            ((System.ComponentModel.ISupportInitialize)(this.dgvcheque)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox partycmbx;
        private System.Windows.Forms.TextBox inwordtxt;
        private System.Windows.Forms.TextBox receipttxt;
        private System.Windows.Forms.TextBox amttxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label Amount;
        private System.Windows.Forms.Label partylbl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button newbtn;
        private System.Windows.Forms.Button prntbtn;
        private System.Windows.Forms.Button Discardbtn;
        private System.Windows.Forms.Button Savebtn;
        private System.Windows.Forms.TextBox banktxt;
        private System.Windows.Forms.TextBox transidtxt;
        private System.Windows.Forms.TextBox transamttxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label transIDlbl;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker trans_date;
        private System.Windows.Forms.DataGridView dgvcheque;
        private System.Windows.Forms.Button deletebtn;
        private System.Windows.Forms.Button addbtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn date_;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bank;
        private System.Windows.Forms.DataGridViewTextBoxColumn transID;
        private System.Windows.Forms.DataGridViewTextBoxColumn amt;
        private System.Windows.Forms.Label emplbl;
        private System.Windows.Forms.Label operatorlbl;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox datetxt;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox referencetxt;
    }
}