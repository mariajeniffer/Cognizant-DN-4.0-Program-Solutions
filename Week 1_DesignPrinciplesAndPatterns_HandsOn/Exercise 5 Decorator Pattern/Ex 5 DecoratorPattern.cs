using System;

interface INotifier
{
    void Send(string message);
}

class EmailNotifier : INotifier
{
    public void Send(string message)
    {
        Console.WriteLine("Email: " + message);
    }
}

abstract class NotifierDecorator : INotifier
{
    protected INotifier notifier;

    public NotifierDecorator(INotifier notifier)
    {
        this.notifier = notifier;
    }

    public abstract void Send(string message);
}

class SMSNotifierDecorator : NotifierDecorator
{
    public SMSNotifierDecorator(INotifier notifier) : base(notifier) { }

    public override void Send(string message)
    {
        notifier.Send(message);
        Console.WriteLine("SMS: " + message);
    }
}

class SlackNotifierDecorator : NotifierDecorator
{
    public SlackNotifierDecorator(INotifier notifier) : base(notifier) { }

    public override void Send(string message)
    {
        notifier.Send(message);
        Console.WriteLine("Slack: " + message);
    }
}

class DecoratorPatternExample
{
    static void Main(string[] args)
    {
        INotifier notifier = new SlackNotifierDecorator(
                                new SMSNotifierDecorator(
                                    new EmailNotifier()));
        notifier.Send("Hello, world!");
    }
}
