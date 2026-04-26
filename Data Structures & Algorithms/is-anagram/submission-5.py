class Solution:
    """
    Counter creates a dictionary of char frequencies
    """
    def isAnagram(self, s: str, t: str) -> bool:
        if len(s) != (len(t)):
            return False

        counter = Counter(s)
        print(counter)

        for c in counter:
            print(c)
        
        return Counter(s) == Counter(t)

class Solution:
    def isAnagram(self, s: str, t: str) -> bool:
        return sorted(s) == sorted(t)
