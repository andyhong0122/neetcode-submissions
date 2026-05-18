public class Solution {
    public bool IsValid(string s) {
        var close = new HashSet<char>() { ']', '}', ')' };
        var open = new HashSet<char>() { '[', '{', '(' };

        var stack = new Stack<char>();
        var pairs = new Dictionary<char, char> {
            { ']', '[' },
            { '}', '{' },
            { ')', '(' }
        };
        
        foreach (char character in s) {
            // If opening symbol, add to the single stack
            if (open.Contains(character)) {
                stack.Push(character);
            }
            // Else if closing symbol, check if it matches the top of the stack
            else if (close.Contains(character)) {
                if (stack.Count == 0 || stack.Pop() != pairs[character]) {
                    return false;
                }
            }

        }

        return stack.Count == 0;
    }
}
