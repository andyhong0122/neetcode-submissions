public class Solution {
    public int[] TopKFrequent(int[] nums, int k) {
        // Pattern: Save number:frequency to dictionary
        var map = new Dictionary<int, int>();
        foreach (int n in nums) {
            if (!map.ContainsKey(n)) {
                map.Add(n, 1);
            }
            map[n]++;
        }

        // Pattern: For each KV pair, add to min-heap
        // In PriorityQueue, priority number is 2nd argument for Enqueue()
        var heap = new PriorityQueue<int, int>();
        foreach (KeyValuePair<int, int> pair in map) {
            heap.Enqueue(pair.Key, pair.Value);

            // Pattern: Keep bounded tree size; dequeue if exceeding
            if (heap.Count > k) {
                _ = heap.Dequeue();
            }
        }
        
        // Pattern: Traverse through priority queue, create output
        // PriorityQueue in C# does not support foreach/for, to keep index in order
        int[] res = new int[k];
        int index = 0;
        while (heap.Count > 0) {
            res[index++] = heap.Dequeue();
        }

        return res;
    }
}

// Theme: Arrays + Hashing
// Time: O(n log k)
// n for all input
// k for bounded min-heap size
// Space: O(n + k)
// n for keeping dictionary (worst case all unqiue)
// k for keeping priority queue (bounded)

