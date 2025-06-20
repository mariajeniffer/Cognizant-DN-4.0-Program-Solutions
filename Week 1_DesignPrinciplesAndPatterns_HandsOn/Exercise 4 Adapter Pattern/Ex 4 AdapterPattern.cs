using System;

interface IPaymentProcessor
{
    void ProcessPayment(double amount);
}

class PayPalGateway
{
    public void SendPayment(double amount)
    {
        Console.WriteLine("Processing PayPal payment: Rs." + amount);
    }
}

class StripeGateway
{
    public void MakePayment(double amount)
    {
        Console.WriteLine("Processing Stripe payment: Rs." + amount);
    }
}

class PayPalAdapter : IPaymentProcessor
{
    private PayPalGateway gateway;

    public PayPalAdapter()
    {
        this.gateway = new PayPalGateway();
    }

    public void ProcessPayment(double amount)
    {
        gateway.SendPayment(amount);
    }
}

class StripeAdapter : IPaymentProcessor
{
    private StripeGateway gateway;

    public StripeAdapter()
    {
        this.gateway = new StripeGateway();
    }

    public void ProcessPayment(double amount)
    {
        gateway.MakePayment(amount);
    }
}

class AdapterPatternExample
{
    static void Main(string[] args)
    {
        IPaymentProcessor paypal = new PayPalAdapter();
        paypal.ProcessPayment(100);

        IPaymentProcessor stripe = new StripeAdapter();
        stripe.ProcessPayment(200);
    }
}
