using System;
using System.Data;
using MySql.Data.MySqlClient;


namespace RAS_CORE
{
	/// <summary>
	/// Summary description for Unit.
	/// </summary>
	public class Unit
	{
		public Unit()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public int getEvtCode(string Code, string Zone)
		{
			MySqlConnection con;
			MySqlCommand mCmd = new MySqlCommand();
			int ret;

			try
			{
				RData MyConn=new RData();
				con = MyConn.GetConn();

				string SQL = "select zone" + Zone + " from usl_event_codes where code = '" +
					Code + "'";
				mCmd.Connection = con;
				mCmd.CommandText = SQL;
				ret = int.Parse(mCmd.ExecuteScalar().ToString());
				con.Close();
				return ret;
			} 
			catch
			{
				return 0;
			}

		}
		
		public int GetOldCode(int NewCode)
		{
			MySqlConnection con;
			MySqlCommand mCmd = new MySqlCommand();
			int ret;

			try
			{
				RData MyConn=new RData();
				con = MyConn.GetConn();

				string SQL = "select oldcode from zonecodes where newcode=" + NewCode;
				mCmd.Connection = con;
				mCmd.CommandText = SQL;
				ret = int.Parse(mCmd.ExecuteScalar().ToString());
				con.Close();
				return ret;
			} 
			catch
			{
				return 0;
			}
		}

		public bool Add_lp_Event(string Code, int Zone, int EvtCode, string Desc)
		{
			MySqlConnection con;
			MySqlCommand mCmd = new MySqlCommand();

			try
			{
				RData MyConn=new RData();
				con = MyConn.GetConn();

				string SQL = "insert into usl_events_low_pr values('" + Code + "'," + 
					Zone + ", getdate()," + EvtCode + ",'" + Desc + "')";
				mCmd.Connection = con;
				mCmd.CommandText = SQL;
				mCmd.ExecuteNonQuery();
				con.Close();
				return true;
			} 
			catch
			{
				return false;
			}
		}
		
	}
}
