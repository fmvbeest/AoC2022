using AoC2022.Util;
using Directory = AoC2022.Util.Directory;
using File = AoC2022.Util.File;

namespace AoC2022.Puzzles;

public class Puzzle8 : PuzzleBase<int, int[][]>
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
                if (isVisible(i, j, grid))
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
        var lines = input.GetInput().ToArray();

        return lines.Select(line => line.Select(c => int.Parse(c.ToString())).ToArray()).ToArray();
    }

    private bool isVisible(int row, int column, int[][] grid)
    {
        var tree = grid[row][column];

        var left = GetLeft(row, column, grid).All(t => t < tree);
        
        var right = GetRight(row, column, grid).All(t => t < tree);
        
        var top = GetTop(row, column, grid).All(t => t < tree);
        
        var bottom = GetBottom(row, column, grid).All(t => t < tree);


        return left || right || top || bottom;
    }

    private int[] GetLeft(int row, int column, int[][] grid)
    {
        var res = new List<int>();
        for (var i = 0; i < column; i++)
        {
            res.Add(grid[row][i]);
        }
        return res.ToArray();
    }
    
    private int[] GetRight(int row, int column, int[][] grid)
    {
        var res = new List<int>();
        for (var i = column+1; i < grid[row].Length; i++)
        {
            res.Add(grid[row][i]);
        }
        return res.ToArray();
    }

    private int[] GetTop(int row, int column, int[][] grid)
    {
        var res = new List<int>();
        for (var i = 0; i < row; i++)
        {
            res.Add(grid[i][column]);
        }

        return res.ToArray();
    }
    
    private int[] GetBottom(int row, int column, int[][] grid)
    {
        var res = new List<int>();
        for (var i = row+1; i< grid.Length; i++)
        {
            res.Add(grid[i][column]);
        }
        return res.ToArray();
    }

    private int ScenicScore(int row, int column, int[][] grid)
    {
        var score = 1;
        
        var left = GetLeft(row, column, grid).Reverse().ToArray();
        score *= ViewingDistance(left, grid[row][column]);
        
        var right = GetRight(row, column, grid).ToArray();
        score *= ViewingDistance(right, grid[row][column]);
        
        var top = GetTop(row, column, grid).Reverse().ToArray();
        score *= ViewingDistance(top, grid[row][column]);
        
        var bottom = GetBottom(row, column, grid).ToArray();
        score *= ViewingDistance(bottom, grid[row][column]);

        return score;
    }

    private int ViewingDistance(int[] treeline, int height)
    {
        var distance = 0;
        
        for (int i = 0; i < treeline.Length; i++)
        {
            distance++;
            if (treeline[i] >= height)
            {
                break;
            }
        }

        return distance;
    }
}