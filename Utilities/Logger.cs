using System;
using TaleWorlds.Library;

namespace DisableRandomColors.Utilities
{
	public static class Logger
	{
		/// <summary>
		/// Generic logging method.
		/// </summary>
		public static void Log(string message, LogLevel level = LogLevel.Information)
		{
#if DEBUG
			// In Debug build, log everything
#else
            // In Release build, skip Debug logs
            if (level == LogLevel.Debug)
            {
                return;
            }
#endif
			InformationManager.DisplayMessage(new InformationMessage(message, GetColorForLogLevel(level)));
		}

		private static Color GetColorForLogLevel(LogLevel level)
		{
			switch (level)
			{
				case LogLevel.Information:
					return Colors.Cyan;
				case LogLevel.Debug:
					return Colors.Cyan;
				case LogLevel.Warning:
					return Colors.Yellow;
				case LogLevel.Error:
					return Colors.Red;
				default:
					throw new ArgumentException("Invalid log level specified.");
			}
		}

		public enum LogLevel
		{
			Information,
			Debug,
			Warning,
			Error
		}
	}
}
