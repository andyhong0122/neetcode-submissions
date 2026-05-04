public class Solution {
    public int Search(int[] nums, int target) {
        return BinarySearch(nums, target, 0);
    }

    private int BinarySearch(int[] nums, int target, int offset) {
        // base case: if length is 0, target not found
        if (nums.Length == 0) {
            return -1;
        }

        int mid = nums.Length / 2;

        // base case: return if midpoint is target
        if (nums[mid] == target) {
            return offset + mid;
        }

        int[] segment;

        if (nums[mid] < target) {
            segment = nums[(mid + 1)..];
            return BinarySearch(segment, target, offset + mid + 1);
        } else {
            segment = nums[..mid];
            return BinarySearch(segment, target, offset);
        }

    }
}

// Target: 4
// 1 2 3 4 5
//     M
// 3 4 5
//   M

// Target: 0
// 0 2 3 4 5
//     M
// 0 2 3
//   M
// 0 2
//   M
// 0
// M

/*

Binary Search

1. Get the midpoint, check if num is >< target

2. If num < target, move midpoint to start -> here -> midpoint

3. If num > target, move to midpoint -> here -> end

4. Repeat until target is found

*/