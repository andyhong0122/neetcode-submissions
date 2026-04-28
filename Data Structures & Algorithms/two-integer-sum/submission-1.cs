// Dictionary, sort each char
public class Solution {
    public List<List<string>> GroupAnagrams(string[] strs) {
        // Keep a dictionary to track string:[strings]
        // O(n x k)
        Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();

        // For each entry, create a key for its sorted characters
        // O(n x k log k)
        // n = number of strings
        // k log k = sorting each chracter within string
            // k = length of each string
            // k log k = sorting characters
        foreach (string str in strs) {
            string key = new string(str.OrderBy(character => character).ToArray());

            // for sorted string, check in dict
            if (!dict.TryGetValue(key, out List<string> list)) {
                list = new List<string>();
                dict[key] = list;
            }

            list.Add(str);
        }

        // Return all values in the dictionary
        return dict.Values.ToList();
    }
}
