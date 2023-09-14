using System.Threading.Channels;

namespace Fibonacci_sequence
{
    internal class Program
    {
        // 標準費氏數列解法,以及遞迴函式(recursive function)
        static void Main(string[] args)
        {
            int input = GetInput();
            int sum = 0;
            for (int i = 0; i < input; i++)
                sum += Fibonacci(i);
            Console.WriteLine(sum);
        }

        static int GetInput()
        {
            int input;

            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out input))
                    return input;
                else
                    Console.WriteLine("輸入錯誤,請重新輸入:");
            }
        }

        static int Fibonacci(int n)
        {
            if (n == 0 || n == 1)
                return n;
            else
                return Fibonacci(n - 1) + Fibonacci(n - 2);
        }
    }
}