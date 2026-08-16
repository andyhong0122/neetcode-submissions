/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */

public class Solution {    
    public bool IsSubtree(TreeNode root, TreeNode subRoot) {
        // 1. Return: If root is null, nothing else to explore
        if (root == null) return false;

        // 2. Evaluate:
        bool curr = IsSameTree(root, subRoot);
        bool left = IsSubtree(root.left, subRoot);
        bool right = IsSubtree(root.right, subRoot);

        // 3. Combine: 
        return curr || left || right;
    }

    private bool IsSameTree(TreeNode root, TreeNode subroot){
        // 1. Return
        if (root == null && subroot == null) return true;
        if (root == null || subroot == null) return false;

        // 2. Evaluate
        bool left = IsSameTree(root.left, subroot.left);
        bool right = IsSameTree(root.right, subroot.right);
        bool curr = root.val == subroot.val;

        // 3. Combine
        return left && right && curr;
    }
}
