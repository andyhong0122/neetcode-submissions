public class Solution {
    public int Trap(int[] height) {
        // Handle edge cases: null and 0 length 
        if (height.Length == 0 || height == null) {
            return 0;
        }

        // O(1) space
        int left = 0;
        int right = height.Length - 1;
        int lWall = height[left];
        int rWall = height[right];
        int total = 0;
        
        // O(n) time - one pass
        while (left < right ) {
            if (lWall < rWall) {
                left++;
                lWall = Math.Max(lWall, height[left]);
                total += lWall - height[left];
            }
            else {
                right--;
                rWall = Math.Max(rWall, height[right]);
                total += rWall - height[right];
            }
        }

        return total;
    }
}
