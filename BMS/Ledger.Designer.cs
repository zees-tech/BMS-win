namespace BMS
{
    partial class Ledger
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
            this.ledgerlbl = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.date_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.particular = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.folio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.credit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.debit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.adManualRecbtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // ledgerlbl
            // 
            this.ledgerlbl.AutoSize = true;
            this.ledgerlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ledgerlbl.ForeColor = System.Drawing.Color.Maroon;
            this.ledgerlbl.Location = new System.Drawing.Point(496, 7);
            this.ledgerlbl.Name = "ledgerlbl";
            this.ledgerlbl.Size = new System.Drawing.Size(79, 25);
            this.ledgerlbl.TabIndex = 171;
            this.ledgerlbl.Text = "Ledger";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.date_,
            this.particular,
            this.folio,
            this.credit,
            this.debit,
            this.bal});
            this.dataGridView1.Location = new System.Drawing.Point(22, 44);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1041, 508);
            this.dataGridView1.TabIndex = 175;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // date_
            // 
            this.date_.HeaderText = "Date";
            this.date_.Name = "date_";
            this.date_.Width = 150;
            // 
            // particular
            // 
            this.particular.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.particular.HeaderText = "Particular";
            this.particular.Name = "particular";
            // 
            // folio
            // 
            this.folio.HeaderText = "Folio";
            this.folio.Name = "folio";
            // 
            // credit
            // 
            this.credit.HeaderText = "Credit";
            this.credit.Name = "credit";
            this.credit.Width = 120;
            // 
            // debit
            // 
            this.debit.HeaderText = "Debit";
            this.debit.Name = "debit";
            this.debit.Width = 120;
            // 
            // bal
            // 
            this.bal.HeaderText = "Balance";
            this.bal.Name = "bal";
            this.bal.Width = 120;
            // 
            // adManualRecbtn
            // 
            this.adManualRecbtn.Location = new System.Drawing.Point(941, 570);
            this.adManualRecbtn.Name = "adManualRecbtn";
            this.adManualRecbtn.Size = new System.Drawing.Size(122, 23);
            this.adManualRecbtn.TabIndex = 176;
            this.adManualRecbtn.Text = "Add Manual Record";
            this.adManualRecbtn.UseVisualStyleBackColor = true;
            this.adManualRecbtn.Click += new System.EventHandler(this.adManualRecbtn_Click);
            // 
            // Ledger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1088, 609);
            this.Controls.Add(this.adManualRecbtn);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.ledgerlbl);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Ledger";
            this.Text = "Ledger";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label ledgerlbl;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn date_;
        private System.Windows.Forms.DataGridViewTextBoxColumn particular;
        private System.Windows.Forms.DataGridViewTextBoxColumn folio;
        private System.Windows.Forms.DataGridViewTextBoxColumn credit;
        private System.Windows.Forms.DataGridViewTextBoxColumn debit;
        private System.Windows.Forms.DataGridViewTextBoxColumn bal;
        private System.Windows.Forms.Button adManualRecbtn;
    }
}