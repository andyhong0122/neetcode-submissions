public class Solution {
/*
[course, prereq]

If there is a cycle within the directed graph, then it is not directed.

1. We can construct a graph representing the course:prereqs nodes.
This will be used as our map to traverse.

2. The states can be managed with an int[number of courses]. 
Why do we want to manage states? To ensure we keep track of the node statuses as we check for any cycles.
An unvisited node will be '0'.
Visiting = '1'; 
Visited = '2'

3. For each of the courses we are managing state, recursively check whether any of them has a cycle. For this use a HasCycle method.

4. HasCycle(int course, Dictionary<int, List<int>> graph, int[] states)
Where course is the current course we are evaluating
Where graph is the entire graph of courses to check neighbors
Where states is the state of ech course we are managing

*/
    public bool CanFinish(int numCourses, int[][] prerequisites) {
        // Construct graph, where Key is prereqs, and Value are the post-prereq courses
        var graph = new Dictionary<int, List<int>>();

        // Populate graph
        foreach (int[] prereq in prerequisites) {
            int p = prereq[1];
            int c = prereq[0];

            if (!graph.ContainsKey(p)) {
                graph[p] = new List<int>();
            }

            graph[p].Add(c);
        }

        // Instantiate state manager for courses
        var states = new int[numCourses];

        // Check for each course of its status; here use the numCourses to ensure we check ALL courses, not just prerequisites
        for (int i = 0; i < numCourses; i++) { 
            if (states[i] == 0) {
                if (HasCycle(i, graph, states)) { // i is the course ID; this is guaranteed to be distinct
                    return false;
                }
            }
        }

        return true;
    }

    private bool HasCycle(int course, Dictionary<int, List<int>> graph, int[] states) {
        // Base cases
        // If course was already visited, return false
        if (states[course] == 2) return false;
        // If course is marked as visiting, this means there is a cycle; backtracking ensures any code is makred as 2 after being visited
        /*
        0 __ 1 __ 3
          \_ 2__
               |
               |__ 0 (cycle; our current course has been revisited during recursion, meaning there is a cycle from 2 to 0)
        */
        if (states[course] == 1) return true;

        // Choose
        states[course] = 1;

        // Explore; check graph whether course is indeed in the graph first
        if (graph.ContainsKey(course)) {
            foreach(int c in graph[course]) {
                if (HasCycle(c, graph, states)) { // if any branch in recursion returns true, bubble up true
                    return true;
                }
            }
        }

        // Unchoose
        states[course] = 2;

        return false;
    }
}
