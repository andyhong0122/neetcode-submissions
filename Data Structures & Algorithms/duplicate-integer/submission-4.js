class Solution {
    /**
     * @param {number[]} nums
     * @return {boolean}
     */
    hasDuplicate(nums) {
        var set = new Set(nums);

        if(set.size != nums.length) {
            return true;
        }
        else {
            return false;
        }
    }
}
