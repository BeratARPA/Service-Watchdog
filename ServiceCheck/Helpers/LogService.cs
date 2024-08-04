using System;
using System.IO;
using System.Threading.Tasks;

namespace ServiceCheck.Helpers
{
    public enum LogLevel
    {
        Info,
        Warning,
        Error
    }

    public class LogService
    {
        private static readonly object _lock = new object();
        public static string PentegrasyonFolderPath = Path.Combine("C:\\ProgramData", "ServiceWatchdog");
        private static readonly string LogDirectory = Path.Combine(PentegrasyonFolderPath, "Logs");
        private static readonly string LogFile = Path.Combine(LogDirectory, "application.log");
        private static readonly int MaxLogFileSize = 10 * 1024 * 1024; // 10 MB

        static LogService()
        {
            CreateFolders();
        }

        private static void CreateFolders()
        {
            if (!Directory.Exists(PentegrasyonFolderPath))
            {
                Directory.CreateDirectory(PentegrasyonFolderPath);
            }

            if (!Directory.Exists(LogDirectory))
            {
                Directory.CreateDirectory(LogDirectory);
            }
        }      

        public static async Task LogAsync(string message, LogLevel level = LogLevel.Info)
        {
            string logMessage = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff} [{level}] {message}";
            await WriteLogAsync(logMessage);
        }

        private static async Task WriteLogAsync(string message)
        {
            CreateFolders();

            lock (_lock)
            {
                if (File.Exists(LogFile) && new FileInfo(LogFile).Length > MaxLogFileSize)
                {
                    RotateLog();
                }

                using (FileStream fileStream = new FileStream(LogFile, FileMode.Append, FileAccess.Write, FileShare.ReadWrite))
                using (StreamWriter writer = new StreamWriter(fileStream))
                {
                     writer.WriteLineAsync(message);
                }
            }
        }

        private static void RotateLog()
        {
            string archiveFile = Path.Combine(LogDirectory, $"application_{DateTime.Now:yyyyMMddHHmmss}.log");
            File.Move(LogFile, archiveFile);
        }

        public static void Log(string message, LogLevel level = LogLevel.Info)
        {
            CreateFolders();

            string logMessage = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff} [{level}] {message}";
            WriteLog(logMessage);
        }

        private static void WriteLog(string message)
        {
            CreateFolders();

            lock (_lock)
            {
                if (File.Exists(LogFile) && new FileInfo(LogFile).Length > MaxLogFileSize)
                {
                    RotateLog();
                }

                using (FileStream fileStream = new FileStream(LogFile, FileMode.Append, FileAccess.Write, FileShare.ReadWrite))
                using (StreamWriter writer = new StreamWriter(fileStream))
                {
                    writer.WriteLine(message);
                }
            }
        }
    }
}