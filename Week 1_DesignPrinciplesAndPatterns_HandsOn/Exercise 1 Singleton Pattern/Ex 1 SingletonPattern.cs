using System;

class Logger
{
    private static Logger? instance;

    private Logger()
    {
        Console.WriteLine("Logger initialized.");
    }

    public static Logger GetInstance()
    {
        if (instance == null)
        {
            instance = new Logger();
        }
        return instance;
    }

    public void Log(string message)
    {
        Console.WriteLine("Log: " + message);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Logger logger1 = Logger.GetInstance();
        Logger logger2 = Logger.GetInstance();

        logger1.Log("First message");
        logger2.Log("Second message");

        Console.WriteLine("Are both loggers same? " + (logger1 == logger2));
    }
}