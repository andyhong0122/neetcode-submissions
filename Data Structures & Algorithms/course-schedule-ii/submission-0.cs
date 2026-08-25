public class Solution {
    public int[] FindOrder(int numCourses, int[][] prerequisites) {
        // Graph
        var graph = new Dictionary<int, List<int>>();

        // Populate graph
        foreach (int[] pc in prerequisites) {
            int prereq = pc[1];
            int course = pc[0];

            if (!graph.ContainsKey(prereq)) {
                graph[prereq] = new List<int>();
            }

            graph[prereq].Add(course);
        }

        // State management & Courses
        var states = new int[numCourses];
        var res = new List<int>();

        // Traverse
        for (int i = 0; i < numCourses; i++) {
            if (states[i] == 0) {
                // If any cycles, return []
                if (HasCycle(i, graph, states, res)) {
                    return new int[0];
                }
            }
        }

        // No cycles found during traversal, return list of courses, reversed
        res.Reverse();
        return res.ToArray();
    }

    private bool HasCycle(int course, Dictionary<int, List<int>> graph, int[] states, List<int> res) {
        if (states[course] == 1) return true;
        if (states[course] == 2) return false;

        states[course] = 1;

        if (graph.ContainsKey(course)) {
            foreach (int c in graph[course]) {
                if (HasCycle(c, graph, states, res)) {
                    return true;
                }
            }
        }

        // No cycle, and reached end of courses sequence
        states[course] = 2;
        res.Add(course);

        return false;
    }
}
