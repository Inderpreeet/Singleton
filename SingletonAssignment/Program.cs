using System;

class Logger
{
    private static Logger _instance;
    private static readonly object _lock = new object();

    // Constructor is hidden (private)
    private Logger() {}

    // Property is used to access the instance
    public static Logger Instance
    {
        get
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new Logger();
                    }
                }
            }
            return _instance;
        }
    }

    // Logging function is not static
    public void Log(string message)
    {
        Console.WriteLine(message);
    }
}

// Using it in a basic console application
class Program
{
    static void Main()
    {
        Logger log1 = Logger.Instance;
        Logger log2 = Logger.Instance;

        log1.Log("This is a singleton log message.");

        Console.WriteLine(log1 == log2 ? "Same instance" : "Different instances");
    }
}


