using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentBL.Helpers
{
	using System.IO;
	using System.Reflection;


	public static class LogWriteHeper
	{
		private static string m_exePath = string.Empty;
        //public LogWriteHeper()
        //{
            
        //}
        //public LogWriteHeper(string logMessage)
        //{
        //	LogWrite(logMessage);
        //}
        public static void LogWrite(string logMessage)
		{
			m_exePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
			try
			{
				using (StreamWriter w = File.AppendText(m_exePath + "\\" + "stulog.txt"))
				{
					Log(logMessage, w);
				}
			}
			catch (Exception ex)
			{
			}
		}

		 static void Log(string logMessage, TextWriter txtWriter)
		{
			try
			{
				txtWriter.Write("\r\n Student Log Entry : ");
				txtWriter.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
					DateTime.Now.ToLongDateString());
				txtWriter.WriteLine("  :");
				txtWriter.WriteLine("  :{0}", logMessage);
				txtWriter.WriteLine("-------------------------------");
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
