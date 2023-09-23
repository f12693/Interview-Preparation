namespace The_Number_of_Longest_Sequences
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] inputStr = { "0", "-5", "1", "3", "4" };
            int[] intArray = new int[inputStr.Length];
            for (int i = 0; i < inputStr.Length; i++)
                intArray[i] = int.Parse(inputStr[i]);

            int result = FindLongest(intArray);
            Console.WriteLine("最長遞增子序列的數量：" + result); // 應該輸出 2

        }

        static int FindLongest(int[] nums)
        {
            int n = nums.Length;
            int[] lengths = new int[n]; // 存儲以每個元素結尾的最長遞增子序列的長度
            int[] counts = new int[n];  // 存儲以每個元素結尾的最長遞增子序列的數量

            int maxLength = 1; // 記錄最長遞增子序列的長度

            // 初始情況下，每個元素的長度和數量都為1
            for (int i = 0; i < n; i++)
            {
                lengths[i] = 1;
                counts[i] = 1;
            }

            for (int i = 1; i < n; i++) // 以nums[i]結尾的最長遞增子序列
            {
                for (int j = 0; j < i; j++) // 依前面已解決的最長遞增子序列的長度&數量來繼續討論狀況(如i=3時，已解決的是以nums[1]或以num[2]為結尾的狀況)
                {
                    if (nums[i] > nums[j])
                    {
                        if (lengths[i] < lengths[j] + 1)
                        {
                            lengths[i] = lengths[j] + 1;
                            counts[i] = counts[j];
                        }
                        else if (lengths[i] == lengths[j] + 1)
                        {
                            counts[i] += counts[j];
                        }
                    } 
                }
                maxLength = Math.Max(maxLength, lengths[i]);
            }

            int result = 0;

            // 遍歷最長遞增子序列的數量數組，找到所有最長遞增子序列的數量
            for (int i = 0; i < n; i++)
            {
                if (lengths[i] == maxLength)
                {
                    result += counts[i];
                }
            }

            return result;
        }
    }
}