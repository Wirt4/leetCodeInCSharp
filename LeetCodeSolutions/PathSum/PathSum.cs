namespace LeetCodeSolutions;
public class PathSumSolution
{
    public bool HasPathSum(TreeNode root, int targetSum, int runningSum = 0)
    {
        //base case
        if (root == null)
        {
            return false;
        }

        //is leaf
        if (root.left == null && root.right == null)
        {
            return targetSum == runningSum + root.val;
        }

        runningSum += root.val;

        //make the recursive call
        return HasPathSum(root.left, targetSum, runningSum) || HasPathSum(root.right, targetSum, runningSum);



    }
}
