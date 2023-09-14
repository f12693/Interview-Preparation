namespace Arithmetic
{
    internal class Program
    {
        // 主要是知道switch要怎麼用
        static void Main(string[] args)
        {
            while (true)
            {
                double num1 = GetDoubleInput();
                char operation = GetCharInput();
                double num2 = GetDoubleInput();
                double result = Arithmetic(num1, num2, operation);
                Console.WriteLine(result);
            }
        }
        static double GetDoubleInput()
        {
            double input;

            while (true)
            {
                if (double.TryParse(Console.ReadLine(), out input))
                    return input;
                else
                    Console.WriteLine("輸入錯誤,請重新輸入:");
            }
        }

        static char GetCharInput()
        {
            char input;

            while (true)
            {
                if (char.TryParse(Console.ReadLine(), out input))
                    return input;
                else
                    Console.WriteLine("輸入錯誤,請重新輸入:");
            }
        }

        static double Arithmetic(double num1, double num2, char operation)
        {
            switch (operation)
            {
                case '+':
                    return num1 + num2;
                case '-':
                    return num1 - num2;
                case '*':
                    return num1 * num2;
                case '/':
                    if (num2 != 0)
                    {
                        return num1 / num2;
                    }
                    else return double.NaN;
                default:
                    Console.WriteLine("無效的運算");
                    return double.NaN;
            }
        }
    }
}