using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicML
{
	public static class Logging
	{
		public enum LoggingDestination
		{
			LogBox = 0,
			ProgramOutput = 1,
			Console = 2
		}


		public static void Log(string s, LoggingDestination destination = LoggingDestination.LogBox)
		{
			switch(destination)
			{
				case LoggingDestination.LogBox:
					if (FormBasicML._formLoggingBox != null)
					{
						FormBasicML._formLoggingBox.AppendText(s);
						return;
					}
					break;
				case LoggingDestination.ProgramOutput:
					if (FormBasicML._formProgramOutputBox != null)
					{
						FormBasicML._formProgramOutputBox.AppendText(s);
						return;
					}
					break;
				default:
					break;
			}

			Console.Write(s);
		}

		public static void LogLine(string s, LoggingDestination destination = LoggingDestination.LogBox) { Log(s + "\n", destination); }
	}
}
