using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicML
{
	public static class Logging
	{
		public static void Log(string s)
		{
			if (FormBasicML._formLoggingBox != null)
			{
				FormBasicML._formLoggingBox.AppendText(s);
				return;
			}

			Console.Write(s);
		}

		public static void LogLine(string s)
		{
			if (FormBasicML._formLoggingBox != null)
			{
				FormBasicML._formLoggingBox.AppendText(s + "\n");
				return;
			}

			Console.WriteLine(s);
		}
	}
}
