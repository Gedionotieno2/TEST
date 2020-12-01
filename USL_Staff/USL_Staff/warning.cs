using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace USL_Staff
{
    public partial class warning : Form
    {
        private string str_name;
        private string staffno;

        public warning(string s_name, string staff_num)
        {
            InitializeComponent();
            str_name = s_name;
            staffno = staff_num;
        }

        private void warning_Load(object sender, EventArgs e)
        {
            lblName.Text = str_name;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            cData data = new cData();
            if (data.AddWarning(staffno, dtp.Value, txtDesc.Text))
            {
                MessageBox.Show("Warning Added", "Update",
                          MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }
    }
}
