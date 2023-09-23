namespace LeetCode_226._Invert_Binary_Tree
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
            PrintTree(invertedRoot);
            Console.WriteLine();
            PrintTreeDFS(invertedRoot);
            Console.WriteLine();

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        // Queue，先進先出 (First-In-First-Out, FIFO) 的資料結構，類似於排隊。
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

        // Stack，後進先出 (Last-In-First-Out, LIFO) 的資料結構，類似於一疊盤子。
        static void PrintTreeDFS(TreeNode root)
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

        // 效果跟PrintTreeDFS一樣
        static void PrintTree(TreeNode root)
        {
            if (root == null)
                return;
            Console.Write(root.val + " ");
            PrintTree(root.left);
            PrintTree(root.right);
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

    public class Solution
    {
        public TreeNode InvertTree(TreeNode root)
        {
            if (root != null)
            {
                TreeNode left = root.left;
                TreeNode right = root.right;

                root.left = InvertTree(right);
                root.right = InvertTree(left);

                // 注意不能化簡成以下，因第二行用的是已經改過的root.left，而不是最一開始的root.left
                // root.left = InvertTree(root.right);
                // root.right = InvertTree(root.left);
            }

            return root;
        }
    }
}