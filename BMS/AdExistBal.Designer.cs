namespace BMS
{
    partial class AdExistBal
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
            this.particulartxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.amttxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.credittn = new System.Windows.Forms.RadioButton();
            this.debitbtn = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // savebtn
            // 
            this.savebtn.Location = new System.Drawing.Point(419, 89);
            this.savebtn.Name = "savebtn";
            this.savebtn.Size = new System.Drawing.Size(75, 23);
            this.savebtn.TabIndex = 0;
            this.savebtn.Text = "Save";
            this.savebtn.UseCompatibleTextRendering = true;
            this.savebtn.UseVisualStyleBackColor = true;
            this.savebtn.Click += new System.EventHandler(this.savebtn_Click);
            // 
            // particulartxt
            // 
            this.particulartxt.Location = new System.Drawing.Point(13, 51);
            this.particulartxt.Name = "particulartxt";
            this.particulartxt.Size = new System.Drawing.Size(375, 20);
            this.particulartxt.TabIndex = 1;
            this.particulartxt.Text = "Opening Balance";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Particular";
            // 
            // amttxt
            // 
            this.amttxt.Location = new System.Drawing.Point(394, 51);
            this.amttxt.Name = "amttxt";
            this.amttxt.Size = new System.Drawing.Size(100, 20);
            this.amttxt.TabIndex = 1;
            this.amttxt.Text = "0";
            this.amttxt.TextChanged += new System.EventHandler(this.amttxt_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(394, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Amount";
            // 
            // credittn
            // 
            this.credittn.AutoSize = true;
            this.credittn.Location = new System.Drawing.Point(280, 89);
            this.credittn.Name = "credittn";
            this.credittn.Size = new System.Drawing.Size(52, 17);
            this.credittn.TabIndex = 3;
            this.credittn.Text = "Credit";
            this.credittn.UseVisualStyleBackColor = true;
            this.credittn.Visible = false;
            this.credittn.CheckedChanged += new System.EventHandler(this.credittn_CheckedChanged);
            // 
            // debitbtn
            // 
            this.debitbtn.AutoSize = true;
            this.debitbtn.Location = new System.Drawing.Point(338, 89);
            this.debitbtn.Name = "debitbtn";
            this.debitbtn.Size = new System.Drawing.Size(50, 17);
            this.debitbtn.TabIndex = 3;
            this.debitbtn.Text = "Debit";
            this.debitbtn.UseVisualStyleBackColor = true;
            this.debitbtn.Visible = false;
            this.debitbtn.CheckedChanged += new System.EventHandler(this.debitbtn_CheckedChanged);
            // 
            // AdExistBal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 124);
            this.Controls.Add(this.debitbtn);
            this.Controls.Add(this.credittn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.amttxt);
            this.Controls.Add(this.particulartxt);
            this.Controls.Add(this.savebtn);
            this.Name = "AdExistBal";
            this.Text = "AdExistBal";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button savebtn;
        private System.Windows.Forms.TextBox particulartxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox amttxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton credittn;
        private System.Windows.Forms.RadioButton debitbtn;
    }
}