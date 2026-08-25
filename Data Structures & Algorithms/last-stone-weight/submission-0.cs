public class Solution {
    public int LastStoneWeight(int[] stones) {
        var pq = new PriorityQueue<int, int>();

        foreach (int s in stones) {
            pq.Enqueue(-s, -s);
        }

        while (pq.Count > 1) {
            int largest1 = pq.Dequeue();
            int largest2 = pq.Dequeue();
            if (largest2 > largest1) {
                pq.Enqueue(largest1 - largest2, largest1 - largest2);
            }
        }

        pq.Enqueue(0,0);
        return Math.Abs(pq.Peek());
    }
}
