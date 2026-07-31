public class Solution {

    // Pattern: directions
    private int[][] directions = new int[][]
    {
        new int[] { 0, 1 },
        new int[] { 0, -1 },
        new int[] { 1, 0 },
        new int[] { -1, 0 }
    };

    public int NumIslands(char[][] grid) {
        // Pattern: res
        int res = 0;

        // Pattern: traverse matrix
        for (int r = 0; r < grid.Length; r++) {
            for (int c = 0; c < grid[0].Length; c++) {
                if (grid[r][c] == '1') {
                    Dfs(r, c, grid);
                    res++;
                }
            }
        }

        return res;
    }

    // Pattern: void DFS
    private void Dfs(int r, int c, char[][] grid) {
        // Pattern: bound check
        if (r < 0 || c < 0 || r > grid.Length -1 || c > grid[0].Length - 1) {
            return;
        }

        // Pattern: base case
        if (grid[r][c] == '0') {
            return;
        }

        // Pattern: mark visited
        grid[r][c] = '0';

        // Pattern: recurse
        foreach (int[] dir in directions) {
            Dfs(r + dir[0], c + dir[1], grid);
        }
    }
}
