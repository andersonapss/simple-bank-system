using Banks.Interfaces;

namespace Banks.Loggers
{
    public class FileLogger : ILogger
    {
        private readonly string filePath;

        public FileLogger(string filePath)
        {
            this.filePath = filePath;
        }
        public void Log(string message)
        {
        File.AppendAllText(filePath, $"{message}{Environment.NewLine}");
        }
    }
}