namespace 雙指針解法_from_Cindy_
{
    internal class Program
    {
        /// <summary>
        /// 給定一個整數陣列為nums，移動全部的 零 元素到最後面，同時維持非零元素的原本順序。
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            int[] nums = { 2, 1, 0, 3, 8, 7 };
            MoveZeroes(nums);
            MoveZeroesIntuitive(nums);
        }
        static void MoveZeroes(int[] nums)
        {
            int nonZeroIndex = 0; // 非零元素應該放置的位置

            // 遍歷整個陣列
            for (int i = 0; i < nums.Length; i++)
            {
                // 如果該元素非零，就執行
                if (nums[i] != 0)
                {
                    // 如果非零元素目前的索引 不是他應該所在的索引，就交換它們
                    if (i != nonZeroIndex)
                    {
                        int temp = nums[nonZeroIndex];
                        nums[nonZeroIndex] = nums[i];
                        nums[i] = temp;
                    }

                    // 下一個非零元素放的位置
                    nonZeroIndex++;
                }

                // 這段是用來看目前陣列的狀況
                Console.Write($"這是for的第{i}圈跑完時的陣列：");
                foreach (int num in nums)
                {
                    Console.Write(num + " ");
                }
                Console.WriteLine();
            }
        }

        // 直覺寫法，但效能較差
        static void MoveZeroesIntuitive(int[] nums)
        {
            // 用一個list把所有非零元素裝進去
            List<int> temp = new List<int>();
            foreach (int element in nums)
            {
                if (element != 0)
                {
                    temp.Add(element);
                }
            }

            // 把list的元素全部先塞到nums後，其餘補0
            for (int i = 0; i < nums.Length; i++)
            {
                if (i < temp.Count)
                {
                    nums[i] = temp[i];
                }
                else
                {
                    nums[i] = 0;
                }
            }

            foreach (int num in nums)
            {
                Console.Write(num + " ");
            }
        }


    }
}