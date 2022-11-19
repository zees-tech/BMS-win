namespace BMS
{
    partial class Authenticate
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
            this.keytxt = new System.Windows.Forms.TextBox();
            this.confirmbtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // keytxt
            // 
            this.keytxt.Location = new System.Drawing.Point(14, 12);
            this.keytxt.Name = "keytxt";
            this.keytxt.Size = new System.Drawing.Size(245, 20);
            this.keytxt.TabIndex = 1;
            this.keytxt.Text = "Enter the admin key to confirm";
            this.keytxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.keytxt.TextChanged += new System.EventHandler(this.keytxt_TextChanged);
            // 
            // confirmbtn
            // 
            this.confirmbtn.Location = new System.Drawing.Point(97, 52);
            this.confirmbtn.Name = "confirmbtn";
            this.confirmbtn.Size = new System.Drawing.Size(75, 23);
            this.confirmbtn.TabIndex = 2;
            this.confirmbtn.Text = "Confirm";
            this.confirmbtn.UseVisualStyleBackColor = true;
            this.confirmbtn.Click += new System.EventHandler(this.confirmbtn_Click);
            // 
            // Authenticate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(273, 87);
            this.ControlBox = false;
            this.Controls.Add(this.confirmbtn);
            this.Controls.Add(this.keytxt);
            this.Name = "Authenticate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Authenticate";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox keytxt;
        private System.Windows.Forms.Button confirmbtn;
    }
}