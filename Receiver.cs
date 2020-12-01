using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace RAS_CORE
{
	/// <summary>
	/// Summary description for Receiver.
	/// </summary>
	public class Receiver
	{
		//public properties
		public Int32 rcvBaud;
		public short rcvCOMPort;
		public Int32 rcvDataBits;
		public string rcvParity;
		public Int32 rcvStopBits;
		public string Settings;
		public string rcvName;
		public int iHeartBeat;

		public Receiver()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public bool AddRcv()
		{
			return true;
		}

		public void GetRcv(System.Windows.Forms.ListView lv)
		{
			try
			{
				MySqlDataReader dReader;
				MySqlCommand sCmd=new MySqlCommand();

				RData MyConn=new RData();
				sCmd.Connection=MyConn.GetConn();
				sCmd.CommandText="select * from ras_core_receivers";

				dReader=sCmd.ExecuteReader();

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
                return;
			}
			catch(MySqlException ex)
			{
				System.Windows.Forms.MessageBox.Show(ex.ToString());
				return;
			}
		}

		public bool DelRcv(string RcvID)
		{
			return true;
		}

		public Receiver GetRcv(string RcvID)
		{
			return null;
		}
		
	}
}
