public class Solution {
    public int[] TopKFrequent(int[] nums, int k) {
        // 1. Construct dictionary to hold count:nums
        Dictionary<int, int> dict = new Dictionary<int, int>();
        foreach (int num in nums) {
            if (!dict.ContainsKey(num)) {
                dict.Add(num, 0);
            }
            dict[num]++;
        }

        // 2. Construct priority queue (min-heap) to hold num < K
        PriorityQueue<int, int> pq = new PriorityQueue<int, int>();
        // key is number, and value is frequency
        foreach (KeyValuePair<int, int> kv in dict) {
            pq.Enqueue(kv.Key, kv.Value);

            if (pq.Count > k) {
                pq.Dequeue();
            }
        }

        // 3. Get elements from pq K times
        int[] output = new int[k];
        for (int i = 0; i < k; i++) {
            output[i] = pq.Dequeue();
        }

        return output;
    }
}

/*
1. Priority Queue / Min-Heap
Time: O(n log k) - for each element, we need to place them in the heap, which insertion, removal is O(log n)
Space: O(n + k) - initial space required for keeping count (n), and another for keeping heap (k length)
*/