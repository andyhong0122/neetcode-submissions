class Solution:
    """
    Time: O(n), we only do a one pass over n
    Space: O(1), we only keep primitives to keep track of indices
    """
    def trap(self, height: List[int]) -> int:
        if not height: return 0;

        l, r = 0, len(height) - 1
        leftMax, rightMax = height[l], height[r]
        res = 0

        while l < r:
            """
            Determine bottleneck. At the finishing point leftMax and rightMax
            will meet. 
            """
            if leftMax < rightMax:
                l += 1
                """
                Here leftMax is L wall, and height[l] is R wall
                """
                leftMax = max(leftMax, height[l])
                """ 
                If old L wall was higher than new R wall, then we can capture water.
                This only works because we know there is a higher right wall somewhere.
                """
                res += leftMax - height[l]
            # If rightMax is lower than leftMax, our rightMax is the bottleneck.
            # Knowing there is a higher wall on the left, we can begin capturing from right.
            else:
                r -= 1
                """
                rightMax is the older R wall, and height[r] becomes the new L wall.
                """
                rightMax = max(rightMax, height[r])
                res += rightMax - height[r]
        
        """
        The condition for the while loop termination is when l meets r.
        This means we have finished traversal using two pointers.
        Return accumulated water.
        """
        return res
        
        