public class Solution {
    public int LongestConsecutive(int[] nums) {
        if (nums.Length == 0) {
            return 0;
        }

        // O(n)
        HashSet<int> set = new HashSet<int>(nums);
        int longest = 0;

        // O(n)
        for (int i = 0; i < nums.Length; i++) {
            int counter = 1;
            int temp = nums[i] + 1;

            // O(1)
            if (!set.Contains(nums[i] - 1)) {

                // O(1)
                while(set.Contains(temp)) {
                    temp++;
                    counter++; 
                }

                longest = Math.Max(longest, counter);
            }
        }

        return longest;
    }
}
