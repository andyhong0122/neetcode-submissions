public class Solution {
    public List<List<int>> Subsets(int[] nums) {
        var res = new List<List<int>>();
        var subset = new List<int>();
        Dfs(nums, 0, subset, res);
        return res;
    }

    private void Dfs(int[] nums, int i, List<int> subset, List<List<int>> res) {
        if (i >= nums.Length) {
            res.Add(new List<int>(subset));
            return;
        }

        subset.Add(nums[i]);
        Dfs(nums, i + 1, subset, res);
        subset.RemoveAt(subset.Count - 1);
        Dfs(nums, i + 1, subset, res);
    }
}
