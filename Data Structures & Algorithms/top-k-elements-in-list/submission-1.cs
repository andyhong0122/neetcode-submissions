public class Solution {
    public int[] TopKFrequent(int[] nums, int k) {
        // 1. Create mapping between count:nums
        var count = new Dictionary<int, int>();
        foreach (int num in nums) {
            if (count.ContainsKey(num)) {
                count[num]++;
            } else {
                count[num] = 1;
            }
        }

        // 2. Populate heap using PriorityQueue DS
        // Note: PriorityQueue in C# is min-heap by default.
        PriorityQueue<int, int> heap = new PriorityQueue<int, int>();
        foreach (KeyValuePair<int, int> entry in count) {
            // 2.1. Enqueue by element, priority score
            heap.Enqueue(entry.Key, entry.Value);

            // 2.2.
            if (heap.Count > k) {
                heap.Dequeue();
            }
        }

        // 3. Dequeue entries from from heap K times, assign to res
        int[] res = new int[k];
        for (int i = 0; i < k; i++) {
            res[i] = heap.Dequeue();
        }
        return res;
    }
}

/*
1. Priority Queue / Min-Heap
Time: O(n log k) - for each element, we need to place them in the heap, which insertion, removal is O(log n)
Space: O(n + k) - initial space required for keeping count (n), and another for keeping heap (k length)
*/
