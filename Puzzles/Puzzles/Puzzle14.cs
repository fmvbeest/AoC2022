using System.Data;
using AoC2022.Util;

namespace AoC2022.Puzzles;

public class Puzzle14 : PuzzleBase<List<List<Coordinate>>, int, int>
{
    protected override string Filename => "Input/puzzle-input-14";
    protected override string PuzzleTitle => "--- Day 14: Regolith Reservoir ---";

    private HashSet<Coordinate> _rocks;
    private HashSet<Coordinate> _sand;

    public override int PartOne(List<List<Coordinate>> input)
    {
        _rocks = InitializeRocks(input);
        _sand = new HashSet<Coordinate>();
        
        var bottom = _rocks.Select(x => x.Y).Max();
        var sandSource = new Coordinate(500, 0);
        var intoTheAbyss = false;

        while (!intoTheAbyss)
        {
            var sandUnit = sandSource;
            var isBlocked = false;
            while (!isBlocked)
            {
                if (sandUnit.Y > bottom)
                {
                    intoTheAbyss = true;
                    break;
                }
                
                if (!IsBlocked(sandUnit + (0, 1), _rocks, _sand))
                {
                    sandUnit += (0, 1);
                    continue;
                }
                if (!IsBlocked(sandUnit + (-1, 1), _rocks, _sand))
                {
                    sandUnit += (-1, 1);
                    continue;
                }
                if (!IsBlocked(sandUnit + (1, 1), _rocks, _sand))
                {
                    sandUnit += (1, 1);
                    continue;
                }

                _sand.Add(sandUnit);
                isBlocked = true;
            }
        }

        return _sand.Count;
    }

    public override int PartTwo(List<List<Coordinate>> input)
    {
        _rocks = InitializeRocks(input);
        _sand = new HashSet<Coordinate>();
       
        var bottom = _rocks.Select(x => x.Y).Max() + 2;
        var sandSource = new Coordinate(500, 0);
        var sourceBlocked = false;
        
        while (!sourceBlocked)
        {
            var sandUnit = sandSource;
            var isBlocked = false;
            while (!isBlocked)
            {
                if (!IsBlocked(sandUnit + (0, 1), _rocks, _sand) && sandUnit.Y != bottom-1)
                {
                    sandUnit += (0, 1);
                    continue;
                }
                if (!IsBlocked(sandUnit + (-1, 1), _rocks, _sand) && sandUnit.Y != bottom-1)
                {
                    sandUnit += (-1, 1);
                    continue;
                }
                if (!IsBlocked(sandUnit + (1, 1), _rocks, _sand) && sandUnit.Y != bottom-1)
                {
                    sandUnit += (1, 1);
                    continue;
                }

                _sand.Add(sandUnit);
                if (sandUnit.Equals(sandSource))
                {
                    sourceBlocked = true;
                    break;
                }
                
                isBlocked = true;
            }
        }

        return _sand.Count;
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