public class Solution 
{
    public int[][] Merge(int[][] intervals) 
    {

    // 1. Sort all intervals by the starting point
    Array.Sort(intervals, (a,b) => a[0].CompareTo(b[0]));

    // Create as List so size is dynamic
    List<int[]> res = new List<int[]>() 
    {
        // Seed the initial value
        intervals[0],
    };

    // 2. Iterate through the sorted list to compare current and next interval pair
    for (int i = 1; i < intervals.Length; i++) 
    {
        int currentStart = intervals[i][0];
        int currentEnd = intervals[i][1];
        int currentRes = res.Count - 1;
        int lastEnd = res[currentRes][1];

        // 2.1. If next starting index is <= previous last index
        if (currentStart <= lastEnd)
        {
            // 2.2. If start point overlaps, evaluate which ending point is greater
            res[currentRes][1] = Math.Max(lastEnd, currentEnd);
        } 
        // 2.2. If not, add pair to res, continue -> 2
        else
        {
            res.Add(new int[] { currentStart, currentEnd });
        }
    }

    // 3. Return response.ToArray() to convert List<int[]>
    return res.ToArray();        
    }
}
