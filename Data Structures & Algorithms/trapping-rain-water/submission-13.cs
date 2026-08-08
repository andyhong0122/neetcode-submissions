public class Solution {
    public int Trap1(int[] height) {
        /*
        Theme: Two Pointers

        - For brute force, we can move two pointers at once, but from the start.

        For every index
            Get the left and right walls to compare (highest walls)
            Then apply the formula min(leftMax, rightMax) - height[i] (keep track of res)
        */

        if (height == null || height.Length == 0) {
            return 0;
        }

        int n = height.Length;
        int res = 0; // 7

        // [0,2,0,3,1,0,1,3,2,1]
        //  ^               
        for (int i = 0; i < height.Length; i++) {
            int lMax = height[i];
            int rMax = height[i];

            for (int l = 0; l < i; l++) {
                lMax = Math.Max(lMax, height[l]);
            }

            for (int r = i + 1; r < n; r++) {
                rMax = Math.Max(rMax, height[r]);
            }

            res += Math.Min(lMax, rMax) - height[i];
        }

        return res;
    }

    public int Trap(int[] height) {
        /*
        Theme: Two Pointers

        - For the optimal two pointers approach, start l and r at each ends

        */
        if (height == null || height.Length == 0) {
            return 0;
        }

        int l = 0;
        int r = height.Length - 1;
        int lmax = height[l];
        int rmax = height[r];
        int res = 0;

        while (l < r) {
            if (lmax < rmax) {
                l++;
                lmax = Math.Max(height[l], lmax);
                res += lmax - height[l];
            } 
            else {
                r--;
                rmax = Math.Max(height[r], rmax);
                res += rmax - height[r];
            }
        }

        return res;
    }
}


// Start at two ends
// Compare LM <> RM
    // Increment/Decrement L R
        // Get new LM/RM
    // Get height of current bar: min(LM, RM) - height[i]
        // Add to response
