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

        // 2. Populate heap
        PriorityQueue<int, int> heap = new PriorityQueue<int, int>();
        foreach (var entry in count) {
            // 2.1. Enqueue by element, priority score
            heap.Enqueue(entry.Key, entry.Value);

            // 2.2. If we have more heap count than K, evict
            // This automatically dequeues the element with weakest priority
            if (heap.Count > k) {
                heap.Dequeue();
            }
        }

        // 3. Dequeue from heap
        int[] res = new int[k];
        for (int i = 0; i < k; i++) {
            res[i] = heap.Dequeue();
        }
        return res;

    }
}

/*
Appraoch 1: Priority Queue
Time: O(n log k)
Space: O(n + k)
Where:
n is length of array
k is number of top frequent elements

1. Keep count in dictionary
[count]int:[int]number

2. Populate default heap (min-heap)

3. Now generate response with remaining heap

*/