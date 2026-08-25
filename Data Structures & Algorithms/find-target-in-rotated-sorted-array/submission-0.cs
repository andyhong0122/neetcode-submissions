public class Solution {
    /*
        The rotation point is in the pivoted point. No matter where the pivot point is, one side is guaranteed to be sorted if nums is split in half. This is the clue to use binary search.

        Before jumping into BS, a linear time to solve this is to simply iterate through the list. Target will be at the later index, or not exist. This puts our TC at O(n).

        Back to BS. Grab the midpoint, and check whether L is < M. If true, this means range [l..m] is sorted. 
            Then do another check - l <= target <= m ? If true, then discard [m + 1..r]. If not, then our target is on the right side. Discard [l..m]
    */
    public int Search(int[] nums, int target) {
        int l = 0;
        int r = nums.Length - 1;

        // Binary search
        while (l <= r) {
            int mid = l + (r-l)/2;

            if (nums[mid] == target) return mid;

            if (nums[l] <= nums[mid]) { // left side is sorted
                if (nums[l] <= target && target <= nums[mid]) { // target is on left side, discard [m..r]
                    r = mid - 1;
                } else { // target is on right side, discard [l..m]
                    l = mid + 1;
                }

            } else { // right side is sorted
                if (nums[mid] <= target && target <= nums[r]) { // target is on right side, discard [l..m]
                    l = mid + 1;
                } else { // target is on left side, discard [m..r]
                    r = mid - 1;
                }
            }
        }

        return -1;
    }
}
