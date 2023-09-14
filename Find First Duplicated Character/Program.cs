using System.Collections.Generic;

namespace Find_First_Duplicated_Character
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = getInput();
            char result = FindFirstDuplicatedCharacter(input);
            if (result == '\0')
            {
                Console.WriteLine("無重複自字元");
            }
            else
                Console.WriteLine(result);
        }
        static string getInput()
        {
            string? input = Console.ReadLine();

            while (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("輸入錯誤,請重新輸入:");
            }
            return input;
        }

        static char FindFirstDuplicatedCharacter(string input)
        {
            HashSet<char> result = new HashSet<char>();
            foreach (char c in input)
            {
                if (result.Contains(c))
                    return c;
                else
                    result.Add(c);
            }
            return '\0';
        }
    }
}