using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;
using System.Collections;

namespace USL_Staff
{
    class cData
    {
        public bool AddNew(string[] values)
        {
            try
            {
                SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["SGSConnectionString"].ToString());
                cn.Open();
                string query_insert = "insert into usl_staff values('" + values[0] + "','" + values[1] + "','" + values[2] + "','" + values[3] + "','" + values[4]
                    + "',convert(datetime,'" + values[5] + "',103),convert(datetime,'" + values[6] + "',103),'" + values[7] + "','" + values[8] + "','"
                    + values[9] + "','" + values[10] + "','" + values[11] + "',null, '" + values[13] + "','" + values[14] + "','" + values[15] + "','" +
                    values[16] + "','" + values[17] +"','" +values[18] + "','" + values[19] + "')";

                SqlCommand cmd = new SqlCommand(query_insert, cn);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                cn.Close();
                cn.Dispose();

                return true;
            }
            catch(Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
                return false;
            }
        }

        public void GetList(ListView lv)
        {
            lv.Items.Clear();
            try
            {
                SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["SGSConnectionString"].ToString());
                cn.Open();
                string query = "select staffno, firstname + ' ' + Surname as Name  from usl_staff";

                SqlCommand cmd = new SqlCommand(query, cn);
                SqlDataReader rdr;

                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    ListViewItem n = new ListViewItem();
                    n.Text = rdr[0].ToString();
                    n.SubItems.Add(rdr[1].ToString());
                    lv.Items.Add(n);
                }

                cmd.Dispose();
                cn.Close();
                cn.Dispose();


            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
            }

        }

        public ArrayList getDetails(string staff_no)
        {
            ArrayList mList = new ArrayList();
            try
            {
                SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["SGSConnectionString"].ToString());
                cn.Open();
                string query = "select *  from usl_staff where staffno='" + staff_no + "'";

                SqlCommand cmd = new SqlCommand(query, cn);
                SqlDataReader rdr;

                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    mList.Add(rdr[0].ToString());
                    mList.Add(rdr[1].ToString());
                    mList.Add(rdr[2].ToString());
                    mList.Add(rdr[3].ToString());
                    mList.Add(rdr[4].ToString());
                    mList.Add(rdr[5].ToString());
                    mList.Add(rdr[6].ToString());
                    mList.Add(rdr[7].ToString());
                    mList.Add(rdr[8].ToString());
                    mList.Add(rdr[9].ToString());
                    mList.Add(rdr[10].ToString());
                    mList.Add(rdr[11].ToString());
                    mList.Add("");
                    mList.Add(rdr[13].ToString());
                    mList.Add(rdr[14].ToString());
                    mList.Add(rdr[15].ToString());
                    mList.Add(rdr[16].ToString());
                    mList.Add(rdr[17].ToString());
                    mList.Add(rdr[18].ToString());
                    mList.Add(rdr[19].ToString());
                }

                cmd.Dispose();
                cn.Close();
                cn.Dispose();


            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
            }
            return mList;
        }

        public bool Update(string[] info)
        {
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["SGSConnectionString"].ToString());

            try
            {
                cn.Open();

                SqlDataAdapter sda;
                DataSet ds= new DataSet();

                sda = new SqlDataAdapter("select top 1 * from usl_staff where staffno='" + info[0] + "'", cn);

                SqlCommandBuilder cbuilder = new SqlCommandBuilder(sda);
                sda.Fill(ds);

                ds.Tables[0].PrimaryKey = new DataColumn[] { ds.Tables[0].Columns["StaffNo"] };

                DataRow uRow = ds.Tables[0].Rows.Find(info[0]);
                uRow.BeginEdit();
                uRow[1] = info[1];
                uRow[2] = info[2];
                uRow[3] = info[3];
                uRow[4] = info[4];
                uRow[5] = DateTime.Parse(info[5]);
                uRow[6] = DateTime.Parse(info[6]);
                uRow[7] = info[7];
                uRow[8] = info[8];
                uRow[9] = info[9];
                uRow[10] = info[10];
                uRow[11] = info[11];
                uRow[13] = info[13];
                uRow[14] = info[14];
                uRow[15] = info[15];
                uRow[16] = info[16];
                uRow[17] = info[17];
                uRow[18] = info[18];
                uRow[19] = info[19];

                uRow.EndEdit();

                sda.Update(ds);

                cn.Close();
                cn.Dispose();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            finally
            {
                if (cn.State == ConnectionState.Open)
                    cn.Close();
            }
        }

        public bool AddWarning(string staff_no, DateTime dt, string desc)
        {
            try
            {
                SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["SGSConnectionString"].ToString());
                cn.Open();
                string query_insert = "insert into usl_warn values('"+staff_no + "',convert(datetime,'" + dt.ToShortDateString() + "',103),'" + desc + "')";

                SqlCommand cmd = new SqlCommand(query_insert, cn);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                cn.Close();
                cn.Dispose();

                return true;
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
                return false;
            }
        }

        public void getWarning(string staff_no, ListView lv)
        {
            lv.Items.Clear();
            try
            {
                SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["SGSConnectionString"].ToString());
                cn.Open();
                string query = "select *  from usl_warn where staffno='" + staff_no + "'";

                SqlCommand cmd = new SqlCommand(query, cn);
                SqlDataReader rdr;

                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    ListViewItem n = new ListViewItem();
                    n.Text = DateTime.Parse(rdr[2].ToString()).ToShortDateString();
                    n.SubItems.Add(rdr[3].ToString());
                    lv.Items.Add(n);
                }

                cmd.Dispose();
                cn.Close();
                cn.Dispose();


            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
            }

        }

        public void Search(string name, ListView lv)
        {
            string query;
            lv.Items.Clear();

            try
            {
                SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["SGSConnectionString"].ToString());
                cn.Open();
                if (name == "*")
                    query = "select staffno, firstname + ' ' + Surname as Name  from usl_staff";
                else
                    query = "select staffno, firstname + ' ' + Surname as Name  from usl_staff where firstname like '%" + name +
                        "%' or surname like '%" + name + "%'";

                SqlCommand cmd = new SqlCommand(query, cn);
                SqlDataReader rdr;

                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    ListViewItem n = new ListViewItem();
                    n.Text = rdr[0].ToString();
                    n.SubItems.Add(rdr[1].ToString());
                    lv.Items.Add(n);
                }

                cmd.Dispose();
                cn.Close();
                cn.Dispose();


            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
            }
        }

        public bool Delete(string staffno)
        {
            try
            {
                SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["SGSConnectionString"].ToString());
                cn.Open();
                string query_insert = "delete from usl_staff where staffno='" + staffno + "'";

                SqlCommand cmd = new SqlCommand(query_insert, cn);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                cn.Close();
                cn.Dispose();

                return true;
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
                return false;
            }
        }

        public void LoadBase(ComboBox cb)
        {
            try
            {
                SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["SGSConnectionString"].ToString());
                cn.Open();
                string query = "select base_name from Base";

                SqlCommand cmd = new SqlCommand(query, cn);
                SqlDataReader rdr;

                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                   cb.Items.Add(rdr[0].ToString());
                }

                cmd.Dispose();
                cn.Close();
                cn.Dispose();


            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
            }
        }
    }

   
}
