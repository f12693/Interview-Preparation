namespace LeeCode___226._Invert_Binary_Tree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 創建一個測試用的二叉樹
            TreeNode root = new TreeNode(4);
            root.left = new TreeNode(2);
            root.right = new TreeNode(7);
            root.left.left = new TreeNode(1);
            root.left.right = new TreeNode(3);
            root.right.left = new TreeNode(6);
            root.right.right = new TreeNode(9);

            // 創建解決方案對象
            Solution solution = new Solution();

            // 呼叫 InvertTree 函數進行反轉
            TreeNode invertedRoot = solution.InvertTree(root);

            // 打印反轉後的二叉樹，可以自行實現遍歷函數
            PrintTreeBFS(invertedRoot);
            Console.WriteLine();
            PrintTreeDFS(invertedRoot);
            Console.WriteLine();
            PrintTree(invertedRoot);

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
        static void PrintTreeBFS(TreeNode root)
        {
            if (root == null)
                return;
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                TreeNode current = queue.Dequeue();
                Console.Write(current.val + " ");

                if (current.left != null)
                    queue.Enqueue(current.left);

                if (current.right != null)
                    queue.Enqueue(current.right);
            }
        }
        static void PrintTreeDFS(TreeNode root)
        {
            if (root == null)
                return;
            Console.Write(root.val + " ");
            PrintTreeDFS(root.left);
            PrintTreeDFS(root.right);
        }

        static void PrintTree(TreeNode root)
        {
            if (root == null)
                return;

            Stack<TreeNode> stack = new Stack<TreeNode>();
            stack.Push(root);

            while (stack.Count > 0)
            {
                TreeNode current = stack.Pop();
                Console.Write(current.val + " ");

                if (current.right != null)
                    stack.Push(current.right);

                if (current.left != null)
                    stack.Push(current.left);
            }
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
    }

    public class Solution
    {
        public TreeNode InvertTree(TreeNode root)
        {
            if (root != null)
            {
                TreeNode left = InvertTree(root.left);
                TreeNode right = InvertTree(root.right);

                root.left = right;
                root.right = left;
            }

            return root;
        }
    }
}