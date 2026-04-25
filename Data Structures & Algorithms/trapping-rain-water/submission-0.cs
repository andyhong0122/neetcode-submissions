public class Solution 
{
    /*
        height
        [0,1,0,2,1,0,1,3,2,1,2,1]
                            
        Conditions to store water
        1. height > 0
        2. consecutive height <= current height
        3. left wall >= right wall
    */
    public int Trap(int[] height) 
    {
        if (height == null || height.Length == 0) 
        {
            return 0;
        }

        int left = 0;
        int right = height.Length - 1;
        int leftMax = height[left];
        int rightMax = height[right];
        int totalVolume = 0;

        while (left < right)
        {
            if (leftMax < rightMax)
            {
                left++;
                leftMax = Math.Max(leftMax, height[left]);
                totalVolume += leftMax - height[left];
            }
            else
            {
                right--;
                rightMax = Math.Max(rightMax, height[right]);
                totalVolume += rightMax - height[right];
            }
        }

        return totalVolume;
    }
}