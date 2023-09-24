using Microsoft.VisualBasic;

namespace LeetCode_704._Binary_Search
{
    internal class Program
    {
        /// <summary>
        /// 給定排序好的整數陣列，找出目標索引，時間複雜度須為O(log n)
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            int[] nums = { -1, 0, 3, 5, 9, 12 };
            int target = 9;

            int result = Search(nums, target);
            Console.WriteLine(result);


            // 極限測資，一百萬筆資料，只跑了19次迴圈，對應了log 1000000(base 2) ≈ 19.93
            int[] largeArray = new int[1000000];
            for (int i = 0; i < 1000000; i++)
                largeArray[i] = i;
            int extremeTarger = 999999;
            int iterations; // 測試共跑了幾次while迴圈
            int test = Search2(largeArray, extremeTarger,out iterations); // 順便練習out用法
            Console.WriteLine(test);
            Console.WriteLine(iterations);

        }
        public static int Search(int[] nums, int target)
        {
            int left = 0;
            int right = nums.Length;

            while (left <= right)
            {
                // 若用 (left + right)/2 可能會造成溢位
                int mid = left + (right - left) / 2;

                if(nums[mid] < target ) 
                    left = mid + 1;
                if (nums[mid] > target )
                    right = mid - 1;
                if (nums[mid] == target )
                    return mid;
            }
            return -1;
        }

        public static int Search2(int[] nums, int target, out int iterations)
        {
            int left = 0;
            int right = nums.Length;
            iterations = 0;
            while (left <= right)
            {
                iterations++;
                // 若用 (left + right)/2 可能會造成溢位
                int mid = left + (right - left) / 2;

                if (nums[mid] < target)
                    left = mid + 1;
                if (nums[mid] > target)
                    right = mid - 1;
                if (nums[mid] == target)
                    return mid;
            }
            return -1;
        }
    }
}