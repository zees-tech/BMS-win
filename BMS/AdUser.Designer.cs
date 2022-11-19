namespace BMS
{
    partial class AdUser
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
            this.nametxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.useridtxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.passwordtxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.typecmb = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.savebtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // nametxt
            // 
            this.nametxt.Location = new System.Drawing.Point(94, 53);
            this.nametxt.Name = "nametxt";
            this.nametxt.Size = new System.Drawing.Size(229, 20);
            this.nametxt.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "User Name";
            // 
            // useridtxt
            // 
            this.useridtxt.Location = new System.Drawing.Point(94, 79);
            this.useridtxt.Name = "useridtxt";
            this.useridtxt.Size = new System.Drawing.Size(137, 20);
            this.useridtxt.TabIndex = 1;
            this.useridtxt.TextChanged += new System.EventHandler(this.useridtxt_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "User Id";
            // 
            // passwordtxt
            // 
            this.passwordtxt.Location = new System.Drawing.Point(94, 105);
            this.passwordtxt.Name = "passwordtxt";
            this.passwordtxt.Size = new System.Drawing.Size(137, 20);
            this.passwordtxt.TabIndex = 2;
            this.passwordtxt.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Password";
            // 
            // typecmb
            // 
            this.typecmb.FormattingEnabled = true;
            this.typecmb.Items.AddRange(new object[] {
            "Master",
            "Standard"});
            this.typecmb.Location = new System.Drawing.Point(94, 130);
            this.typecmb.Name = "typecmb";
            this.typecmb.Size = new System.Drawing.Size(121, 21);
            this.typecmb.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "User Type";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(52, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(260, 31);
            this.label5.TabIndex = 3;
            this.label5.Text = "Register New User";
            // 
            // savebtn
            // 
            this.savebtn.Location = new System.Drawing.Point(291, 156);
            this.savebtn.Name = "savebtn";
            this.savebtn.Size = new System.Drawing.Size(75, 23);
            this.savebtn.TabIndex = 5;
            this.savebtn.Text = "Save";
            this.savebtn.UseVisualStyleBackColor = true;
            this.savebtn.Click += new System.EventHandler(this.savebtn_Click);
            // 
            // AdUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 191);
            this.Controls.Add(this.savebtn);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.typecmb);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.passwordtxt);
            this.Controls.Add(this.useridtxt);
            this.Controls.Add(this.nametxt);
            this.Name = "AdUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdUser";
            this.Load += new System.EventHandler(this.AdUser_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox nametxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox useridtxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox passwordtxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox typecmb;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button savebtn;
    }
}