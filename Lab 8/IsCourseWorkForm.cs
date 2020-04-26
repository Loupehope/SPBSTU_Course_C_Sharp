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
    public partial class IsCourseWorkForm : Form
    {
        public string searchString = String.Empty;
        public bool isSelected = false;
        public IsCourseWorkForm()
        {
            InitializeComponent();
        }

        private void find_Click(object sender, EventArgs e)
        {
            searchString = isCourseBox.Checked ? "true" : "false";
            isSelected = true;
            Close();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
