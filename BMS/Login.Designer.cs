namespace BMS
{
    partial class Login
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.clearbtn = new System.Windows.Forms.Button();
            this.loginbtn = new System.Windows.Forms.Button();
            this.pwdtxt = new System.Windows.Forms.TextBox();
            this.logintxt = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Login ID";
            // 
            // clearbtn
            // 
            this.clearbtn.Location = new System.Drawing.Point(124, 130);
            this.clearbtn.Name = "clearbtn";
            this.clearbtn.Size = new System.Drawing.Size(64, 23);
            this.clearbtn.TabIndex = 4;
            this.clearbtn.Text = "Clear";
            this.clearbtn.UseVisualStyleBackColor = true;
            this.clearbtn.Click += new System.EventHandler(this.clearbtn_Click);
            // 
            // loginbtn
            // 
            this.loginbtn.Location = new System.Drawing.Point(194, 130);
            this.loginbtn.Name = "loginbtn";
            this.loginbtn.Size = new System.Drawing.Size(64, 23);
            this.loginbtn.TabIndex = 3;
            this.loginbtn.Text = "Login";
            this.loginbtn.UseVisualStyleBackColor = true;
            this.loginbtn.Click += new System.EventHandler(this.loginbtn_Click);
            // 
            // pwdtxt
            // 
            this.pwdtxt.AcceptsTab = true;
            this.pwdtxt.Location = new System.Drawing.Point(100, 93);
            this.pwdtxt.Name = "pwdtxt";
            this.pwdtxt.Size = new System.Drawing.Size(203, 20);
            this.pwdtxt.TabIndex = 1;
            this.pwdtxt.Text = "";
            this.pwdtxt.UseSystemPasswordChar = true;
            // 
            // logintxt
            // 
            this.logintxt.AcceptsTab = true;
            this.logintxt.Location = new System.Drawing.Point(100, 56);
            this.logintxt.Name = "logintxt";
            this.logintxt.Size = new System.Drawing.Size(203, 20);
            this.logintxt.TabIndex = 1;
            this.logintxt.Text = "";           
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 203);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.clearbtn);
            this.Controls.Add(this.loginbtn);
            this.Controls.Add(this.pwdtxt);
            this.Controls.Add(this.logintxt);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button clearbtn;
        private System.Windows.Forms.Button loginbtn;
        private System.Windows.Forms.TextBox pwdtxt;
        private System.Windows.Forms.TextBox logintxt;

        private bool isUser()
        {
            return Call.ret_isRecord("Login_T", Constant.CompanyDB);
        }
    }
}

