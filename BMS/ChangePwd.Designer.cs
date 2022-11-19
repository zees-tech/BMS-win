namespace BMS
{
    partial class ChangePwd
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
            this.savebtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.newpasstxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.confirmpasstxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // savebtn
            // 
            this.savebtn.Location = new System.Drawing.Point(371, 163);
            this.savebtn.Name = "savebtn";
            this.savebtn.Size = new System.Drawing.Size(75, 23);
            this.savebtn.TabIndex = 0;
            this.savebtn.Text = "Save";
            this.savebtn.UseVisualStyleBackColor = true;
            this.savebtn.Click += new System.EventHandler(this.savebtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "New Password";
            // 
            // newpasstxt
            // 
            this.newpasstxt.Location = new System.Drawing.Point(107, 62);
            this.newpasstxt.Name = "newpasstxt";
            this.newpasstxt.Size = new System.Drawing.Size(255, 20);
            this.newpasstxt.TabIndex = 2;
            this.newpasstxt.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Confirm Password";
            // 
            // confirmpasstxt
            // 
            this.confirmpasstxt.Location = new System.Drawing.Point(107, 111);
            this.confirmpasstxt.Name = "confirmpasstxt";
            this.confirmpasstxt.Size = new System.Drawing.Size(255, 20);
            this.confirmpasstxt.TabIndex = 2;
            this.confirmpasstxt.UseSystemPasswordChar = true;
            this.confirmpasstxt.TextChanged += new System.EventHandler(this.confirmpasstxt_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(111, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(251, 31);
            this.label3.TabIndex = 3;
            this.label3.Text = "Change Password";
            // 
            // ChangePwd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 198);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.confirmpasstxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.newpasstxt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.savebtn);
            this.Name = "ChangePwd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Change Password";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button savebtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox newpasstxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox confirmpasstxt;
        private System.Windows.Forms.Label label3;
    }
}