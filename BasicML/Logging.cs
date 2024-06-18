using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicML
{
	public static class Logging
	{
		public static RichTextBox _logBox;				// The location that output logs are written to

		public static void Log(string s)
		{
			if (_logBox != null)
			{
				_logBox.AppendText(s);
				return;
			}

			Console.Write(s);
		}

		public static void LogLine(string s)
		{
			if (_logBox != null)
			{
				_logBox.AppendText(s + "\n");
				return;
			}

			Console.WriteLine(s);
		}
	}
}
