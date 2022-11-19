namespace BMS
{
    partial class Cash_Payment
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
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.Savebtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.amttxt = new System.Windows.Forms.TextBox();
            this.partycmbx = new System.Windows.Forms.ComboBox();
            this.partylbl = new System.Windows.Forms.Label();
            this.Amount = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.inwordtxt = new System.Windows.Forms.TextBox();
            this.Discardbtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.receivertxt = new System.Windows.Forms.TextBox();
            this.newbtn = new System.Windows.Forms.Button();
            this.prntbtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.receipttxt = new System.Windows.Forms.TextBox();
            this.emplbl = new System.Windows.Forms.Label();
            this.operatorlbl = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.referrencetxt = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(604, 80);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(95, 20);
            this.dateTimePicker1.TabIndex = 0;
            // 
            // Savebtn
            // 
            this.Savebtn.Location = new System.Drawing.Point(624, 343);
            this.Savebtn.Name = "Savebtn";
            this.Savebtn.Size = new System.Drawing.Size(75, 23);
            this.Savebtn.TabIndex = 1;
            this.Savebtn.Text = "Save";
            this.Savebtn.UseVisualStyleBackColor = true;
            this.Savebtn.Click += new System.EventHandler(this.Save_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(293, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Payment Memo";
            // 
            // amttxt
            // 
            this.amttxt.Location = new System.Drawing.Point(104, 105);
            this.amttxt.Name = "amttxt";
            this.amttxt.Size = new System.Drawing.Size(152, 20);
            this.amttxt.TabIndex = 3;
            this.amttxt.TextChanged += new System.EventHandler(this.amttxt_TextChanged);
            // 
            // partycmbx
            // 
            this.partycmbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.partycmbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.partycmbx.FormattingEnabled = true;
            this.partycmbx.Location = new System.Drawing.Point(104, 48);
            this.partycmbx.Name = "partycmbx";
            this.partycmbx.Size = new System.Drawing.Size(306, 33);
            this.partycmbx.TabIndex = 4;
            // 
            // partylbl
            // 
            this.partylbl.AutoSize = true;
            this.partylbl.Enabled = false;
            this.partylbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.partylbl.Location = new System.Drawing.Point(28, 51);
            this.partylbl.Name = "partylbl";
            this.partylbl.Size = new System.Drawing.Size(70, 25);
            this.partylbl.TabIndex = 2;
            this.partylbl.Text = "label1";
            // 
            // Amount
            // 
            this.Amount.AutoSize = true;
            this.Amount.Location = new System.Drawing.Point(55, 108);
            this.Amount.Name = "Amount";
            this.Amount.Size = new System.Drawing.Size(43, 13);
            this.Amount.TabIndex = 2;
            this.Amount.Text = "Amount";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(53, 152);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "In Word";
            // 
            // inwordtxt
            // 
            this.inwordtxt.Location = new System.Drawing.Point(104, 149);
            this.inwordtxt.Name = "inwordtxt";
            this.inwordtxt.Size = new System.Drawing.Size(595, 20);
            this.inwordtxt.TabIndex = 3;
            // 
            // Discardbtn
            // 
            this.Discardbtn.Location = new System.Drawing.Point(543, 343);
            this.Discardbtn.Name = "Discardbtn";
            this.Discardbtn.Size = new System.Drawing.Size(75, 23);
            this.Discardbtn.TabIndex = 1;
            this.Discardbtn.Text = "Discard";
            this.Discardbtn.UseVisualStyleBackColor = true;
            this.Discardbtn.Click += new System.EventHandler(this.Discard_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 196);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Reciever";
            // 
            // receivertxt
            // 
            this.receivertxt.Location = new System.Drawing.Point(104, 193);
            this.receivertxt.Name = "receivertxt";
            this.receivertxt.Size = new System.Drawing.Size(152, 20);
            this.receivertxt.TabIndex = 3;
            // 
            // newbtn
            // 
            this.newbtn.Location = new System.Drawing.Point(624, 41);
            this.newbtn.Name = "newbtn";
            this.newbtn.Size = new System.Drawing.Size(75, 23);
            this.newbtn.TabIndex = 1;
            this.newbtn.Text = "New";
            this.newbtn.UseVisualStyleBackColor = true;
            this.newbtn.Click += new System.EventHandler(this.newbtn_Click);
            // 
            // prntbtn
            // 
            this.prntbtn.Location = new System.Drawing.Point(624, 12);
            this.prntbtn.Name = "prntbtn";
            this.prntbtn.Size = new System.Drawing.Size(75, 23);
            this.prntbtn.TabIndex = 1;
            this.prntbtn.Text = "Print";
            this.prntbtn.UseVisualStyleBackColor = true;
            this.prntbtn.Click += new System.EventHandler(this.Discard_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(562, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Receipt Id";
            // 
            // receipttxt
            // 
            this.receipttxt.Location = new System.Drawing.Point(624, 105);
            this.receipttxt.Name = "receipttxt";
            this.receipttxt.Size = new System.Drawing.Size(75, 20);
            this.receipttxt.TabIndex = 3;
            this.receipttxt.Text = "#####";
            this.receipttxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // emplbl
            // 
            this.emplbl.AutoSize = true;
            this.emplbl.Location = new System.Drawing.Point(110, 356);
            this.emplbl.Name = "emplbl";
            this.emplbl.Size = new System.Drawing.Size(48, 13);
            this.emplbl.TabIndex = 97;
            this.emplbl.Text = "Authorlbl";
            // 
            // operatorlbl
            // 
            this.operatorlbl.AutoSize = true;
            this.operatorlbl.Location = new System.Drawing.Point(12, 356);
            this.operatorlbl.Name = "operatorlbl";
            this.operatorlbl.Size = new System.Drawing.Size(92, 13);
            this.operatorlbl.TabIndex = 96;
            this.operatorlbl.Text = "You Are Login As:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(38, 241);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Referrence";
            // 
            // referrencetxt
            // 
            this.referrencetxt.Location = new System.Drawing.Point(104, 238);
            this.referrencetxt.Name = "referrencetxt";
            this.referrencetxt.Size = new System.Drawing.Size(152, 20);
            this.referrencetxt.TabIndex = 3;
            // 
            // Cash_Payment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 378);
            this.Controls.Add(this.emplbl);
            this.Controls.Add(this.operatorlbl);
            this.Controls.Add(this.partycmbx);
            this.Controls.Add(this.inwordtxt);
            this.Controls.Add(this.referrencetxt);
            this.Controls.Add(this.receivertxt);
            this.Controls.Add(this.receipttxt);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.amttxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Amount);
            this.Controls.Add(this.partylbl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.newbtn);
            this.Controls.Add(this.prntbtn);
            this.Controls.Add(this.Discardbtn);
            this.Controls.Add(this.Savebtn);
            this.Controls.Add(this.dateTimePicker1);
            this.MaximizeBox = false;
            this.Name = "Cash_Payment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cash_Payment";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button Savebtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox amttxt;
        private System.Windows.Forms.ComboBox partycmbx;
        private System.Windows.Forms.Label partylbl;
        private System.Windows.Forms.Label Amount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox inwordtxt;
        private System.Windows.Forms.Button Discardbtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox receivertxt;
        private System.Windows.Forms.Button newbtn;
        private System.Windows.Forms.Button prntbtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox receipttxt;
        private System.Windows.Forms.Label emplbl;
        private System.Windows.Forms.Label operatorlbl;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox referrencetxt;
    }
}