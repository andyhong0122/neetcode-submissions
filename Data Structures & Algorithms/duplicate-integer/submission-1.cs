
public class Solution {
    public bool hasDuplicate(int[] nums)
    {
        HashSet<int> set = new HashSet<int>(nums);

        if (set.Count != nums.Length)
        {
            return true;
        }
        else 
        {
            return false;
        }
    }
}

// Space complexity: Worst case, O(N), if there are no duplicates
// Time complexity: 
// Average O(1), each number is hashed and added to set
// Worst case O(n), where we hit a collision for every addition to set 