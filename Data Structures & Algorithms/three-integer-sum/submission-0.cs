public class Solution {
    public List<List<int>> ThreeSum(int[] nums) {
        // sort by order, since O(n log n) is smaller than O(n^2)
        Array.Sort(nums);

        // keep array of arrays
        List<List<int>> res = new List<List<int>>();

        // anchor pt1, pt2 and pt3 iterate
        for (int pt1 = 0; pt1 < nums.Length; pt1++) {
            if (pt1 > 0 && nums[pt1] == nums[pt1 - 1]) {
                continue;
            }

            // edge case - no triplets expected
            if (nums[pt1] > 0) {
                break;
            }

            int pt2 = pt1 + 1;
            int pt3 = nums.Length - 1;
            
            // iterate until pt3 hits end
            while (pt2 < pt3) {
                int sum = nums[pt1] + nums[pt2] + nums[pt3];

                // if sum is greater than 0, try lowering pt3
                if (sum > 0) {
                    pt3--;
                } 
                // if sum is less than 0, try incrementing pt2
                else if (sum < 0) {
                    pt2++;
                }
                // finally, we're at 0, add triplet
                else {
                    res.Add(new List<int> {nums[pt1],  nums[pt2], nums[pt3]});

                    // after adding, move pt2 and p3
                    pt2++;
                    pt3--;

                    // in case there are duplicate values, skip them
                    while (pt2 < pt3 && nums[pt2 - 1] == nums[pt2]) {
                        pt2++;
                    }
                }
            }
        }

        // return res
        return res;
    }
}
