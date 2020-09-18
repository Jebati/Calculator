using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    enum Command
    {
        Unknown = 0,
        Add = 1,
        Subtract,
        Multiply, 
        Divide
    }

    class CalculatorTask
    {
        public double number1;
        public double number2;
        public string symbol;
        public Command command;
    }

    class CalculatorResult
    {
        public double data = 0;
        public bool infinity = false;
        public bool unknown = false;
    }

    class Calculator
    {
        private delegate CalculatorResult Operation(double number1, double number2);

        public delegate void ResultHandler(CalculatorTask task, CalculatorResult result);
        public event ResultHandler Subscribe;

        public void Сalculate(CalculatorTask task)
        {

            Operation operation = Unknown;

            switch (task.command)
            {
                case Command.Add:
                    operation = Add;
                    break;
                case Command.Subtract:
                    operation = Subtract;
                    break;
                case Command.Multiply:
                    operation = Multiply;
                    break;
                case Command.Divide:
                    operation = Divide;
                    break;
            }

            CalculatorResult result = operation(task.number1, task.number2);
            Subscribe?.Invoke(task, result);
        }

        private static CalculatorResult Unknown(double number1, double number2)
        {
            CalculatorResult result = new CalculatorResult();
            result.unknown = false;
            return result;
        }

        private static CalculatorResult Add(double number1, double number2)
        {
            CalculatorResult result = new CalculatorResult();
            result.data = number1 + number2;
            return result;
        }

        private static CalculatorResult Subtract(double number1, double number2)
        {
            CalculatorResult result = new CalculatorResult();
            result.data = number1 - number1;
            return result;
        }

        private static CalculatorResult Multiply(double number1, double number2)
        {
            CalculatorResult result = new CalculatorResult();
            result.data = number1 * number2;
            return result;
        }

        private static CalculatorResult Divide(double number1, double number2)
        {
            CalculatorResult result = new CalculatorResult();

            if (number1 == 0)
            {
                result.infinity = true;
            }
            else if (number2 != 0)
            {
                result.data = number1 / number2;
            }

            return result;
        }
    }
}
