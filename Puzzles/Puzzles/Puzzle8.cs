namespace AoC2022.Puzzles;

public class Puzzle8 : PuzzleBase<int[][], int, int>
{
    protected override string Filename => "Input/puzzle-input-08";
    protected override string PuzzleTitle => "--- Day 8: Treetop Tree House ---";

    public override int PartOne(int[][] grid)
    {
        var numVisible = 0;
        for (var i = 1; i < grid.Length-1; i++)
        {
            for (var j = 1; j < grid[i].Length-1; j++)
            {
                if (IsVisible(i, j, grid))
                {
                    numVisible++;
                }
            }
        }
        return numVisible + 2 * grid.Length + 2 * (grid[0].Length - 2);
    }

    public override int PartTwo(int[][] grid)
    {
        var scenicScore = 0;
        for (var i = 1; i < grid.Length-1; i++)
        {
            for (var j = 1; j < grid[i].Length-1; j++)
            {
                scenicScore = Math.Max(scenicScore, ScenicScore(i, j, grid));
            }
        }
        return scenicScore;
    }
    
    public override int[][] Preprocess(IPuzzleInput input, int part = 1)
    {
        return input.GetAllLines().Select(line => line.Select(c => c-'0').ToArray()).ToArray();
    }

    private static bool IsVisible(int row, int column, IReadOnlyList<int[]> grid)
    {
        var tree = grid[row][column];

        return GetLeft(row, column, grid).All(t => t < tree) 
               || GetRight(row, column, grid).All(t => t < tree)
               || GetTop(row, column, grid).All(t => t < tree)
               || GetBottom(row, column, grid).All(t => t < tree);
    }

    private static IEnumerable<int> GetHorizontal(int start, int end, int row, IReadOnlyList<int[]> grid)
    {
        var res = new List<int>();
        for (var i = start; i < end; i++)
        {
            res.Add(grid[row][i]);
        }
        return res;
    }

    private static IEnumerable<int> GetLeft(int row, int column, IReadOnlyList<int[]> grid)
    {
        return GetHorizontal(0, column, row, grid);
    }
    
    private static IEnumerable<int> GetRight(int row, int column, IReadOnlyList<int[]> grid)
    {
        return GetHorizontal(column + 1, grid[row].Length, row, grid);
    }

    private static IEnumerable<int> GetVertical(int start, int end, int column, IReadOnlyList<int[]> grid)
    {
        var res = new List<int>();
        for (var i = start; i < end; i++)
        {
            res.Add(grid[i][column]);
        }
        return res;
    }
    
    private static IEnumerable<int> GetTop(int row, int column, IReadOnlyList<int[]> grid)
    {
        return GetVertical(0, row, column, grid);
    }
    
    private static IEnumerable<int> GetBottom(int row, int column, IReadOnlyList<int[]> grid)
    {
        return GetVertical(row+1, grid.Count, column, grid);
    }

    private static int ScenicScore(int row, int column, int[][] grid)
    {
        var score = 1;
        
        if ((score *= ViewingDistance(GetLeft(row, column, grid).Reverse(), grid[row][column])) == 0)
            return score;
        
        if ((score *= ViewingDistance(GetRight(row, column, grid), grid[row][column])) == 0)
            return score;
        
        if ((score *= ViewingDistance(GetTop(row, column, grid).Reverse(), grid[row][column])) == 0)
            return score;

        return score * ViewingDistance(GetBottom(row, column, grid), grid[row][column]);
    }

    private static int ViewingDistance(IEnumerable<int> treeline, int height)
    {
        var distance = 0;
        foreach (var t in treeline)
        {
            distance++;
            if (t >= height) break;
        }
        return distance;
    }
}