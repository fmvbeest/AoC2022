﻿namespace AoC2022.Puzzles;

public class Puzzle1 : PuzzleBase
{
    protected override string Filename => "Input/puzzle-input-01";
    protected override string PuzzleTitle => "--- Day 1: Calorie Counting ---";

    public override int PartOne(IPuzzleInput input)
    {
        return Preprocess(input).Select(x => x.Sum()).Max();
    }

    public override int PartTwo(IPuzzleInput input)
    {
        return Preprocess(input).Select(x => x.Sum()).OrderByDescending(x => x).Take(3).Sum();
    }

    private static IEnumerable<IEnumerable<int>> Preprocess(IPuzzleInput input)
    {
        var index = 0;
        return input.GetAllLines().
            GroupBy(x => !string.IsNullOrEmpty(x) ? index : index++, 
                x => !string.IsNullOrEmpty(x) ? int.Parse(x) : 0);
    }
}