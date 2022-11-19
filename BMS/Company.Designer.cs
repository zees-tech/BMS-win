namespace BMS
{
    partial class Company
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
            this.image = new System.Windows.Forms.PictureBox();
            this.btndelete = new System.Windows.Forms.Button();
            this.btninsert = new System.Windows.Forms.Button();
            this.cmbstate = new System.Windows.Forms.ComboBox();
            this.txtgstin = new System.Windows.Forms.TextBox();
            this.txtpincode = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtdistrict = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtcity = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtaddress = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtalias = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtname = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.newbtn = new System.Windows.Forms.Button();
            this.previousbtn = new System.Windows.Forms.Button();
            this.nextbtn = new System.Windows.Forms.Button();
            this.Savebtn = new System.Windows.Forms.Button();
            this.Discardbtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.chbxgenerateLedger = new System.Windows.Forms.CheckBox();
            this.btnaddcontact = new System.Windows.Forms.Button();
            this.chbxnewcat = new System.Windows.Forms.CheckBox();
            this.txtnewcat = new System.Windows.Forms.TextBox();
            this.cmbnewtype = new System.Windows.Forms.ComboBox();
            this.cmbcategory = new System.Windows.Forms.ComboBox();
            this.adbankdtbtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.image)).BeginInit();
            this.SuspendLayout();
            // 
            // image
            // 
            this.image.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.image.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.image.Location = new System.Drawing.Point(526, 19);
            this.image.Name = "image";
            this.image.Size = new System.Drawing.Size(296, 162);
            this.image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.image.TabIndex = 0;
            this.image.TabStop = false;
            // 
            // btndelete
            // 
            this.btndelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btndelete.Location = new System.Drawing.Point(706, 189);
            this.btndelete.Name = "btndelete";
            this.btndelete.Size = new System.Drawing.Size(75, 23);
            this.btndelete.TabIndex = 15;
            this.btndelete.Text = "Delete";
            this.btndelete.UseVisualStyleBackColor = true;
            this.btndelete.Click += new System.EventHandler(this.btndelete_Click);
            // 
            // btninsert
            // 
            this.btninsert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btninsert.Location = new System.Drawing.Point(625, 189);
            this.btninsert.Name = "btninsert";
            this.btninsert.Size = new System.Drawing.Size(75, 23);
            this.btninsert.TabIndex = 14;
            this.btninsert.Text = "Insert";
            this.btninsert.UseVisualStyleBackColor = true;
            this.btninsert.Click += new System.EventHandler(this.btninsert_Click);
            // 
            // cmbstate
            // 
            this.cmbstate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbstate.FormattingEnabled = true;
            this.cmbstate.Items.AddRange(new object[] {
            "Andhra Pradesh (AP)",
            "Arunachal Pradesh (AR)",
            "Assam (AS)",
            "Bihar (BR)",
            "Chhattisgarh (CG)",
            "Goa (GA)",
            "Gujarat (GJ)",
            "Haryana (HR)",
            "Himachal Pradesh (HP)",
            "Jammu and Kashmir (JK)",
            "Jharkhand (JH)",
            "Karnataka (KA)",
            "Kerala (KL)",
            "Madhya Pradesh (MP)",
            "Maharashtra (MH)",
            "Manipur (MN)",
            "Meghalaya (ML)",
            "Mizoram (MZ)",
            "Nagaland (NL)",
            "Odisha(OR)",
            "Punjab (PB)",
            "Rajasthan (RJ)",
            "Sikkim (SK)",
            "Tamil Nadu (TN)",
            "Telangana (TS)",
            "Tripura (TR)",
            "Uttar Pradesh (UP)",
            "Uttarakhand (UK)",
            "West Bengal (WB)",
            "Andaman and Nicobar Islands(AN)",
            "Chandigarh (CH)",
            "Dadra and Nagar Haveli (DN)",
            "Daman and Diu (DD)",
            "National Capital Territory of Delhi (DL)",
            "Lakshadweep (LD)",
            "Pondicherry (PY)",
            "Select State"});
            this.cmbstate.Location = new System.Drawing.Point(75, 150);
            this.cmbstate.Name = "cmbstate";
            this.cmbstate.Size = new System.Drawing.Size(142, 21);
            this.cmbstate.TabIndex = 6;
            // 
            // txtgstin
            // 
            this.txtgstin.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtgstin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtgstin.Location = new System.Drawing.Point(75, 201);
            this.txtgstin.MaxLength = 15;
            this.txtgstin.Name = "txtgstin";
            this.txtgstin.Size = new System.Drawing.Size(142, 21);
            this.txtgstin.TabIndex = 8;
            // 
            // txtpincode
            // 
            this.txtpincode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpincode.Location = new System.Drawing.Point(75, 175);
            this.txtpincode.MaxLength = 6;
            this.txtpincode.Name = "txtpincode";
            this.txtpincode.Size = new System.Drawing.Size(87, 21);
            this.txtpincode.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(24, 205);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 15);
            this.label9.TabIndex = 63;
            this.label9.Text = "GSTIN";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(15, 179);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 15);
            this.label8.TabIndex = 61;
            this.label8.Text = "Pincode";
            // 
            // txtdistrict
            // 
            this.txtdistrict.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdistrict.Location = new System.Drawing.Point(75, 123);
            this.txtdistrict.Name = "txtdistrict";
            this.txtdistrict.Size = new System.Drawing.Size(164, 21);
            this.txtdistrict.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(32, 153);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 15);
            this.label7.TabIndex = 60;
            this.label7.Text = "State";
            // 
            // txtcity
            // 
            this.txtcity.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcity.Location = new System.Drawing.Point(75, 97);
            this.txtcity.Name = "txtcity";
            this.txtcity.Size = new System.Drawing.Size(164, 21);
            this.txtcity.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(23, 127);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 15);
            this.label6.TabIndex = 57;
            this.label6.Text = "District";
            // 
            // txtaddress
            // 
            this.txtaddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtaddress.Location = new System.Drawing.Point(75, 71);
            this.txtaddress.Name = "txtaddress";
            this.txtaddress.Size = new System.Drawing.Size(426, 21);
            this.txtaddress.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(41, 101);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 15);
            this.label5.TabIndex = 59;
            this.label5.Text = "City";
            // 
            // txtalias
            // 
            this.txtalias.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtalias.Location = new System.Drawing.Point(75, 45);
            this.txtalias.Name = "txtalias";
            this.txtalias.Size = new System.Drawing.Size(364, 21);
            this.txtalias.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(16, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 15);
            this.label4.TabIndex = 58;
            this.label4.Text = "Address";
            // 
            // txtname
            // 
            this.txtname.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtname.Location = new System.Drawing.Point(75, 19);
            this.txtname.Name = "txtname";
            this.txtname.Size = new System.Drawing.Size(364, 21);
            this.txtname.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(34, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 15);
            this.label3.TabIndex = 62;
            this.label3.Text = "Alias";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 15);
            this.label1.TabIndex = 64;
            this.label1.Text = "Company";
            // 
            // newbtn
            // 
            this.newbtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.newbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newbtn.Location = new System.Drawing.Point(26, 237);
            this.newbtn.Name = "newbtn";
            this.newbtn.Size = new System.Drawing.Size(75, 23);
            this.newbtn.TabIndex = 18;
            this.newbtn.Text = "New";
            this.newbtn.UseVisualStyleBackColor = true;
            this.newbtn.Click += new System.EventHandler(this.newbtn_Click);
            // 
            // previousbtn
            // 
            this.previousbtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.previousbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.previousbtn.Location = new System.Drawing.Point(666, 238);
            this.previousbtn.Name = "previousbtn";
            this.previousbtn.Size = new System.Drawing.Size(75, 23);
            this.previousbtn.TabIndex = 17;
            this.previousbtn.Text = "Previous";
            this.previousbtn.UseVisualStyleBackColor = true;
            this.previousbtn.Click += new System.EventHandler(this.previousbtn_Click);
            // 
            // nextbtn
            // 
            this.nextbtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.nextbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nextbtn.Location = new System.Drawing.Point(747, 238);
            this.nextbtn.Name = "nextbtn";
            this.nextbtn.Size = new System.Drawing.Size(75, 23);
            this.nextbtn.TabIndex = 16;
            this.nextbtn.Text = "Next";
            this.nextbtn.UseVisualStyleBackColor = true;
            this.nextbtn.Click += new System.EventHandler(this.nextbtn_Click);
            // 
            // Savebtn
            // 
            this.Savebtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Savebtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Savebtn.Location = new System.Drawing.Point(666, 238);
            this.Savebtn.Name = "Savebtn";
            this.Savebtn.Size = new System.Drawing.Size(75, 23);
            this.Savebtn.TabIndex = 17;
            this.Savebtn.Text = "Save";
            this.Savebtn.UseVisualStyleBackColor = true;
            this.Savebtn.Click += new System.EventHandler(this.Savebtn_Click);
            // 
            // Discardbtn
            // 
            this.Discardbtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Discardbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Discardbtn.Location = new System.Drawing.Point(747, 238);
            this.Discardbtn.Name = "Discardbtn";
            this.Discardbtn.Size = new System.Drawing.Size(75, 23);
            this.Discardbtn.TabIndex = 16;
            this.Discardbtn.Text = "Discard";
            this.Discardbtn.UseVisualStyleBackColor = true;
            this.Discardbtn.Click += new System.EventHandler(this.Discardbtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(236, 181);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 15);
            this.label2.TabIndex = 60;
            this.label2.Text = "Category";
            // 
            // chbxgenerateLedger
            // 
            this.chbxgenerateLedger.AutoSize = true;
            this.chbxgenerateLedger.Checked = true;
            this.chbxgenerateLedger.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbxgenerateLedger.Location = new System.Drawing.Point(297, 237);
            this.chbxgenerateLedger.Name = "chbxgenerateLedger";
            this.chbxgenerateLedger.Size = new System.Drawing.Size(106, 17);
            this.chbxgenerateLedger.TabIndex = 11;
            this.chbxgenerateLedger.Text = "Generate Ledger";
            this.chbxgenerateLedger.UseVisualStyleBackColor = true;
            // 
            // btnaddcontact
            // 
            this.btnaddcontact.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnaddcontact.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnaddcontact.Location = new System.Drawing.Point(20, 237);
            this.btnaddcontact.Name = "btnaddcontact";
            this.btnaddcontact.Size = new System.Drawing.Size(89, 23);
            this.btnaddcontact.TabIndex = 77;
            this.btnaddcontact.Text = "Add Contact";
            this.btnaddcontact.UseVisualStyleBackColor = true;
            this.btnaddcontact.Click += new System.EventHandler(this.btnaddcontact_Click);
            // 
            // chbxnewcat
            // 
            this.chbxnewcat.AutoSize = true;
            this.chbxnewcat.Checked = true;
            this.chbxnewcat.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.chbxnewcat.Location = new System.Drawing.Point(297, 211);
            this.chbxnewcat.Name = "chbxnewcat";
            this.chbxnewcat.Size = new System.Drawing.Size(93, 17);
            this.chbxnewcat.TabIndex = 10;
            this.chbxnewcat.Text = "New Category";
            this.chbxnewcat.UseVisualStyleBackColor = true;
            this.chbxnewcat.CheckedChanged += new System.EventHandler(this.chbxnewcat_CheckedChanged);
            // 
            // txtnewcat
            // 
            this.txtnewcat.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtnewcat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtnewcat.Location = new System.Drawing.Point(413, 207);
            this.txtnewcat.Name = "txtnewcat";
            this.txtnewcat.Size = new System.Drawing.Size(142, 21);
            this.txtnewcat.TabIndex = 12;
            this.txtnewcat.Text = "NEW CATEGORY NAME";
            this.txtnewcat.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cmbnewtype
            // 
            this.cmbnewtype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbnewtype.FormattingEnabled = true;
            this.cmbnewtype.Items.AddRange(new object[] {
            "Creditor",
            "Debitor",
            "Select Type"});
            this.cmbnewtype.Location = new System.Drawing.Point(413, 235);
            this.cmbnewtype.Name = "cmbnewtype";
            this.cmbnewtype.Size = new System.Drawing.Size(88, 21);
            this.cmbnewtype.TabIndex = 13;
            // 
            // cmbcategory
            // 
            this.cmbcategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbcategory.FormattingEnabled = true;
            this.cmbcategory.Location = new System.Drawing.Point(297, 178);
            this.cmbcategory.Name = "cmbcategory";
            this.cmbcategory.Size = new System.Drawing.Size(121, 21);
            this.cmbcategory.TabIndex = 9;
            // 
            // adbankdtbtn
            // 
            this.adbankdtbtn.Location = new System.Drawing.Point(388, 124);
            this.adbankdtbtn.Name = "adbankdtbtn";
            this.adbankdtbtn.Size = new System.Drawing.Size(113, 23);
            this.adbankdtbtn.TabIndex = 78;
            this.adbankdtbtn.Text = "A/c Details";
            this.adbankdtbtn.UseVisualStyleBackColor = true;
            this.adbankdtbtn.Click += new System.EventHandler(this.adbankdtbtn_Click);
            // 
            // Company
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 272);
            this.Controls.Add(this.adbankdtbtn);
            this.Controls.Add(this.cmbcategory);
            this.Controls.Add(this.chbxnewcat);
            this.Controls.Add(this.chbxgenerateLedger);
            this.Controls.Add(this.newbtn);
            this.Controls.Add(this.cmbnewtype);
            this.Controls.Add(this.cmbstate);
            this.Controls.Add(this.txtnewcat);
            this.Controls.Add(this.txtgstin);
            this.Controls.Add(this.txtpincode);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtdistrict);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtcity);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtaddress);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtalias);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtname);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btninsert);
            this.Controls.Add(this.btndelete);
            this.Controls.Add(this.image);
            this.Controls.Add(this.btnaddcontact);
            this.Controls.Add(this.nextbtn);
            this.Controls.Add(this.Discardbtn);
            this.Controls.Add(this.Savebtn);
            this.Controls.Add(this.previousbtn);
            this.Name = "Company";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CompanyObj";
            ((System.ComponentModel.ISupportInitialize)(this.image)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox image;
        private System.Windows.Forms.Button btndelete;
        private System.Windows.Forms.Button btninsert;
        private System.Windows.Forms.ComboBox cmbstate;
        private System.Windows.Forms.TextBox txtgstin;
        private System.Windows.Forms.TextBox txtpincode;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtdistrict;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtcity;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtaddress;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtalias;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtname;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button newbtn;
        private System.Windows.Forms.Button previousbtn;
        private System.Windows.Forms.Button nextbtn;
        private System.Windows.Forms.Button Savebtn;
        private System.Windows.Forms.Button Discardbtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chbxgenerateLedger;
        private System.Windows.Forms.Button btnaddcontact;
        private System.Windows.Forms.CheckBox chbxnewcat;
        private System.Windows.Forms.TextBox txtnewcat;
        private System.Windows.Forms.ComboBox cmbnewtype;
        private System.Windows.Forms.ComboBox cmbcategory;
        private System.Windows.Forms.Button adbankdtbtn;
    }
}