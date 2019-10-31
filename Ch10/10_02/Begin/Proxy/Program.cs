using System;

/// <summary>
/// This code demonstrates the Proxy pattern for a Math object 
/// represented by a CalculateProxy object.
/// </summary>
namespace Proxy.Demonstration
{
    /// <summary>
    /// Proxy Design Pattern.
    /// </summary>
    class Client    
    {
        static void Main()
        {
            // Create math proxy
            //IE, create a calculator instead of some platonic "math"
            //note we call the proxy/calculator's methods, not the methods from Math.
            //but THOSE methods call Math's methods.
            CalculateProxy proxy = new CalculateProxy();

            // Do some math
            //We do the math, but only via the help of the proxy.
            Console.WriteLine("Calculations");
            Console.WriteLine("-------------");
            Console.WriteLine("\n10 + 5 = " + proxy.Add(10, 5));
            Console.WriteLine("\n10 - 5 = " + proxy.Subtract(10, 5));
            Console.WriteLine("\n10 * 5 = " + proxy.Multiply(10, 5));
            Console.WriteLine("\n10 / 5 = " + proxy.Divide(10, 5));

            // Wait for user
            Console.ReadKey();
        }
    }

    /// <summary>
    /// The 'Subject interface
    /// </summary>
    public interface IMath
    {
        double Add(double x, double y);
        double Subtract(double x, double y);
        double Multiply(double x, double y);
        double Divide(double x, double y);
    }

    /// <summary>
    /// The 'RealSubject' class
    /// </summary>
    //Here is where the logic happens. Ie, the real math.
    class Math : IMath
    {
        public double Add(double x, double y) { return x + y; }
        public double Subtract(double x, double y) { return x - y; }
        public double Multiply(double x, double y) { return x * y; }
        public double Divide(double x, double y) { return x / y; }
    }

    /// <summary>
    /// The 'Proxy Object' class
    /// </summary>
    //This is what the client will use.
    //They only see the calculator. They don't see the math happening.
    class CalculateProxy : IMath
    {
        private Math _math = new Math();

        public double Add(double x, double y)
        {
            return _math.Add(x, y);
        }
        public double Subtract(double x, double y)
        {
            return _math.Subtract(x, y);
        }
        public double Multiply(double x, double y)
        {
            return _math.Multiply(x, y);
        }
        public double Divide(double x, double y)
        {
            return _math.Divide(x, y);
        }
    }
}

/*
PROXY PATTERN

A surrogate or placeholder for another object to control access to it.

Provides objects that reference other objects for their functionality.
It's useful when you want to give a client access to some logic,
but don't want/need to share details of how the logic works.

Our example will be a proxy involving math and a calculator.
     
*/