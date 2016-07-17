using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            Summator summator = new Summator();
            Subtractor subtractor = new Subtractor();
            summator.Calculate(3d, 2d);
            subtractor.Calculate(3d, 2d);

        }
    }
    abstract class ArithmeticOperation
    {
        public abstract void Calculate(double n1, double n2);
    }
    abstract class ArithmeticCalculation :ArithmeticOperation
    {
        protected double result;
        protected double num1;
        protected double num2;
        public sealed override void Calculate(double n1, double n2)
        {
            GetNum(n1, n2);
            DoOperation();
            ReturnResult();
            
        }
        protected virtual void GetNum(double n1, double n2)
        {
            num1 = n1;
            num2 = n2;
        }
        public abstract void DoOperation();
        protected virtual void ReturnResult()
        {
            Console.WriteLine("Result of culculation:{0}", result);
        }
    }
    class Summator : ArithmeticCalculation
    {
        public override void DoOperation()
        {
            result = num1 + num2;
        }
    }
    class Subtractor : ArithmeticCalculation
    {
        public override void DoOperation()
        {
            result = num1 - num2;
        }
    }
}
