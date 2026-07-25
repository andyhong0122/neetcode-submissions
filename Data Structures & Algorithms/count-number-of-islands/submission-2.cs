public class Solution {
    private readonly int[][] directions = new int[][]
    {
        // horizontal exploration
        new int[] {1, 0}, 
        new int[] {-1, 0},
        new int[] {0, 1}, 
        new int[] {0, -1}
    };

    public int NumIslands(char[][] grid) 
    {
        int islands = 0;

        for (int i = 0; i < grid.Length; i++) 
        {
            for (int j = 0; j < grid[i].Length; j++)
            {
                if (grid[i][j] == '1')
                {
                    Explore(grid, i, j);
                    // Once exploration is finished, we can increment island
                    islands++;
                }
            }
        }

        return islands;
    }

    private void Explore(char[][] grid, int row, int col)
    {
        // Base case: No more land to be explored, return and propagate our finding: 1 island!
        if (row < 0 || col < 0 || row >= grid.Length || col >= grid[0].Length || grid[row][col] == '0')
        {
            return;
        }

        // We can potentially save the visited coordinates (x,y) as a tuple key in dictionary, ACTUALLY hashset is more preferable
        // and check each time whether the '1' has been visited, but no need
        // Instead, just toggle the '1' to '0':
        grid[row][col] = '0';

        // Next, explore all directions
        foreach (int[] direction in directions)
        {
            Explore(grid, row + direction[0], col + direction[1]);
        }
    }
}

// Travese through matrix
    // if 0
        // skip
    // if 1
        // explore the land! DFS
        // adjacent -- W, N, E, S
        // continue following land until surrounded by water
            // remember the previous coordinate we came from [i][j] --> mark as visited '0'

