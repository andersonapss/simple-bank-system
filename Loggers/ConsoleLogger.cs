using Banks.Interfaces;

namespace Banks.Loggers
{
    public class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine($"LOGGER: {message}");
        }

    
    }
}