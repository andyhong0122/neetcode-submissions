
// Theme: Arrays + Hashing
public class Solution {
    public int[] TopKFrequent(int[] nums, int k) {
        /*
        Bucket sorting
        Intuition is to that a nums list can only be N long,
        so we can leverage that fact and allocate an array N + 1 long (worst case)
        then treat the indices as the frequency count

        Deriving our counts from our idices, we can decrementing from length - 1
        while gathering our answer
        */

        // Pattern: Construct hash table with nums[]
        var map = new Dictionary<int, int>();
        foreach (int n in nums) {
            if (!map.ContainsKey(n)) {
                map.Add(n, 1);
            }
            else {
                map[n]++;
            }
        }

        // Pattern: Populate data structure (bucket array)
        // Init an int[length + 1] (bc we skip over 0 index)
        List<int>[] arr = new List<int>[nums.Length + 1];
        foreach (KeyValuePair<int, int> n in map) {
            if (arr[n.Value] == null) { // each index is 'null' at first
                arr[n.Value] = new List<int>() { n.Key };
            }
            else {
                arr[n.Value].Add(n.Key);
            }
        }

        // Pattern: Iterate through data structure, collect output
        // Start from end (length - 1) - why start from length - 1? 
        // i >= 0 && res.Length > k
        // i--;
        int[] res = new int[k];
        int counter = 0;
        
        for (int i = arr.Length - 1; i > 0 && counter < k; i--) {
            if (arr[i] != null) { // bc some arr[i] can be 'null'
                foreach (int n in arr[i]) {
                    res[counter++] = n;
                    
                    if (counter == k) {
                        return res;
                    }
                }
            }
        }

        return res;
    }

    public int[] TopKFrequent2(int[] nums, int k) {
        /*
        Min-Heap
        Intuition is to use a min-heap to keep a bounded size.
        Compared to bucket sorting, this is useful when:
        1. We do not know the size of N
        2. The size of K is much smaller than N

        Time: O(n log k)
        n for all input
        k for bounded min-heap size

        Space: O(n + k)
        n for keeping dictionary (worst case all unqiue)
        k for keeping priority queue (bounded)
        */

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

