
// Sliding Window, one pass
public class Solution {
    public int LengthOfLongestSubstring(string s) {
        // 1. Set up dictionary to keep track of char:last seen index --> O(n)
        Dictionary<char, int> lastSeen = new Dictionary<char, int>();

        // 1.1. Keep track of left pointer and output --> O(1)
        int left = 0;
        int output = 0;

        // 2. Traverse through the list --> O(n)
        for (int right = 0; right < s.Length; right++) {
            // Check if we have seen char before. --> O(1)
            if (lastSeen.ContainsKey(s[right])) {
            // If yes, move left pointer to right + 1
            left = Math.Max(lastSeen[s[right]] + 1, left);
            }
            // Update the index value of the current char in dictionary
            lastSeen[s[right]] = right;

            // Finally, set the max length to output: current output vs current longest sequence 
            output = Math.Max(output, right - left + 1);
        }

        // 3. Return response
        return output;
    }
}

// Brute Solution
public class BruteSolution {
    public int LengthOfLongestSubstring(string s) {
        int longest = 0;

        // 1. Iterate through each char in string
        for (int i = 0; i < s.Length; i++) { // O(n)
            // Scoped within each sequence; will be instantiated new for each sequence
            HashSet<char> set = new HashSet<char>();

            // 2. Check each consecutive sequence if there are repeating chars
            for (int j = i; j < s.Length; j++) { // O(m)

                // 2.1. If we have seen char, break inner loop
                if (set.Contains(s[j])) {
                    break;
                }

                // 2.2. If we have not seen char, continue adding
                set.Add(s[j]);
            }

            // 3. Set our longest value
            longest = Math.Max(longest, set.Count);
        }

        return longest;
    }
}

