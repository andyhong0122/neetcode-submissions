public class Solution {
    /*
    Koko can eat as slow as she can, as long as it is under h

    1. Find minimum rate (1) and maximum rate (highest pile). After doing so, we need to find the speed at which Koko can eat. 

    2. To find out how many hours she needs per pile, we can do pile/k, which would give us the hours needed. HOWEVER, for values that are not whole numbers, we must round up. We can round up by using integer division such that:

    pile + k - 1  / k

    This ensures our value will always be in the multiple that is rounded down to target value. 

    For example, 

    pile = 3
    rate = 2
    3/2 = 1.5, rounded down to 1 <-- Wrong!

    pile = 3
    rate = 2
    3+2-1/2 = 2 <-- Correct!

    pile = 4
    rate = 2
    4+2-1/2 = 2.5, rounded down to 2 <-- Correct!

    3. Evaluate each pile using k. Intuitively, we can scan through all ranges of [1..max pile], but this will evaluate to at least O(n). 
    
    We can improve this by leveraging binary search. Take the midpoint from [1.. max rate] first, and check if Koko can finish eating within given h with k rate. If total hours spent eating is <= h, check if Koko can eat slower. If total hours spent eating is > h, Koko must eat faster. 

    Exmaple,

    piles = [1,4,3,2], h =9

    K range = [1,2,3,4]
               L M    R

    take mid = left + (right - left) / 2
    L = 0
    R = 3
    0 + (3-0) / 2 = 1.5 = 1

    Go through each pile with k=2 to find number of hours needed
    1+2-1/2 = 1
    4+2-1/2 = 2
    3+2-1/2 = 2
    2+2-1/2 = 1
    Total of 6 hours, which is less than 9. Can we find an even slower speed?

    K range = [1,2,3,4]
               L R

    M = 0 + 1 - 0 / 2 = 0

    1+1-1/1 = 1
    4+1-1/1 = 4
    3+1-1/1 = 3
    2+1-1/1 = 2
    Total of 10 hours needed, which does not work.   

    TC: O(piles x log pile)
    SC: O(1), no auxiliary memory

    */
    public int MinEatingSpeed(int[] piles, int h) {
        // Get min and max
        int l = 1;
        int r = piles.Max();
        int res = r; // start at absolute max speed

        // Binary search to find lowest speed
        while (l <= r) {
            int mid = l + (r - l) / 2;
            int totalTime = 0; // sum hours taken across all piles for K

            foreach(int p in piles) {
                int time = (p + mid - 1) / mid;
                totalTime += time;
            }

            if (totalTime <= h) { // if time is less than h, then we want to check if we can go slower
                res = mid;
                r = mid - 1;
            } else {
                l = mid + 1;
            }
        }

        return res;
    }
}
