using System;

namespace Calculator
{
      internal class Program
      {
            public static void Main(string[] args)
            {
                Calculator calculator = new Calculator();
                calculator.Subscribe += ShowResult;

                while(true)
                {
                    try
                    {
                        CalculatorTask task = InputCalculatorTask();
                        calculator.Сalculate(task);
                    } catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }   
            }

            public static CalculatorTask InputCalculatorTask()
            {
                CalculatorTask task = new CalculatorTask();

                Console.WriteLine();
                Console.Write("A: ");
                task.number1 = Convert.ToDouble(Console.ReadLine());

                Console.Write("B: ");
                task.number2 = Convert.ToDouble(Console.ReadLine());

                Console.Write("Operation: ");
                task.symbol = Console.ReadLine();


                switch (task.symbol)
                {
                    case "+":
                        task.command = Command.Add;
                        break;

                    case "-":
                        task.command = Command.Subtract;
                        break;

                    case "*":
                        task.command = Command.Multiply;
                        break;

                    case "/":
                    case ":":
                        task.command = Command.Divide;
                        break;

                    default:
                        task.command = Command.Unknown;
                        break;
                }

                return task;
            }

            public static void ShowResult(CalculatorTask task, CalculatorResult result)
            {
                if (!result.unknown)
                {
                    Console.Write($"{task.number1} {task.symbol} {task.number2} = ");

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
            }
      }

}