using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Data.SqlClient;
using System.Configuration;

namespace USL_Staff
{
    public partial class frmDetails : Form
    {
        string imagename;
        cData data_proxy;

        public frmDetails()
        {
            InitializeComponent();
        }

        private void frmDetails_Load(object sender, EventArgs e)
        {
            data_proxy = new cData();

            btnEdit.Enabled = false;
            btnSave.Enabled = false;

            lvNames.View = View.Details;
            lvNames.Columns.Add(new ColumnHeader());
            lvNames.Columns.Add(new ColumnHeader());

            lvNames.Columns[0].Text = "Staff No";
            lvNames.Columns[0].Width = lvNames.Width * 3/10;
            lvNames.Columns[1].Text = "Staff No";
            lvNames.Columns[1].Width = (lvNames.Width * 7/10)-3;

            data_proxy.GetList(lvNames);

            data_proxy.LoadBase(cbBase);

            //enable disable
            groupBox1.Enabled = false;
            groupBox3.Enabled = false;
            groupBox5.Enabled = false;
            groupBox6.Enabled = false;

            //warning list
            lvWarn.View = View.Details;
            lvWarn.Columns.Add(new ColumnHeader());
            lvWarn.Columns.Add(new ColumnHeader());

            lvWarn.Columns[0].Text = "Warning Date";
            lvWarn.Columns[0].Width = lvWarn.Width * 3 / 10;
            lvWarn.Columns[1].Text = "Description";
            lvWarn.Columns[1].Width = (lvNames.Width * 7 / 10) - 3;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {

            try
            {
                FileDialog fldlg = new OpenFileDialog();

                fldlg.InitialDirectory = @":C\";
                fldlg.Filter = "Image File (*.jpg;*.bmp;*.gif)|*.jpg;*.bmp;*.gif";


                if (fldlg.ShowDialog() == DialogResult.OK)
                {

                    imagename = fldlg.FileName;
                    Bitmap newimg = new Bitmap(imagename);
                    pic.SizeMode = PictureBoxSizeMode.StretchImage;
                    pic.Image = (Image)newimg;
                }

                fldlg = null;

            }



            catch (System.ArgumentException ae)
            {
                imagename = " ";
                MessageBox.Show(ae.Message.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }


        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            foreach (Control c in groupBox1.Controls)
            {
                if (c.GetType().ToString() == "System.Windows.Forms.TextBox")
                {
                    if (c.Text == "")
                    {
                        MessageBox.Show("Please Enter Data in the required fields", "Error",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }

            foreach (Control c in groupBox3.Controls)
            {
                if (c.GetType().ToString() == "System.Windows.Forms.TextBox")
                {
                    if (c.Text == "")
                    {
                        MessageBox.Show("Please Enter Data in the required fields", "Error",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }

            string[] info= new string[20];
            info[0] = txtStaffNo.Text;
            info[1] = txtIDNo.Text;
            info[2] = txtFName.Text;
            info[3] = txtMName.Text;
            info[4] = txtSName.Text;
            info[5] = dtpDob.Value.ToShortDateString();
            info[6] = dtpEmp.Value.ToShortDateString();
            info[7] = txtDist.Text;
            info[8] = txtDiv.Text;
            info[9] = txtLoc.Text;
            info[10] = txtSubLoc.Text;
            info[11] = txtRes.Text;
            info[12] = "";
            info[13] = txtFirstRef.Text;
            info[14] = txtFirstRefRel.Text;
            info[15] = txtSecRef.Text;
            info[16] = txtSecRefRel.Text;
            info[17] = cbBase.Text;
            info[18] = txtMobile.Text;
            info[19] = txtEmail.Text;

            cData data = new cData();
            if (data.AddNew(info))
            {
                MessageBox.Show("New Record Added", "Information",
                          MessageBoxButtons.OK, MessageBoxIcon.Information);
                groupBox1.Enabled = false;
                groupBox3.Enabled = false;
                groupBox5.Enabled = false;
                groupBox6.Enabled = false;
                data_proxy.GetList(lvNames);
            }


        }

        private void btnSavePic_Click(object sender, EventArgs e)
        {
            try
            {
                if (imagename != "")
                {
                    FileStream fs;
                    fs = new FileStream(@imagename, FileMode.Open, FileAccess.Read);

                    //a byte array to read the image
                    byte[] picbyte = new byte[fs.Length];
                    fs.Read(picbyte, 0, System.Convert.ToInt32(fs.Length));
                    fs.Close();


                    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SGSConnectionString"].ToString());
                    conn.Open();

                    string query = "update usl_staff set photo= @pic where StaffNo='" + txtStaffNo.Text + "'";
                    SqlParameter picparameter = new SqlParameter();
                    picparameter.SqlDbType = SqlDbType.Image;
                    picparameter.ParameterName = "pic";
                    picparameter.Value = picbyte;

                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.Add(picparameter);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Image Added","Update",MessageBoxButtons.OK,MessageBoxIcon.Information);

                    cmd.Dispose();
                    conn.Close();
                    conn.Dispose();

                }

            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }
        }

        private void lvNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            //enable disable
            groupBox1.Enabled = false;
            groupBox3.Enabled = false;
            groupBox5.Enabled = false;
            groupBox6.Enabled = false;
            btnSave.Enabled = false;

            //retrieve currently selected staff details
            string staff_no;
            btnEdit.Enabled = true;

            foreach (ListViewItem n in lvNames.SelectedItems)
            {
                staff_no = n.Text;
                ArrayList aL = data_proxy.getDetails(staff_no);
                txtStaffNo.Text = aL[0].ToString();
                txtIDNo.Text = aL[1].ToString();
                txtFName.Text=aL[2].ToString();
                txtMName.Text=aL[3].ToString();
                txtSName.Text = aL[4].ToString();
                dtpDob.Value = DateTime.Parse(aL[5].ToString());
                dtpEmp.Value = DateTime.Parse(aL[6].ToString()); ;
                txtDist.Text = aL[7].ToString();
                txtDiv.Text = aL[8].ToString();
                txtLoc.Text = aL[9].ToString();
                txtSubLoc.Text = aL[10].ToString();
                txtRes.Text = aL[11].ToString();
                txtFirstRef.Text = aL[13].ToString();
                txtFirstRefRel.Text = aL[14].ToString();
                txtSecRef.Text = aL[15].ToString();
                txtSecRefRel.Text = aL[16].ToString();
                cbBase.Text = aL[17].ToString();
                txtMobile.Text = aL[18].ToString();
                txtEmail.Text = aL[19].ToString();
                //retrieve photo

                if (pic.Image != null)
                    pic.Image= null;

                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SGSConnectionString"].ToString());

                try
                {
                    conn.Open();

                    string squery = "select Photo from usl_staff where staffno='" + staff_no + "'";

                    SqlCommand cmd = new SqlCommand(squery, conn);

                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();

                    sda.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0]["Photo"].ToString()=="")
                            return;
                        MemoryStream ms = new MemoryStream((byte[])dt.Rows[0]["Photo"]);
                        pic.Image = Image.FromStream(ms);
                        pic.SizeMode = PictureBoxSizeMode.StretchImage;
                        pic.Refresh();
                    }


                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                finally
                {
                    if (conn.State == ConnectionState.Open)
                        conn.Close();
                }

                //get the warnings
                data_proxy.getWarning(txtStaffNo.Text, lvWarn);

            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            //enable disable
            groupBox1.Enabled = true;
            groupBox3.Enabled = true;
            groupBox5.Enabled = true;
            groupBox6.Enabled = true;

            txtStaffNo.Enabled = false;

            if (btnEdit.Text == "Edit")
            {
                btnEdit.Text = "Update";
                return;
            }

            if (btnEdit.Text == "Update")
            {
                //update details
                string[] info = new string[20];
                info[0] = txtStaffNo.Text;
                info[1] = txtIDNo.Text;
                info[2] = txtFName.Text;
                info[3] = txtMName.Text;
                info[4] = txtSName.Text;
                info[5] = dtpDob.Value.ToShortDateString();
                info[6] = dtpEmp.Value.ToShortDateString();
                info[7] = txtDist.Text;
                info[8] = txtDiv.Text;
                info[9] = txtLoc.Text;
                info[10] = txtSubLoc.Text;
                info[11] = txtRes.Text;
                info[12] = "";
                info[13] = txtFirstRef.Text;
                info[14] = txtFirstRefRel.Text;
                info[15] = txtSecRef.Text;
                info[16] = txtSecRefRel.Text;
                info[17] = cbBase.Text;
                info[18] = txtMobile.Text;
                info[19] = txtEmail.Text;

                if (data_proxy.Update(info))
                {
                    MessageBox.Show("Data Updated", "Update",
                          MessageBoxButtons.OK, MessageBoxIcon.Information);
                    groupBox1.Enabled = false;
                    groupBox3.Enabled = false;
                    groupBox5.Enabled = false;
                    groupBox6.Enabled = false;
                }
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            //enable disable
            groupBox1.Enabled = true;
            groupBox3.Enabled = true;
            groupBox5.Enabled = true;
            groupBox6.Enabled = true;
            btnSave.Enabled = true;

            if (!btnNew.Enabled) btnNew.Enabled = true;

            foreach (Control c in groupBox1.Controls)
            {
                if (c.GetType().ToString() == "System.Windows.Forms.TextBox")
                    c.Text = "";
            }

            foreach (Control c in groupBox3.Controls)
            {
                if (c.GetType().ToString() == "System.Windows.Forms.TextBox")
                    c.Text = "";
            }

            foreach (Control c in groupBox5.Controls)
            {
                if (c.GetType().ToString() == "System.Windows.Forms.TextBox")
                    c.Text = "";
            }

            foreach (Control c in groupBox6.Controls)
            {
                if (c.GetType().ToString() == "System.Windows.Forms.TextBox")
                    c.Text = "";
            }

            cbBase.Text = "";

            cbBase.Text = "";
            if (pic.Image != null)
                pic.Image=null;
            dtpDob.Value = DateTime.Now;
            dtpEmp.Value = DateTime.Now;
        }

        private void btnWarn_Click(object sender, EventArgs e)
        {
            warning wrn = new warning(txtFName.Text + " " + txtSName.Text,txtStaffNo.Text);
            wrn.ShowDialog();
        }

        private void dtpDob_ValueChanged(object sender, EventArgs e)
        {
            DateTime zeroTime = new DateTime(1, 1, 1);
            TimeSpan t = DateTime.Now - dtpDob.Value;

            int years = (zeroTime + t).Year - 1;
            txtAge.Text = years.ToString();
        }

        private void txtSrch_TextChanged(object sender, EventArgs e)
        {
            if (txtSrch.Text.Length > 3)
                data_proxy.Search(txtSrch.Text, lvNames);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this record?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (data_proxy.Delete(txtStaffNo.Text))
                {
                    MessageBox.Show("Record Deleted", "Delete",
                         MessageBoxButtons.OK, MessageBoxIcon.Information);
                    foreach (Control c in groupBox1.Controls)
                    {
                        if (c.GetType().ToString() == "System.Windows.Forms.TextBox")
                            c.Text = "";
                    }

                    foreach (Control c in groupBox3.Controls)
                    {
                        if (c.GetType().ToString() == "System.Windows.Forms.TextBox")
                            c.Text = "";
                    }

                    foreach (Control c in groupBox5.Controls)
                    {
                        if (c.GetType().ToString() == "System.Windows.Forms.TextBox")
                            c.Text = "";
                    }

                    foreach (Control c in groupBox6.Controls)
                    {
                        if (c.GetType().ToString() == "System.Windows.Forms.TextBox")
                            c.Text = "";
                    }

                    cbBase.Text = "";
                    if (pic.Image != null)
                        pic.Image = null;
                    dtpDob.Value = DateTime.Now;
                    dtpEmp.Value = DateTime.Now;
                }
            }
        }

        private void frmDetails_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        
    }
}
