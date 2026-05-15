public class Solution {
    public List<List<string>> GroupAnagrams(string[] strs) {
        // 1. Dictionary to keep sortedKey:strings
        var dict = new Dictionary<string, List<string>>();

        // 2. Sort each string, store to sortedKey
        foreach (string str in strs) {
            string temp = new string(str.OrderBy(ch => ch).ToArray());

            if (dict.TryGetValue(temp, out List<string> list)) {
                list.Add(str);
            } else {
                dict[temp] = new List<string>() { str };
            }
        }

        // 3. Return the Values of dictionary
        return dict.Values.ToList();
    }
}
