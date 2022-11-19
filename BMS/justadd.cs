using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace bms1
{
    public partial class justadd : Form
    {
        public justadd()
        {
            InitializeComponent();
        }
        private void savebtn_Click(object sender, EventArgs e)
        {
            return_();
            this.Close();
        }
        public string return_()
        {
            return newcategorytxt.Text;
        }
    }
}
