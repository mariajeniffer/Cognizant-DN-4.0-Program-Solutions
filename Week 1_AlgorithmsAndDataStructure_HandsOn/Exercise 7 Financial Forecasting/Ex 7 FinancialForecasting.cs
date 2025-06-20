using System;

class FinancialForecasting
{
    // Recursive method to calculate future value
    public static double CalculateFutureValue(double presentValue, double growthRate, int years)
    {
        if (years == 0)
            return presentValue;
        else
            return (1 + growthRate) * CalculateFutureValue(presentValue, growthRate, years - 1);
    }

    // Optimized version using memoization (optional)
    public static double CalculateFutureValueOptimized(double presentValue, double growthRate, int years)
    {
        double[] memo = new double[years + 1];
        return Helper(presentValue, growthRate, years, memo);
    }

    private static double Helper(double pv, double rate, int n, double[] memo)
    {
        if (n == 0) return pv;
        if (memo[n] != 0) return memo[n];
        memo[n] = (1 + rate) * Helper(pv, rate, n - 1, memo);
        return memo[n];
    }

    static void Main()
    {
        double presentValue = 10000; // Rs.10,000
        double growthRate = 0.05; // 5% annual growth
        int years = 5;

        double futureValue = CalculateFutureValue(presentValue, growthRate, years);
        Console.WriteLine($"📊 Future value after {years} years (Recursion): Rs.{futureValue:F2}");

        double optimizedValue = CalculateFutureValueOptimized(presentValue, growthRate, years);
        Console.WriteLine($"⚡ Future value after {years} years (Optimized): Rs.{optimizedValue:F2}");
    }
}

