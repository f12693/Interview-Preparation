using System.Numerics;
using System.Runtime.CompilerServices;

namespace LeetCode_543._Diameter_of_Binary_Tree
{
    internal class Program
    {
        /// <summary>
        /// 注意答案是可以不經過根節點的，因此DiameterOfBinaryTree()遞迴函式只是回傳"經過該節點的最大Diameter"而已
        /// </summary>
        /// <param name="args"></param>

        static void Main(string[] args)
        {
            // 該測資答案為8
            int?[] input = { 4, -7, -3, null, null, -9, -3, 9, -7, -4, null, 6, null, -6, -6, null, null, 0, 6, 5, null, 9, null, null, -1, -4, null, null, null, -2 };

            var solution = new Solution();
            TreeNode root = solution.BuildTree(input);

            int a = solution.DiameterOfBinaryTree(root);
            Console.WriteLine(a);
            Console.WriteLine(solution.MaxDiameter);

            //// 該段程式碼可用來測試BuildTree()建出來的TreeNode是否正確
            //TreeNode root = new TreeNode(4);
            //root.left = new TreeNode(-7);
            //root.right = new TreeNode(-3);
            //root.right.left = new TreeNode(-9);
            //root.right.right = new TreeNode(-3);
            //root.right.left.left = new TreeNode(9);
            //root.right.left.right = new TreeNode(-7);
            //root.right.right.left = new TreeNode(-4);
            //root.right.left.left.left = new TreeNode(6);
            //root.right.left.right.left = new TreeNode(-6);
            //root.right.left.right.right = new TreeNode(-6);
            //root.right.left.left.left.left = new TreeNode(0);
            //root.right.left.left.left.right = new TreeNode(6);
            //root.right.left.right.left.left = new TreeNode(5);
            //root.right.left.right.right.left = new TreeNode(9);
            //root.right.left.left.left.left.right = new TreeNode(-1);
            //root.right.left.left.left.right.left = new TreeNode(-4);
            //root.right.left.right.right.left.left = new TreeNode(-2);

        }
    }
    public class Solution
    {
        public int MaxDiameter { get; set; } = 0;
        public int DiameterOfBinaryTree(TreeNode root)
        {
            if (root == null) return 0;
            int leftDiameter = DiameterOfBinaryTree(root.left);
            int rightDiameter = DiameterOfBinaryTree(root.right);
            MaxDiameter = Math.Max(MaxDiameter, leftDiameter + rightDiameter);
            return Math.Max(leftDiameter, rightDiameter) + 1;
        }

        public TreeNode BuildTree(int?[] input)
        {
            if (input == null || input.Length == 0)
                return null;

            Queue<TreeNode> queue = new Queue<TreeNode>();
            TreeNode root = new TreeNode(input[0].GetValueOrDefault());
            queue.Enqueue(root);

            int i = 1;
            while (i < input.Length)
            {
                TreeNode current = queue.Dequeue();
                if (input[i].HasValue)
                {
                    current.left = new TreeNode(input[i].Value);
                    queue.Enqueue(current.left);
                }

                i++;

                if (i < input.Length && input[i].HasValue)
                {
                    current.right = new TreeNode(input[i].Value);
                    queue.Enqueue(current.right);
                }

                i++;
            }

            return root;
        }
    }
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }

        // 設中斷點時較方便觀察
        public override string ToString()
        {
            return "Node=" + val;
        }
    }
}