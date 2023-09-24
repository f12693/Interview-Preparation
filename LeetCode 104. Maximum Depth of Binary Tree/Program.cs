namespace LeetCode_104._Maximum_Depth_of_Binary_Tree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TreeNode root = new TreeNode(3);
            root.left = new TreeNode(9);
            root.right = new TreeNode(20);
            root.right.left = new TreeNode(15);
            root.right.right = new TreeNode(7);
            root.right.right.right = new TreeNode(8);

            int result = Solution.MaxDepth(root);
            Console.WriteLine(result);

        }
    }

    public class Solution
    {
        public static int MaxDepth(TreeNode root)
        {
            if (root == null) return 0;
            int leftDepth = MaxDepth(root.left);
            int rightDepth = MaxDepth(root.right);
            return Math.Max(leftDepth, rightDepth) + 1;
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