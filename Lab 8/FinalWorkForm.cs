using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_8
{
    public partial class FinalWorkForm : Form
    {
        public string searchString = String.Empty;
        public bool isSelected = false;
        public FinalWorkForm()
        {
            InitializeComponent();
        }

        private void examBox_CheckedChanged(object sender, EventArgs e)
        {
            if (creditBox.Checked && examBox.Checked)
            {
                creditBox.Checked = false;
            }
        }

        private void find_Click(object sender, EventArgs e)
        {
            searchString = examBox.Checked ? "0,5" : "0,35";
            isSelected = true;
            Close();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void creditBox_CheckedChanged(object sender, EventArgs e)
        {
            if (examBox.Checked && creditBox.Checked)
            {
                examBox.Checked = false;
            }
        }
    }
}
