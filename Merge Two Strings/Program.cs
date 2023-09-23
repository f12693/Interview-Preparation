namespace Merge_Two_Strings
{
    internal class Program
    {
        /// <summary>
        /// 請將兩個陣列合併，但不能出現重複數字。
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            int[] input1 = { 1, 3, 4 };
            int[] input2 = { 3, 5, 6 };

            HashSet<int> output = new HashSet<int>();
            foreach (int element in input1)
            {
                output.Add(element);
            }
            foreach (int element in input2)
            {
                output.Add(element);
            }
            foreach (int element in output)
            {
                Console.Write(element + " ");
            }

        }
    }
}