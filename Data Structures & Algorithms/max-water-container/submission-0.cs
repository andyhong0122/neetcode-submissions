public class Solution {
    /*
    Theme: Two pointers

    A brute force approach would be to use a nested loop, where we check each pair (i and j). This renders a O(n^2) time complexity however.

    The optimal way is to use two pointers, where we calculate the area with two pointers starting from both ends. O(n)
    */
    public int MaxArea(int[] heights) {
        int res = 0;
        int l = 0;
        int r = heights.Length - 1;

        while (l < r) {
            int area = (Math.Min(heights[l], heights[r])) * (r - l);

            res = Math.Max(area, res);

            if (heights[l] <= heights[r]) {
                l++;
            } else {
                r--;
            }
        }

        return res;
    }
}
