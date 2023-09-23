using System.ComponentModel.Design.Serialization;

namespace LeetCode_1379._Find_a_Corresponding_Node_of_a_Binary_Tree_in_a_Clone_of_That_Tree
{
    internal class Program
    {
        static void Main(string[] args)
        {

            TreeNode original = new TreeNode(7);
            original.left = new TreeNode(4);
            original.right = new TreeNode(3);
            original.right.left = new TreeNode(6);
            original.right.right = new TreeNode(19);

            TreeNode cloned = new TreeNode(7);
            cloned.left = new TreeNode(4);
            cloned.right = new TreeNode(3);
            cloned.right.left = new TreeNode(6);
            cloned.right.right = new TreeNode(19);

            TreeNode target = original.right;

            // 該段用來解釋為何不能直接回傳target(題意是回傳same node in the cloned tree)
            // C#物件的相等，是根據是否參考相同物件而定
            // ref:https://learn.microsoft.com/zh-tw/dotnet/csharp/language-reference/operators/equality-operators
            TreeNode target_cloned = cloned.right;
            if (target == target_cloned)
                Console.WriteLine("same!");
            else
                Console.WriteLine("diff!");

            Solution solution = new Solution();
            TreeNode result = solution.GetTargetCopy(original, cloned, target);

            Console.WriteLine("The corresponding node in the cloned tree is: " + result.val);


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
        public TreeNode GetTargetCopy(TreeNode original, TreeNode cloned, TreeNode target)
        {
            if (original == null)
            {
                return null;
            }

            if (original == target)
            {
                return cloned;
            }

            TreeNode left = GetTargetCopy(original.left, cloned.left, target);
            TreeNode right = GetTargetCopy(original.right, cloned.right, target);

            return left ?? right;
        }
    }

}