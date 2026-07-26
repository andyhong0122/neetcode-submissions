public class Solution {
    // **Pattern: Set directions to explore
    private int[][] directions = new int[][]{
        new int[] {0, 1},
        new int[] {0, -1}, 
        new int[] {1, 0},
        new int[] {-1, 0}
    };

    // Returns a 2D list where each element is [r, c] pair
    public List<List<int>> PacificAtlantic(int[][] heights) {
        List<List<int>> res = new List<List<int>>();

        if (heights == null || heights.Length == 0) {
            return res;
        }

        // **Pattern: set rows and columns
        int rows = heights.Length;
        int cols = heights[0].Length;

        // **Pattern: Maintain visited/seen coordinates
        // Maintain hashset of lands connected to pacific/atlantic
        HashSet<(int, int)> pacific = new HashSet<(int, int)>();
        HashSet<(int, int)> atlantic = new HashSet<(int, int)>();

        // Explore the lands connected oceans.
        // For rows, top row[0] is connected to pacific, and bottom [rows.Length - 1] is connected to atlantic
        for (int c = 0; c < cols; c++) {
            Explore(0, c, heights[0][c], pacific, heights);
            Explore(rows - 1, c, heights[rows - 1][c], atlantic, heights);
        }

        // For columns, left col[0] is connected to pacific, and right [cols.Length - 1] is connected to atlanti
        for (int r = 0; r < rows; r++) {
            Explore(r, 0, heights[r][0], pacific, heights);
            Explore(r, cols - 1, heights[r][cols - 1], atlantic, heights);
        }

        // Finally, after exploration, check for cross between pacific and atlantic, return to res
        foreach ((int r, int c) in pacific) {
            if (atlantic.Contains((r, c))) {
                res.Add(new List<int>() { r, c});
            }
        }

        return res;
    }

    // Recursive method to append to call stack
    // **Pattern: Does not return an exact value, handles marking, and passes in grid by reference
    private void Explore(int r, int c, int prevHeight, HashSet<(int, int)> visited, int[][] heights){
        // **Pattern: return base case -- oob, value not matching condition
        if (r < 0 || c < 0 || r >= heights.Length || c >= heights[0].Length) {
            return;
        }

        // Values not matching condition
        if (prevHeight > heights[r][c] || visited.Contains((r, c))) {
            return;
        }

        visited.Add((r, c));

        // After adding our coordinate to visited, explore further
        // Each dir is an int[]
        foreach (var dir in directions) {
            Explore(r + dir[0], c + dir[1], heights[r][c], visited, heights);
        }
    }
}