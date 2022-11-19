namespace bms1
{
    partial class justadd
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
            this.newcategorytxt = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // savebtn
            // 
            this.savebtn.Location = new System.Drawing.Point(263, 147);
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
            this.label1.Location = new System.Drawing.Point(62, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Add New";
            // 
            // newcategorytxt
            // 
            this.newcategorytxt.Location = new System.Drawing.Point(119, 62);
            this.newcategorytxt.Name = "newcategorytxt";
            this.newcategorytxt.Size = new System.Drawing.Size(163, 20);
            this.newcategorytxt.TabIndex = 2;
            // 
            // justadd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 182);
            this.Controls.Add(this.newcategorytxt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.savebtn);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "justadd";
            this.Text = "justadd";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button savebtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox newcategorytxt;
    }
}