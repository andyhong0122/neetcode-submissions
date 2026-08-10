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
    public int MaxDepth(TreeNode root) {
        /*
        Time: O(n), for worst case where tree is degenerate tree
        Space: O(h), stack will require memory equivalent to height of tree at worst

        Best: Balanced tree, where O(log n)
        Worst: Degenerate tree, where O(n)
        */

        // Passed in node is null, 0 height
        if (root == null) {
            return 0;
        }

        // Get depth from left and right
        int left = MaxDepth(root.left);
        int right = MaxDepth(root.right);

        // Of the received depths from L and R, get the greater depth, and return + 1 (current node height)
        return Math.Max(left, right) + 1;
    }
}
