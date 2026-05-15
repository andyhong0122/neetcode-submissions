/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */


// If node has been seen, we have a cycle
public class Solution {
    public bool HasCycle(ListNode head) {
        HashSet<ListNode> seen = new HashSet<ListNode>(); // O(n) space
        ListNode curr = head;
        
        while (curr != null) { // O(n) time
            if (seen.Contains(curr)) { // O(1) time
                return true;
            }
            seen.Add(curr); // O(1)
            curr = curr.next;
        }

        return false;
    }
}
