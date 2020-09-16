using System;

namespace Calculator
{
      internal class Program
      {

            delegate CalculatorResult Operation(double a, double b);
            public static void Main(string[] args)
            {
                Operation operation;
                CalculatorResult result;

                double a, b;
                string symbol = "";

                while(true)
                {
                    Console.WriteLine();

                    Console.Write("A: ");
                    a = Convert.ToDouble(Console.ReadLine());

                    Console.Write("B: ");
                    b = Convert.ToDouble(Console.ReadLine());

                    Console.Write("Operation: ");
                    symbol = Console.ReadLine();

                    switch (symbol)
                    {
                        case "+":
                            operation = Plus;
                            break;
                        case "-":
                            operation = Minus;
                            break;
                        case "*":
                            operation = Multiplication;
                            break;
                        case "/":
                        case ":":
                            operation = Division;
                            break;

                        default:
                            operation = UnknownOperation;
                            break;
                    }

                    result = operation(a, b);



                    if (!result.unknown)
                    {
                        Console.Write($"{a} {symbol} {b} = ");

                        if (result.infinity)
                        {
                            Console.WriteLine("Infinity");
                        }
                        else
                        {
                            Console.WriteLine(result.data);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Unknown operation");
                    }

                    Console.ReadKey();
                }
            
            }

            static public CalculatorResult Plus(double a, double b)
            {
                CalculatorResult result = new CalculatorResult();
                result.data = a + b;
                return result;
            }

            static public CalculatorResult Minus(double a, double b)
            {
                CalculatorResult result = new CalculatorResult();
                result.data = a - b;
                return result;
            }

            static public CalculatorResult Multiplication(double a, double b)
            {
                CalculatorResult result = new CalculatorResult();
                result.data = a * b;
                return result;
            }

            static public CalculatorResult Division(double a, double b)
            {
                CalculatorResult result = new CalculatorResult();
                
                if(a == 0)
                {
                    result.infinity = true;
                } else if (b != 0)
                {
                    result.data = a / b;
                }

                return result;
            }

            static public CalculatorResult UnknownOperation(double a, double b)
            {
                CalculatorResult result = new CalculatorResult();
                result.unknown = true;
                return result;
            }
    }

    class CalculatorResult
    {
        public double data = 0;
        public bool infinity = false;
        public bool unknown = false;
    }
}