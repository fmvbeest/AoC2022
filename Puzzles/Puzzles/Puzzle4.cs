﻿namespace AoC2022.Puzzles;

public class Puzzle4 : PuzzleBase
{
    protected override string Filename => "Input/puzzle-input-04";
    protected override string PuzzleTitle => "--- Day 4: Camp Cleanup ---";
    
    public override int PartOne(IPuzzleInput input)
    {
        return Preprocess(input).Count(p => IsSubRange(p.a, p.b) || IsSubRange(p.b, p.a));
    }

    public override int PartTwo(IPuzzleInput input)
    {
        return Preprocess(input).Count(p => Overlap(p.a, p.b));
    }

    private static bool IsSubRange(Range a, Range b)
    {
        return a.Start.Value >= b.Start.Value && a.End.Value <= b.End.Value;
    }

    private static bool Overlap(Range a, Range b)
    {
        return a.Start.Value <= b.End.Value && b.Start.Value <= a.End.Value;
    }
    
    private static IEnumerable<(Range a, Range b)> Preprocess(IPuzzleInput input)
    {
        return (from line in input.GetAllLines() 
            select line.Split(',') into sections 
            let rangex = sections[0].Split('-') 
            let rangey = sections[1].Split('-') 
            let x = new Range(new Index(int.Parse(rangex[0])), new Index(int.Parse(rangex[1]))) 
            let y = new Range(new Index(int.Parse(rangey[0])), new Index(int.Parse(rangey[1]))) 
            select (x, y)).ToList();
    }
}