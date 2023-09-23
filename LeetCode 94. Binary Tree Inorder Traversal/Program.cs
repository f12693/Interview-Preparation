namespace LeetCode_94._Binary_Tree_Inorder_Traversal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 圖例：
            //  1
            //   \
            //    2  
            //   / \ 
            //  3   4
            TreeNode root = new TreeNode(1);
            root.right = new TreeNode(2);
            root.right.left = new TreeNode(3);
            root.right.right = new TreeNode(4);

            Solution solution = new Solution();

            var result = solution.InorderTraversal(root);
            Console.Write("遞迴中序：");
            foreach (int e in result)
            {
                Console.Write(e + " ");
            }
            Console.WriteLine();

            var result_inorder = solution.Inorder(root);
            Console.Write("迭代中序：");
            foreach (int e in result_inorder)
            {
                Console.Write(e + " ");

            }
            Console.WriteLine();

            var result_preorder = solution.Preorder(root);
            Console.Write("迭代前序：");
            foreach (int e in result_preorder)
            {
                Console.Write(e + " ");
            }
            Console.WriteLine();

            var result_postorder = solution.Postorder(root);
            Console.Write("迭代後序：");
            foreach (int e in result_postorder)
            {
                Console.Write(e + " ");
            }
            Console.WriteLine();
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
        IList<int> result = new List<int>();

        // using recursive function
        public IList<int> InorderTraversal(TreeNode root)
        {
            helper(root);
            return result;
        }
        public void helper(TreeNode root)
        {
            if (root != null)
            {
                // Inorder
                helper(root.left);
                result.Add(root.val);
                helper(root.right);

                //// preorder
                //result.Add(root.val);
                //helper(root.left);
                //helper(root.right);

                //// postorder
                //helper(root.left);
                //helper(root.right);
                //result.Add(root.val);
            }
            return;
        }

        // using iteration(DFS前序，根.左.右)
        public IList<int> Preorder(TreeNode root)
        {
            IList<int> result = new List<int>();
            if (root == null) return result;

            Stack<TreeNode> stack = new Stack<TreeNode>();
            stack.Push(root);

            while (stack.Count > 0)
            {
                TreeNode node = stack.Pop();
                result.Add(node.val);

                // 先將右子樹推入堆疊，再將左子樹推入，保證左子樹先出
                if (node.right != null)
                    stack.Push(node.right);

                if (node.left != null)
                    stack.Push(node.left);
            }
            return result;
        }

        // using iteration(DFS中序，左.根.右)
        public IList<int> Inorder(TreeNode root)
        {
            IList<int> result = new List<int>();
            if (root == null) return result;

            Stack<TreeNode> stack = new Stack<TreeNode>();
            TreeNode node = root;

            while (node != null || stack.Count > 0)
            {
                if (node != null) // 將左子樹的所有節點壓入堆疊
                {
                    stack.Push(node);
                    node = node.left;
                }
                else // 彈出堆疊頂部的節點並處理它，然後轉向右子樹
                {
                    node = stack.Pop();
                    result.Add(node.val);
                    node = node.right;
                }
            }
            return result;
        }

        // using iteration(DFS後序，左.右.根)
        public IList<int> Postorder(TreeNode root)
        {
            IList<int> result = new List<int>();
            if (root == null) return result;

            Stack<TreeNode> stack = new Stack<TreeNode>();
            stack.Push(root);

            while (stack.Count > 0)
            {
                TreeNode node = stack.Pop();
                result.Insert(0, node.val);

                // 先將左子樹推入堆疊，再將右子樹推入，保證右子樹先出
                // 這部分跟Preorder不一樣，是因為上面用了Insert，先插入的反而會在數列的後面，所以順序依舊是左.右.根。
                // 可以理解為：插入順序為根.右.左，數列順序為左.右.根
                if (node.left != null)
                    stack.Push(node.left);

                if (node.right != null)
                    stack.Push(node.right);
            }
            return result;
        }
    }
}