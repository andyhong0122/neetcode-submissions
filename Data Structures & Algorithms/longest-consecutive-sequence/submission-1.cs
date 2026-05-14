public class Solution {
    public int LongestConsecutive(int[] nums) {
        // 1. Convert nums array into set
        HashSet<int> set = new HashSet<int>(nums);
        int longest = 0;

        // 2. For each num in set, start processing
        foreach (int num in set) {
            if (!set.Contains(num - 1)) {
                int tracker = 1;

                while (set.Contains(num + tracker)) {
                    tracker++;
                }

                longest = Math.Max(tracker, longest);
            }
        }

        // 3. After iterating through all, return longest seen
        return longest;
    }
}

// Requirements: Know start and end
// Start is obtained by checking n - 1
// End is obatained by checkign n + 1
// Keep track of longest