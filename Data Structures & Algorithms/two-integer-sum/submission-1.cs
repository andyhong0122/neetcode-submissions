public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        Dictionary<int, int> dict = new Dictionary<int, int>();

        for (int i = 0; i < nums.Length; i++) 
        {
            int comp = target - nums[i];

            if (dict.ContainsKey(comp)) 
            {
                return new int[] { dict[comp], i };
            }
            dict[nums[i]] = i;
        }

        return Array.Empty<int>();
    }
}
