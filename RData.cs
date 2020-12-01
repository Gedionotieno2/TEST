using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.IO;
using System.Xml;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Configuration;

namespace RAS_CORE
{
	/// <summary>
	/// Summary description for RData.
	/// </summary>
	public class RData
	{
		private string UName;
		private string Server;
        private string Server_bkp; //the backup server in case the primary fails 
		public string Pwd;
		public string dBase;
		public string path;

		public RData()
		{
			setProps();
		}

		public void setProps()
		{
			//call this class to set the properties of the connection
			//read config information from xml file
			string temp, path;
			temp=Assembly.GetExecutingAssembly().Location;
			path=Regex.Replace(temp,@"RAS CORE.exe","")+"\\conf\\conf.xml";
			FileStream fs=new FileStream(@path,FileMode.Open);
			XmlTextReader txtRdr=new XmlTextReader(fs);
			while(!txtRdr.EOF)
			{
				if(txtRdr.MoveToContent()==XmlNodeType.Element && 
					txtRdr.Name=="server_main")
				{
					Server=txtRdr.ReadElementString();
					//System.Windows.Forms.MessageBox.Show(Server);
				}

				if(txtRdr.MoveToContent()==XmlNodeType.Element &&
					txtRdr.Name=="Database")
				{
					dBase=txtRdr.ReadElementString();
				}
				if(txtRdr.MoveToContent()==XmlNodeType.Element &&
					txtRdr.Name=="UserName")
				{
					UName=txtRdr.ReadElementString();
				}
				if (txtRdr.MoveToContent()==XmlNodeType.Element &&
					txtRdr.Name=="Password")
				{
					Pwd=txtRdr.ReadElementString();
				}
				else
				{
					txtRdr.Read();
				}
			}
			//clean up
			txtRdr.Close();
			fs.Close();
			txtRdr=null;
			fs=null;
		}
		public MySqlConnection GetConn()
		{
			//return a sql connection
			MySqlConnection TempConn;
			string Cred;
            try
            {
                Cred = ConfigurationManager.AppSettings["mysql_connection"];
                TempConn = new MySqlConnection(Cred);

                TempConn.Open();
                return TempConn;
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
			
		}

		public Receiver getReceiver(int RcvNum)
		{
			//return an RCI object
			Receiver rcv=new Receiver();
			try
			{
				MySqlDataReader rdr;
				MySqlCommand cmd=new MySqlCommand();
                string strSQL = "select recid,recfullname,portnum,recsettings,heartbeatdelay from ReceiversSetting where recid=" + RcvNum;

				cmd.Connection=GetConn();
				cmd.CommandText=strSQL;

				rdr=cmd.ExecuteReader();
				
				while (rdr.Read())
				{
					rcv.rcvCOMPort=short.Parse(rdr["portnum"].ToString());
					rcv.rcvName=rdr["recfullname"].ToString();
					rcv.Settings=rdr["recsettings"].ToString();
					rcv.iHeartBeat=int.Parse(rdr["heartbeatdelay"].ToString());
				}
				rdr.Close();
				return rcv;


			}
			catch (Exception ex)
			{
				MessageBox.Show("An error occured: " + ex.Message, "RAS CORE",
					MessageBoxButtons.OK,MessageBoxIcon.Hand); 
				return null;
			}

		}

        public void GetRcv(System.Windows.Forms.ListView lv)
        {
            try
            {
                MySqlDataReader dReader;
                MySqlCommand sCmd = new MySqlCommand();

                sCmd.Connection = GetConn();
                sCmd.CommandText = "select recid, recname, recfullname, portnum,recsettings, heartbeatdelay " +
                    "from ReceiversSetting";

                dReader = sCmd.ExecuteReader();
                while (dReader.Read())
                {
                    ListViewItem mItem = new ListViewItem();
                    mItem.Text = dReader[0].ToString();
                    mItem.SubItems.Add(dReader[1].ToString());
                    mItem.SubItems.Add(dReader[2].ToString());
                    mItem.SubItems.Add(dReader[3].ToString());
                    mItem.SubItems.Add(dReader[4].ToString());
                    mItem.SubItems.Add(dReader[5].ToString());
                    lv.Items.Add(mItem);
                }
            }
            catch (MySqlException ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
                return;
            }
        }

        public void saveFX_Evt(string evt_code, string usr_code, string evt_type, string evt_q,
            int sig_strength)
        {
            try
            {
                string sQuery = "insert into usl_fx_events values('" + evt_code + "','" + usr_code +
                    "','" + evt_type + "','" + evt_q + "'," + sig_strength + ", convert(datetime,'" +
                    DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + "',103))";
                MySqlConnection cn = GetConn();
                MySqlCommand cmd = new MySqlCommand(sQuery, cn);

                cmd.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                //write error to log
            }
        }
	}
}
