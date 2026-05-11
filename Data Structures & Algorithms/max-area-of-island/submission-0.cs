public class Solution {
    public int MaxAreaOfIsland(int[][] grid) {
        int area = 0;

        // 1.1 Iterate through entire grid 
        for (int row = 0; row < grid.Length; row++) {
            for (int col = 0; col < grid[0].Length; col++) {
        // 1.2. If 1 is seen, then perform dfs
                if (grid[row][col] == 1) {
        // 2.1. From start of 1, search all directions; careful to not go out of bounds
                    area = Math.Max(area, search(grid, row, col));
                }
            }
        }

        return area;
    }

    private int search(int[][] grid, int row, int col) {
        int[][] directions = new int[][] {
            new int[] {1, 0}, // right
            new int[] {-1, 0}, // left
            new int[] {0, 1}, // top
            new int[] {0, -1} // down
        };

        // 2.2. If coordinate is out of bounds or no longer land, return 0
        if (row < 0 || col < 0 || row > grid.Length - 1 || col > grid[0].Length - 1 
        || grid[row][col] == 0) {
            return 0;
        }
        
        // 2.3. If not, set current coordinate to 0 to prevent dupe, then visit ALL directions
            // Note: If a direction does not result in land, we will return 0 any way as in 2.2
        grid[row][col] = 0;
        int area = 1;
        foreach (int[] direction in directions) {
            area += search(grid, row + direction[0], col + direction[1]);
        }

        return area;
    }
}

// DFS - when land is found, keep expanding
    // Only check horizontal and vertical
    // Should know which part of land is seen

// Memoize island that is already visited
    // Via recording coordinates
    // If land is already visited, we already examined whole land