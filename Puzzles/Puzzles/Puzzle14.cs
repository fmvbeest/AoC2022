using System.Data;
using AoC2022.Util;

namespace AoC2022.Puzzles;

public class Puzzle14 : PuzzleBase<List<List<Coordinate>>, int, int>
{
    protected override string Filename => "Input/puzzle-input-14";
    protected override string PuzzleTitle => "--- Day 14: Regolith Reservoir ---";

    public override int PartOne(List<List<Coordinate>> input)
    {
        var sandSource = new Coordinate(500, 0);

        var rocks = InitializeRocks(input);

        var bottom = rocks.Select(x => x.Y).Max();
        
        var sand = new HashSet<Coordinate>();

        var isBlocked = false;
        var intoTheAbyss = false;
       

        while (!intoTheAbyss)
        {
            var sandUnit = sandSource;
            isBlocked = false;
            while (!isBlocked)
            {
                if (sandUnit.Y > bottom)
                {
                    intoTheAbyss = true;
                    break;
                }
                
                if (!IsBlocked(sandUnit + (0, 1), rocks, sand))
                {
                    sandUnit += (0, 1);
                    continue;
                }
                if (!IsBlocked(sandUnit + (-1, 1), rocks, sand))
                {
                    sandUnit += (-1, 1);
                    continue;
                }
                if (!IsBlocked(sandUnit + (1, 1), rocks, sand))
                {
                    sandUnit += (1, 1);
                    continue;
                }

                sand.Add(sandUnit);
                isBlocked = true;
            }
        }

        return sand.Count;
    }

    public override int PartTwo(List<List<Coordinate>> input)
    {
        var sandSource = new Coordinate(500, 0);

        var rocks = InitializeRocks(input);

        var bottom = rocks.Select(x => x.Y).Max() + 2;
        
        var sand = new HashSet<Coordinate>();
        
        var isBlocked = false;
        var sourceBlocked = false;
       
        while (!sourceBlocked)
        {
            var sandUnit = sandSource;
            isBlocked = false;
            while (!isBlocked)
            {
                if (!IsBlocked(sandUnit + (0, 1), rocks, sand) && sandUnit.Y != bottom-1)
                {
                    sandUnit += (0, 1);
                    continue;
                }
                if (!IsBlocked(sandUnit + (-1, 1), rocks, sand) && sandUnit.Y != bottom-1)
                {
                    sandUnit += (-1, 1);
                    continue;
                }
                if (!IsBlocked(sandUnit + (1, 1), rocks, sand) && sandUnit.Y != bottom-1)
                {
                    sandUnit += (1, 1);
                    continue;
                }

                sand.Add(sandUnit);
                if (sandUnit.Equals(sandSource))
                {
                    sourceBlocked = true;
                    break;
                }
              

                isBlocked = true;
            }
        }

        return sand.Count;
    }
    
    public override List<List<Coordinate>> Preprocess(IPuzzleInput input, int part = 1)
    {
        var lines = input.GetAllLines();
        var list = new List<List<Coordinate>>();

        foreach (var line in lines)
        {
            var coordinates = line.Split(" -> ");
            var coorList = coordinates.Select(coor => coor.Split(',')).Select(s => new Coordinate(int.Parse(s[0]), int.Parse(s[1]))).ToList();
            list.Add(coorList);
        }

        return list;
    }

    private HashSet<Coordinate> InitializeRocks(List<List<Coordinate>> input)
    {
        var rocks = new HashSet<Coordinate>();
        
        foreach (var segments in input.Select(path => path.Skip(1).Zip(path, (prev, curr) => (curr,prev)).ToList()))
        {
            foreach (var (start, end) in segments)
            {
                var rockList = start.Range(end);

                foreach (var rock in rockList)
                {
                    rocks.Add(rock);
                }
            }
        }

        return rocks;
    }

    private bool IsBlocked(Coordinate x, HashSet<Coordinate> rocks, HashSet<Coordinate> sand)
    {
        return rocks.Contains(x) || sand.Contains(x);
    }

}