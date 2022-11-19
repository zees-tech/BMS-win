namespace BMS
{
    partial class PreMain
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
            this.companycmbtxt = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.passwordtxt = new System.Windows.Forms.TextBox();
            this.Loginbtn = new System.Windows.Forms.Button();
            this.clearbtn = new System.Windows.Forms.Button();
            this.premainlbl = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.emplbl = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.viewCompanyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editDetailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // companycmbtxt
            // 
            this.companycmbtxt.FormattingEnabled = true;
            this.companycmbtxt.Location = new System.Drawing.Point(293, 91);
            this.companycmbtxt.Name = "companycmbtxt";
            this.companycmbtxt.Size = new System.Drawing.Size(265, 21);
            this.companycmbtxt.TabIndex = 0;
            this.companycmbtxt.DropDown += new System.EventHandler(this.companycmbtxt_DropDown);
            this.companycmbtxt.SelectedIndexChanged += new System.EventHandler(this.companycmbtxt_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(230, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Company :";
            // 
            // passwordtxt
            // 
            this.passwordtxt.Location = new System.Drawing.Point(293, 119);
            this.passwordtxt.Name = "passwordtxt";
            this.passwordtxt.Size = new System.Drawing.Size(265, 20);
            this.passwordtxt.TabIndex = 2;
            this.passwordtxt.Visible = false;
            // 
            // Loginbtn
            // 
            this.Loginbtn.Location = new System.Drawing.Point(725, 387);
            this.Loginbtn.Name = "Loginbtn";
            this.Loginbtn.Size = new System.Drawing.Size(75, 23);
            this.Loginbtn.TabIndex = 3;
            this.Loginbtn.Text = "Login";
            this.Loginbtn.UseVisualStyleBackColor = true;
            this.Loginbtn.Click += new System.EventHandler(this.Loginbtn_Click);
            // 
            // clearbtn
            // 
            this.clearbtn.Location = new System.Drawing.Point(644, 387);
            this.clearbtn.Name = "clearbtn";
            this.clearbtn.Size = new System.Drawing.Size(75, 23);
            this.clearbtn.TabIndex = 4;
            this.clearbtn.Text = "Clear";
            this.clearbtn.UseVisualStyleBackColor = true;
            this.clearbtn.Click += new System.EventHandler(this.clearbtn_Click);
            // 
            // premainlbl
            // 
            this.premainlbl.AutoSize = true;
            this.premainlbl.Location = new System.Drawing.Point(366, 24);
            this.premainlbl.Name = "premainlbl";
            this.premainlbl.Size = new System.Drawing.Size(35, 13);
            this.premainlbl.TabIndex = 1;
            this.premainlbl.Text = "label1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(228, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Password :";
            this.label3.Visible = false;
            // 
            // emplbl
            // 
            this.emplbl.AutoSize = true;
            this.emplbl.Location = new System.Drawing.Point(12, 400);
            this.emplbl.Name = "emplbl";
            this.emplbl.Size = new System.Drawing.Size(35, 13);
            this.emplbl.TabIndex = 1;
            this.emplbl.Text = "label1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewCompanyToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(812, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // viewCompanyToolStripMenuItem
            // 
            this.viewCompanyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.editDetailToolStripMenuItem});
            this.viewCompanyToolStripMenuItem.Name = "viewCompanyToolStripMenuItem";
            this.viewCompanyToolStripMenuItem.Size = new System.Drawing.Size(74, 20);
            this.viewCompanyToolStripMenuItem.Text = "Company ";
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.addToolStripMenuItem.Text = "Add";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.viewToolStripMenuItem.Text = "View";
            this.viewToolStripMenuItem.Click += new System.EventHandler(this.viewToolStripMenuItem_Click);
            // 
            // editDetailToolStripMenuItem
            // 
            this.editDetailToolStripMenuItem.Name = "editDetailToolStripMenuItem";
            this.editDetailToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.editDetailToolStripMenuItem.Text = "Edit Detail";
            // 
            // PreMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 422);
            this.Controls.Add(this.clearbtn);
            this.Controls.Add(this.Loginbtn);
            this.Controls.Add(this.passwordtxt);
            this.Controls.Add(this.emplbl);
            this.Controls.Add(this.premainlbl);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.companycmbtxt);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "PreMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PreMain";
            this.Load += new System.EventHandler(this.PreMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox companycmbtxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox passwordtxt;
        private System.Windows.Forms.Button Loginbtn;
        private System.Windows.Forms.Button clearbtn;
        private System.Windows.Forms.Label premainlbl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label emplbl;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem viewCompanyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editDetailToolStripMenuItem;
    }
}
