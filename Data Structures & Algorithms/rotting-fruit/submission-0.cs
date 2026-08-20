public class Solution {
    // Directions
    private int[][] directions = new int[][] {
        new int[] { 0, 1},
        new int[] { 1, 0},
        new int[] { 0 , -1},
        new int[] { -1, 0}
    };

    public int OrangesRotting(int[][] grid) { 
        int rows = grid.Length;
        int cols = grid[0].Length;
        int minutes = 0;
        
        // 1. Seed data to prep kickoff
        var q = new Queue<(int, int)>();
        int freshOranges = 0;

        for (int r = 0; r < rows; r++) {
            for (int c = 0; c < cols; c++) {
                if (grid[r][c] == 2) q.Enqueue((r, c));
                if (grid[r][c] == 1) freshOranges++;
            }
        }

        // 2. BFS traversal; check queue and fresh oranges count; without the fresh oranges check, we will iterate one additional time, incrementing another minute
        while (q.Count > 0 && freshOranges > 0) {
            // Use snapshot length
            int cycle = q.Count;

            // For each rotten oranges, check neighbors
            for (int i = 0; i < cycle; i++) {
                // Dequeue each rotten orange, and trigger neighbor check
                var (x, y) = q.Dequeue();

                foreach (int[] dir in directions) {
                    // Compute neighbor coordinates
                    int nr = x + dir[0];
                    int nc = y + dir[1];

                    // For each neighbor check, check bounds first; if oob, skip this iteration
                    if (nr < 0 || nc < 0 || nr >= rows || nc >= cols) {
                        continue;
                    }

                    // If neighbor is '1', then this is neighbor of rotten orange; enqueue and rot orange by converting to '2'
                    if (grid[nr][nc] == 1) {
                        freshOranges--;
                        grid[nr][nc] = 2;
                        q.Enqueue((nr, nc));
                    }
                }
            }
            // After each cycle, increment time
            minutes++;
        }
        

        // 3. Evaluate final result
        return freshOranges == 0 ? minutes : -1;
    }
}
