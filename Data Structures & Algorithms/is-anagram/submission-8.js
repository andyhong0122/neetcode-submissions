/*
JS solution: O(n + m), where n is s.length and m is t.length
Space: At most 26 characters in the alphabet, O(1)
*/
class Solution {
    isAnagram(s, t) {
        if (s.length !== t.length) {
            return false;
        }

        // Dictionaries to store char:count
        let dictS = {}
        let dictT = {}

        // Iterate through first sample, store to dict
        for (let i = 0; i < s.length; i++) {
            dictS[s[i]] = (dictS[s[i]] || 0) + 1
            dictT[t[i]] = (dictT[t[i]] || 0) + 1
        }

        for (let key in dictS) {
            if (dictS[key] !== dictT[key]) {
                return false;
            }
        }

        return true;
    }
}
