public class Solution {
    public int[] ProductExceptSelf(int[] nums) {
        int n = nums.Length;
        int counter = 0;
        int[] output = new int[n];

        while (counter < n) {
            int temp = 1;
            for (int i = 0; i < n; i++) {
                if (i != counter) {
                    temp *= nums[i];    
                }
            }
            output[counter] = temp;
            counter++;
        }

        return output;
    }
}
