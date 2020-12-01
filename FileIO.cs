using System;
using System.IO;
using System.Windows.Forms;

namespace RAS_CORE
{
	/// <summary>
	/// Summary description for FileIO.
	/// </summary>
	public class FileIO
	{
		private string logDay;
		public FileIO()
		{
		}

		public void ReadDayFile(DateTime sDate,ListBox lb)
		{
			string sYear	= sDate.Year.ToString();
			string sMonth	= sDate.Month.ToString();
			string sDay	= sDate.Day.ToString();

			string sRead=sDay+sMonth+sYear+".log";
			string input=null;

			if (File.Exists(@"C:\Logs\Data\"+sRead))
			{

				FileStream fs = new FileStream(@"C:\Logs\Data\"+sRead,
					FileMode.Open, FileAccess.Read, FileShare.None);

				StreamReader sr=new StreamReader(fs);
			
				while ((input=sr.ReadLine())!=null)
				{
					lb.Items.Add(input);
				}
				sr.Close();
				fs.Close();
			}

		}

		private void CreateDayFile()
		{
			string sYear	= DateTime.Now.Year.ToString();
			string sMonth	= DateTime.Now.Month.ToString();
			string sDay	= DateTime.Now.Day.ToString();

			logDay=sDay+sMonth+sYear+".log";
			FileStream fs = new FileStream(@"C:\Logs\Data\"+logDay,
				FileMode.CreateNew);
			//FileInfo logFile= new FileInfo(@"C:\Logs\Data\"+logDay);
			//logFile.Create();
			fs.Close();
		}

		public void WriteDayLog(string Data)
		{
			string sYear	= DateTime.Now.Year.ToString();
			string sMonth	= DateTime.Now.Month.ToString();
			string sDay	= DateTime.Now.Day.ToString();

			logDay=sDay+sMonth+sYear+".log";
			//if file does not exist..
			bool bExist=File.Exists(@"C:\Logs\Data\"+logDay);
			
			if (bExist)
			{
				//write the data
				StreamWriter sw=new StreamWriter(@"C:\Logs\Data\"+logDay,true);
				sw.WriteLine(Data);
				sw.Flush();
				sw.Close();
			} 
			else
			{
				//create the log file, then write the data
				this.CreateDayFile();
				StreamWriter sw=new StreamWriter(@"C:\Logs\Data\"+logDay,true);
				sw.WriteLine(Data);
				sw.Flush();
				sw.Close();
			}
		}



	}
}
